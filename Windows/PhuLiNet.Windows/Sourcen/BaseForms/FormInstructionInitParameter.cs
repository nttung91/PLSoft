using Windows.Core.Instructions;

namespace Windows.Core.BaseForms
{
    public class FormInstructionInitParameter
    {
        public IInstruction Instruction { get; set; }

        public object EntityKey { get; set; }
    }
}