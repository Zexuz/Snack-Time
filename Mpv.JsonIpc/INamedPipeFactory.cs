using System.IO.Pipes;

namespace Mpv.JsonIpc
{
    public interface INamedPipeFactory
    {
        NamedPipeClientStream CreateNamedPipe();
    }
}