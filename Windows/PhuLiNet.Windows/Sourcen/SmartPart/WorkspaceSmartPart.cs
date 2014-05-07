using Windows.Core.SmartPart.Workspace;

namespace Windows.Core.SmartPart
{
    public class WorkspaceSmartPart : AbstractSmartPart
    {
        public WorkspaceSmartPart(IWorkspace workspace)
            : base(workspace)
        {
        }

        public override void Init()
        {
            ((IWorkspace) _control).InitWorkspace();
            _initDone = true;
        }

        public override void Deinit()
        {
            ((IWorkspace) _control).DeinitWorkspace();
            _initDone = false;
        }

        public override void Destroy()
        {
            ((IWorkspace) _control).DestroyWorkspace();
        }
    }
}