using System;
using System.Threading.Tasks;
using MediaHelper.Protobuf.generated;
using MediaHelper.Protobuf.grpc.Models;

namespace MediaHelper.Protobuf.grpc.Impl
{
    public class MediaPlayerClient : GrpcClientBase
    {
        private readonly MediaPlayerService.MediaPlayerServiceClient _client;

        public MediaPlayerClient(string ip, int port) : base(ip, port)
        {
            Start();
            _client = new MediaPlayerService.MediaPlayerServiceClient(GetChannel());
        }

        public async Task<GrpcResponse<EmptyMessage>> OpenFile(string filePath, TimeSpan? startPosition = null, bool startInFullscreen = false)
        {
            var reg = new OpenFile
            {
                FileName = filePath,
                FromSeconds = startPosition?.TotalSeconds ?? 0,
                StartInFullscreen = startInFullscreen
            };
            return await ExecuteAsync(_client.OpenAsync(reg, deadline: GetDeadline()));
        }

        public async Task<GrpcResponse<PlayingMediaInfo>> Info()
        {
            return await ExecuteAsync(_client.InfoAsync(new EmptyMessage(), deadline: GetDeadline()));
        }

        public async Task<GrpcResponse<EmptyMessage>> OpenMediaPlayer()
        {
            return await ExecuteAsync(_client.StartAsync(new EmptyMessage(), deadline: GetDeadline()));
        }

        public async Task<GrpcResponse<EmptyMessage>> CloseMediaPlayer()
        {
            return await ExecuteAsync(_client.StopAsync(new EmptyMessage(), deadline: GetDeadline()));
        }

        public async Task<GrpcResponse<IsRunning>> CheckIfMediaPlayerIsRunning()
        {
            return await ExecuteAsync(_client.IsRunningAsync(new EmptyMessage(), deadline: GetDeadline()));
        }

        public async Task<GrpcResponse<EmptyMessage>> Init(string mediaPlayerPath)
        {
            return await ExecuteAsync(_client.InitAsync(new Init
            {
                MediaPlayerPath = mediaPlayerPath
            }, deadline: GetDeadline()));
        }
    }
}