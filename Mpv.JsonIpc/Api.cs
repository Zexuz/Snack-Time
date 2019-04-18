using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Mpv.JsonIpc
{
    public class Api : IApi
    {
        private readonly IIpc _ipc;

        public Api(IIpc ipc)
        {
            _ipc = ipc;
        }

        public async Task ShowText(string text, TimeSpan duration)
        {
            var request = _ipc.CreateCommand(new[] {"show-text", text}, duration.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
            await _ipc.ExecuteCommand<string>(request);
        }

        public async Task<float> GetVolume()
        {
            var result = await _ipc.GetProperty<float>(Property.Volume);
            return result.Data;
        }

        public async Task PlayMedia(string path)
        {
            var request = _ipc.CreateCommand(new[] {"loadfile", path});
            await _ipc.ExecuteCommand<string>(request);
        }

        public async Task<TimeSpan> GetCurrentPosition()
        {
            var result = await _ipc.GetProperty<double>(Property.Position);
            return TimeSpan.FromSeconds(result.Data);
        }

        public async Task<TimeSpan> GetDuration()
        {
            var result = await _ipc.GetProperty<double>(Property.Duration);
            return TimeSpan.FromSeconds(result.Data);
        }
    }
}