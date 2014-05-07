using Windows.Core.SmartPart.Manager;

namespace Windows.Core.SmartPart.Workspace
{
    public interface IWorkspace
    {
        ISmartPartManager SmartPartManager { get; set; }

        ISmartPart CurrentSmartPart { get; }
        bool InitWorkspaceDone { get; }
        void InitWorkspace();
        void DeinitWorkspace();
        void DestroyWorkspace();
        void ShowSmartPart(string key);
    }
}