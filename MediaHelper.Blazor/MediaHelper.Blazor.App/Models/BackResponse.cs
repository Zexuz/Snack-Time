using MediaHelper.Model;

namespace MediaHelper.Blazor.App.Services
{
    public struct BackResponse
    {
        public FileExploror FileExploror { get; set; }
        public string       NewPath      { get; set; }
    }
}