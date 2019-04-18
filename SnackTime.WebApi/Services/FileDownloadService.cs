using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackTime.MediaServer.Service.File;
using File = System.IO.File;

namespace SnackTime.WebApi.Services
{
    public class FileDownloadService
    {
        private readonly ILogger<FileDownloadService>             _logger;
        private readonly MediaServer.Service.File.File.FileClient _client;
        private readonly FileService                              _fileService;

        public FileDownloadService
        (
            ILogger<FileDownloadService> logger,
            MediaServer.Service.File.File.FileClient client,
            FileService fileService
        )
        {
            _logger = logger;
            _client = client;
            _fileService = fileService;
        }

        public async Task DownloadFile()
        {
            var response = _client.Download(new DownloadFileRequest());

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var requestStream = response.ResponseStream;

            double nrOfChunks = 0;

            var currentChunk = 0;
            var currentTempFileIndex = 0;

            FileStream fileStream = null;

            var tempPath = "D:\\SnackTime\\Temp\\";
            string fileName = "";
            string fileOutputPath = "D:\\SnackTime\\";

            while (await requestStream.MoveNext(CancellationToken.None))
            {
                var res = requestStream.Current;

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
                        if (currentChunk % (1024 * 10 * 10) == 0)
                        {
                            if (fileStream != null)
                            {
                                fileStream.Close();
                                fileStream.Dispose();
                            }

                            fileStream = File.Create(tempPath + $"{fileName}.{currentTempFileIndex}.temp");

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
                        _logger.LogTrace($"Hash is {res.Done.Hash}");
                        fileStream.Close();
                        fileStream.Dispose();
                        _logger.LogInformation($"Downloaded chunks in {stopwatch.Elapsed:g}");

                        var s = Stopwatch.StartNew();
                        var filePattern = $"{fileName}.*.temp";
                        await _fileService.CombineMultipleFilesIntoSingleFile(tempPath, filePattern, fileOutputPath + fileName);
                        _logger.LogInformation($"Combined files in {s.Elapsed:g}");
                        s.Stop();
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
}