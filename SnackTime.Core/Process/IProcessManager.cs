namespace SnackTime.Core.Process
{
    public interface IProcessManager
    {
        void StartProcess(string path, string[] args = null);
        bool IsProcessRunning(string path);
        void StopProcess(string path);
    }
}