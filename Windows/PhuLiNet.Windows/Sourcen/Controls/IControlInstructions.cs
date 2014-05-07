using Windows.Core.Instructions;

namespace Windows.Core.Controls
{
    public interface IControlInstructions
    {
        void ApplyInstruction(IInstruction instruction);
    }
}