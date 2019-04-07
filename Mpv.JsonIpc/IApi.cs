using System;
using System.Threading.Tasks;

namespace Mpv.JsonIpc
{
    public interface IApi
    {
        Task        ShowText(string text, TimeSpan duration);
        Task<float> GetVolume();
        Task PlayMedia(string path);
    }
}