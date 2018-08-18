using System.Collections.Generic;
using System.Diagnostics;

namespace MediaHelper.MediaPlayerObserver
{
    public class ProcessManager
    {
        private readonly Dictionary<string,Process>  _process;
        private static ProcessManager _instance;

        public static ProcessManager Instance => _instance ?? (_instance = new ProcessManager());

        private ProcessManager()
        {
            _process = new Dictionary<string, Process>();
        }


        public void StartProcess(string path)
        {
            if(IsProcessRunning(path)) return;
         
            _process.Add(path,Process.Start(path));
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
            if(IsProcessRunning(path))
                _process[path].Kill();
        }
    }
}