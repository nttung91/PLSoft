using Windows.Core.Instructions.Manager;

namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Defines possible instructions on the form (New, Edit, Delete)
    /// </summary>
    public interface IFormInstructions
    {
        IInstructionManager InstructionManager { get; }
    }
}