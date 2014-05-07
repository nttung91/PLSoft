using System.Collections.Generic;
using System.Diagnostics;

namespace Windows.Core.Instructions.Manager
{
    /// <summary>
    /// Base class for all instruction managers
    /// </summary>
    internal abstract class BaseInstructionManager : IInstructionManager
    {
        public event OnApplyInstructionEventHandler OnApplyInstruction;
        public event OnActivateInstructionEventHandler OnActivateInstruction;
        public event OnDeactivateInstructionEventHandler OnDeactivateInstruction;

        protected Dictionary<string, IInstruction> _instructions;

        protected BaseInstructionManager()
        {
            _instructions = new Dictionary<string, IInstruction>();
        }

        #region IInstructionManager Members

        public void Add(IInstruction instruction)
        {
            Debug.Assert(instruction != null, "instruction is null");
            Debug.Assert(!_instructions.ContainsKey(instruction.Id), "instruction exists already");
            Debug.Assert(!_instructions.ContainsValue(instruction), "instruction exists already");

            if (!_instructions.ContainsKey(instruction.Id))
            {
                _instructions.Add(instruction.Id, instruction);
            }
        }

        public void Remove(IInstruction instruction)
        {
            Debug.Assert(instruction != null, "instruction is null");

            if (_instructions.ContainsKey(instruction.Id))
            {
                _instructions.Remove(instruction.Id);
            }
        }

        public IList<IInstruction> Instructions()
        {
            IList<IInstruction> instructionList = new List<IInstruction>();

            foreach (KeyValuePair<string, IInstruction> pair in _instructions)
            {
                instructionList.Add(pair.Value);
            }

            return instructionList;
        }

        public IList<IInstruction> ActiveInstructions()
        {
            IList<IInstruction> instructionList = new List<IInstruction>();

            foreach (KeyValuePair<string, IInstruction> pair in _instructions)
            {
                if (pair.Value.Active)
                {
                    instructionList.Add(pair.Value);
                }
            }

            return instructionList;
        }

        public void Activate(IInstruction instruction)
        {
            Debug.Assert(instruction != null, "instruction is null");
            Debug.Assert(_instructions.ContainsKey(instruction.Id), "instruction does not exist");

            if (_instructions.ContainsKey(instruction.Id))
            {
                ((BaseInstruction) _instructions[instruction.Id]).Active = true;
                InvokeActivateEvent(instruction);
            }
        }

        public void Deactivate(IInstruction instruction)
        {
            Debug.Assert(instruction != null, "instruction is null");
            Debug.Assert(_instructions.ContainsKey(instruction.Id), "instruction does not exist");

            if (_instructions.ContainsKey(instruction.Id))
            {
                ((BaseInstruction) _instructions[instruction.Id]).Active = false;
                InvokeDeactivateEvent(instruction);
            }
        }

        public bool Exists(IInstruction instruction)
        {
            Debug.Assert(instruction != null, "instruction is null");

            return _instructions.ContainsKey(instruction.Id);
        }

        public bool ExistsAndActive(IInstruction instruction)
        {
            Debug.Assert(instruction != null, "instruction is null");

            return (_instructions.ContainsKey(instruction.Id) && _instructions[instruction.Id].Active);
        }

        public bool IsActive(IInstruction instruction)
        {
            Debug.Assert(instruction != null, "instruction is null");
            Debug.Assert(_instructions.ContainsKey(instruction.Id), "instruction does not exist");

            return (_instructions[instruction.Id].Active);
        }

        public virtual void Apply(IInstruction instruction)
        {
            Debug.Assert(instruction != null, "instruction is null");
            Debug.Assert(_instructions.ContainsKey(instruction.Id), "instruction does not exist");
            Debug.Assert(_instructions[instruction.Id].Active, "instruction is not active");

            if (_instructions.ContainsKey(instruction.Id) && _instructions[instruction.Id].Active)
            {
                InvokeApplyEvent(instruction);
            }
        }

        #endregion

        // Invoke the apply instruction event
        protected virtual void InvokeApplyEvent(IInstruction instruction)
        {
            //send event to owner
            if (OnApplyInstruction != null)
                OnApplyInstruction(this, new ApplyInstructionEventArgs(instruction));
        }

        // Invoke the activate instruction event
        protected virtual void InvokeActivateEvent(IInstruction instruction)
        {
            //send event to owner
            if (OnActivateInstruction != null)
                OnActivateInstruction(this, new InstructionEventArgs(instruction));
        }

        // Invoke the deactivate instruction event
        protected virtual void InvokeDeactivateEvent(IInstruction instruction)
        {
            //send event to owner
            if (OnDeactivateInstruction != null)
                OnDeactivateInstruction(this, new InstructionEventArgs(instruction));
        }
    }
}