using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackTime.Core;
using SnackTime.Core.Settings;
using SnackTime.MediaServer.Service.File;
using File = System.IO.File;

namespace SnackTime.WebApi.Services
{
    public class FileDownloadService
    {
        private readonly ILogger<FileDownloadService>             _logger;
        private readonly MediaServer.Service.File.File.FileClient _client;
        private readonly FileService                              _fileService;
        private readonly SettingsService                          _settingsService;

        public FileDownloadService
        (
            ILogger<FileDownloadService> logger,
            GrpcClientProvider clientProvider,
            FileService fileService,
            SettingsService settingsService
        )
        {
            _logger = logger;
            _client = clientProvider.GetFileClient();
            _fileService = fileService;
            _settingsService = settingsService;
        }

        public async Task DownloadFile(MediaFileId id)
        {
            var streamingCall = _client.Download(new DownloadFileRequest
            {
                MediaFileId = id.ToString(),
            });

            var settings = _settingsService.Get();


            double nrOfChunks = 0;

            var currentChunk = 0;
            var currentTempFileIndex = 0;

            FileStream fileStream = null;

            const int tempFileSize = 1024 * 10 * 10;

            var fileName = "";

            _logger.LogInformation($"Starting to download file");

            var stopwatch = Stopwatch.StartNew();
            while (await streamingCall.ResponseStream.MoveNext(CancellationToken.None))
            {
                var res = streamingCall.ResponseStream.Current;

                switch (res.TypeCase)
                {
                    case ResponseDownloadFile.TypeOneofCase.Started:
                        fileName = res.Started.FileName;
                        nrOfChunks = (int) Math.Ceiling(res.Started.Lenght / res.Started.SizePerChunk);
                        _logger.LogTrace($"Length is {res.Started.Lenght}");
                        _logger.LogTrace($"ChunkSize is {res.Started.SizePerChunk}");
                        _logger.LogTrace($"Nr of chunks should be {nrOfChunks}");
                        break;
                    case ResponseDownloadFile.TypeOneofCase.Progress:
                        if (currentChunk % tempFileSize == 0)
                        {
                            if (fileStream != null)
                            {
                                fileStream.Close();
                                fileStream.Dispose();
                            }

                            fileStream = File.Create(settings.System.TempFileDir + $"{fileName}.{currentTempFileIndex}.temp");

                            currentTempFileIndex++;
                        }

                        var byteArray = res.Progress.Content.ToByteArray();
                        await fileStream.WriteAsync(byteArray, 0, byteArray.Length);

                        if (currentChunk % 1000 == 0)
                        {
                            _logger.LogTrace($"Progress {currentChunk / nrOfChunks:P}");
                        }

                        currentChunk++;
                        break;
                    case ResponseDownloadFile.TypeOneofCase.Done:
                        _logger.LogDebug($"Downloaded chunks in {stopwatch.Elapsed:g}");

                        fileStream.Close();
                        fileStream.Dispose();

                        var sw = Stopwatch.StartNew();
                        var filePattern = $"{fileName}.*.temp";
                        await _fileService.CombineMultipleFilesIntoSingleFile(settings.System.TempFileDir, filePattern, settings.System.FileDir + fileName);

                        string hash;
                        using (Stream source = File.OpenRead(settings.System.FileDir + fileName))
                        using (var md5 = MD5.Create())
                        {
                            var byteHash = md5.ComputeHash(source);
                            hash = BitConverter.ToString(byteHash).Replace("-", "").ToLowerInvariant();
                        }

                        // TODO
                        //This needs to be the zip:ed file, else there will be a missmatch.
//                        if (hash != res.Done.Hash)
//                        {
//                            throw new HashMismatchException(res.Done.Hash, hash);
//                        }

                        _logger.LogDebug($"Combined files in {sw.Elapsed:g}");
                        sw.Stop();
                        break;
                    case ResponseDownloadFile.TypeOneofCase.None:
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            stopwatch.Stop();

            _logger.LogInformation($"It took {stopwatch.Elapsed:g}");
        }
    }

    public class HashMismatchException : Exception
    {
        public HashMismatchException(string expected, string actual) : base($"Hash mismatch, Expected '{expected}', actual {actual} ")
        {
        }
    }
}