using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using SnackTime.Core;
using SnackTime.Core.Media.Episodes;
using SnackTime.MediaServer.Service.File;
using File = System.IO.File;

namespace SnackTime.MediaServer
{
    class FileController : SnackTime.MediaServer.Service.File.File.FileBase
    {
        private readonly EpisodeFileLookupProvider _episodeFileLookupProvider;

        public FileController(EpisodeFileLookupProvider episodeFileLookupProvider)
        {
            _episodeFileLookupProvider = episodeFileLookupProvider;
        }

        public override async Task Download
        (
            DownloadFileRequest request,
            IServerStreamWriter<ResponseDownloadFile> responseStream,
            ServerCallContext context
        )
        {
            if (!MediaFileId.TryParse(request.MediaFileId, out var mediaFileId))
            {
                throw new Exception("Invalid mediaFileId");
            }

            var info = await _episodeFileLookupProvider.GetFileInfoForId(mediaFileId.FileId);


            var backSlashIndex = info.Path.LastIndexOf("\\", StringComparison.CurrentCultureIgnoreCase);
            var index = backSlashIndex > -1 ? backSlashIndex : info.Path.LastIndexOf("/", StringComparison.CurrentCultureIgnoreCase);

            var fileName = info.Path.Substring(index + 1);

            var chunkSize = 2048;
            using (Stream source = File.OpenRead(info.Path))
            {
                byte[] buffer = new byte[chunkSize];
                int bytesRead;

                await responseStream.WriteAsync(new ResponseDownloadFile
                {
                    Started = new Started
                    {
                        FileName = fileName,
                        Lenght = source.Length,
                        SizePerChunk = chunkSize,
                    }
                });


                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    await responseStream.WriteAsync(new ResponseDownloadFile
                    {
                        Progress = new Chunk
                        {
                            Content = ByteString.CopyFrom(buffer, 0, bytesRead)
                        }
                    });
                }

                source.Seek(0, SeekOrigin.Begin);

                string hash;
                using (var md5 = MD5.Create())
                {
                    var byteHash = md5.ComputeHash(source);
                    hash = BitConverter.ToString(byteHash).Replace("-", "").ToLowerInvariant();
                }

                await responseStream.WriteAsync(new ResponseDownloadFile
                {
                    Done = new Done
                    {
                        Hash = hash
                    }
                });
            }
        }
    }
}