using System.Collections.Generic;

namespace SnackTime.Core.Process
{
    public class ProcessManager : IProcessManager
    {
        private readonly Dictionary<string, System.Diagnostics.Process> _process;

        public ProcessManager()
        {
            _process = new Dictionary<string, System.Diagnostics.Process>();
        }


        public void StartProcess(string path, string[] args = null)
        {
            if (IsProcessRunning(path)) return;

            var process = System.Diagnostics.Process.Start(path, string.Join(" ", args));
            _process.Add(path, process);
        }

        public bool IsProcessRunning(string path)
        {
            if (!_process.ContainsKey(path))
                return false;

            if (!_process[path].HasExited) return true;

            _process.Remove(path);
            return false;
        }

        public void StopProcess(string path)
        {
            if (IsProcessRunning(path))
                _process[path].Kill();
        }
    }
}