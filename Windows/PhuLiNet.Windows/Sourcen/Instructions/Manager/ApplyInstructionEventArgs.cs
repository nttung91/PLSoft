namespace Windows.Core.Instructions.Manager
{
    /// <summary>
    /// Apply instruction event arguments
    /// </summary>
    public class ApplyInstructionEventArgs
    {
        private IInstruction _instruction;

        public IInstruction Instruction
        {
            get { return _instruction; }
        }

        public ApplyInstructionEventArgs(IInstruction instruction)
        {
            _instruction = instruction;
        }
    }
}