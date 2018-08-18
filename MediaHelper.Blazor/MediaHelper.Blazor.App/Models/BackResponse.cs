using MediaHelper.Model;

namespace MediaHelper.Blazor.App.Models
{
    public struct BackResponse
    {
        public FileExploror FileExploror { get; set; }
        public string       NewPath      { get; set; }
    }
}