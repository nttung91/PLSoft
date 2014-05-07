namespace Windows.Core.Instructions.Manager
{
    /// <summary>
    /// Instruction event arguments
    /// </summary>
    public class InstructionEventArgs
    {
        private IInstruction _instruction;

        public IInstruction Instruction
        {
            get { return _instruction; }
        }

        public InstructionEventArgs(IInstruction instruction)
        {
            _instruction = instruction;
        }
    }
}