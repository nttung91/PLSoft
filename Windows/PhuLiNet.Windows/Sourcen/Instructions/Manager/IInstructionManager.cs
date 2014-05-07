using System.Collections.Generic;

namespace Windows.Core.Instructions.Manager
{
    /// <summary>
    /// Base interface for an instruction manager
    /// </summary>
    public interface IInstructionManager
    {
        event OnApplyInstructionEventHandler OnApplyInstruction;
        event OnActivateInstructionEventHandler OnActivateInstruction;
        event OnDeactivateInstructionEventHandler OnDeactivateInstruction;

        /// <summary>
        /// Add instruction
        /// </summary>
        /// <param name="instruction"></param>
        void Add(IInstruction instruction);

        /// <summary>
        /// Remove instruction
        /// </summary>
        /// <param name="instruction"></param>
        void Remove(IInstruction instruction);

        /// <summary>
        /// Returns all instructions
        /// </summary>
        /// <returns></returns>
        IList<IInstruction> Instructions();

        /// <summary>
        /// Returns all active instructions
        /// </summary>
        /// <returns></returns>
        IList<IInstruction> ActiveInstructions();

        /// <summary>
        /// Activates an instruction
        /// </summary>
        /// <param name="instruction"></param>
        void Activate(IInstruction instruction);

        /// <summary>
        /// Deactivates an instruction
        /// </summary>
        /// <param name="instruction"></param>
        void Deactivate(IInstruction instruction);

        /// <summary>
        /// Is the instruction existent?
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns></returns>
        bool Exists(IInstruction instruction);

        /// <summary>
        /// Is the instruction existent and active?
        /// </summary>
        /// <returns></returns>
        bool ExistsAndActive(IInstruction instruction);

        /// <summary>
        /// Is the instruction active?
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns></returns>
        bool IsActive(IInstruction instruction);

        /// <summary>
        /// Applies (executes) the instruction
        /// </summary>
        /// <param name="instruction"></param>
        void Apply(IInstruction instruction);
    }
}