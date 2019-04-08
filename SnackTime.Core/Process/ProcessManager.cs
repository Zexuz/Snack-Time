using System.Linq;

namespace SnackTime.Core.Process
{
    public class ProcessManager : IProcessManager
    {
        public void StartProcess(string path, string[] args = null)
        {
            if (IsProcessRunning(path)) return;

            System.Diagnostics.Process.Start(path, string.Join(" ", args));
        }

        public bool IsProcessRunning(string path)
        {
            return GetProcessFromPath(path) == null;
        }

        public System.Diagnostics.Process GetProcessFromPath(string path)
        {
            var processes = System.Diagnostics.Process.GetProcesses();
            return processes.Where(process =>
            {
                try
                {
                    if (process.MainModule.FileName == path)
                    {
                        return true;
                    }
                }
                catch
                {
                    // ignored
                }

                return false;
            }).SingleOrDefault();
        }
    }
}