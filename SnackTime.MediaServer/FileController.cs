using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using SnackTime.MediaServer.Service.File;
using File = System.IO.File;

namespace SnackTime.MediaServer
{
    class FileController : SnackTime.MediaServer.Service.File.File.FileBase
    {
        public override async Task Download
        (
            DownloadFileRequest request,
            IServerStreamWriter<ResponseDownloadFile> responseStream,
            ServerCallContext context
        )
        {
            var fileName = "Superstore.S04E15.1080p.WEB.H264-METCON.mkv";
            var path = @"D:\Downloads\Torrents\Superstore.S04E15.1080p.WEB.H264-METCON\";
            var chunkSize = 2048;
            using (Stream source = File.OpenRead(path + fileName))
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