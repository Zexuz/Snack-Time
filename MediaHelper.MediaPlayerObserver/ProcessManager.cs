using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MediaHelper.MediaPlayerObserver
{
    public class ProcessManager
    {
        private        List<Process>  _process;
        private static ProcessManager _instance;

        public static ProcessManager Instance => _instance ?? (_instance = new ProcessManager());

        public ProcessManager()
        {
            _process = new List<Process>();
        }


        public void StartProcess(string path)
        {
            _process.Add(Process.Start(path));
        }

        public bool IsProcessRunning(string path)
        {
            var runningProcesses = _process.Where(process => !process.HasExited).Select(process => process.StartInfo.FileName);
            return runningProcesses.Any(s => s == path);
        }
    }
}