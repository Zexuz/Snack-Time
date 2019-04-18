using System;

namespace SnackTime.Core.Process
{
    public class ProcessManager
    {
        public void StartProcess(string path)
        {
            StartProcess(path, new string[0]);
        }

        public void StartProcess(string path, string[] args)
        {
            if (IsProcessRunning(path)) return;

            System.Diagnostics.Process.Start(path, string.Join(" ", args));
        }

        public bool IsSvpRunning()
        {
            return IsProcessRunning("SVPManager");
        }

        public bool IsMpvRunning()
        {
            return IsProcessRunning("MPV");
        }

        private bool IsProcessRunning(string name)
        {
            return System.Diagnostics.Process.GetProcessesByName(name).Length == 1;
        }
    }
}