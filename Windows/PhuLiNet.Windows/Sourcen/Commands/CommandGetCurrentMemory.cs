using System.Diagnostics;

namespace Windows.Core.Commands
{
    internal class CommandGetCurrentMemory : BaseCommand
    {
        public long MemoryUsedInBytes { get; set; }

        public long MemoryUsedInKilobyte
        {
            get { return MemoryUsedInBytes/1024; }
        }

        public CommandGetCurrentMemory()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            Process currentProc = Process.GetCurrentProcess();
            MemoryUsedInBytes = currentProc.PrivateMemorySize64;
        }

        #endregion
    }
}