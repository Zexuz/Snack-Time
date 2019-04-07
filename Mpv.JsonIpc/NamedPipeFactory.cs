using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Mpv.JsonIpc
{
    public class NamedPipeFactory : INamedPipeFactory
    {
        public NamedPipeClientStream CreateNamedPipe()
        {
            var pipeName = GetPipeNameForCurrentOs();
            return new NamedPipeClientStream(".", pipeName, PipeDirection.InOut, PipeOptions.Asynchronous, TokenImpersonationLevel.Anonymous);
        }

        public static string GetPipeNameForCurrentOs()
        {
            const string linuxOrMacPipeName = "/tmp/mpvsocket";
            const string windowsPipeName = "mpvpipe";

            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            return isWindows ? windowsPipeName : linuxOrMacPipeName;
        }
    }
}