using System.Diagnostics;

namespace Windows.Core.Instructions.Manager
{
    /// <summary>
    /// An instruction manager with no instructions and no instruction can be applied.
    /// </summary>
    internal class NoInstructionManager : BaseInstructionManager
    {
        internal NoInstructionManager() : base()
        {
        }

        public override void Apply(IInstruction instruction)
        {
            Debug.Assert(false, "NoInstructionManager cannot apply any instruction");
        }
    }
}