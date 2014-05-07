using System;
using System.Diagnostics;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using PhuLiNet.Business.Common.Context.Base;
using Windows.Core.Binding;
using Windows.Core.Instructions.Manager;

namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Base form for readonly and preview screens, no save possible
    /// </summary>
    public partial class FrmReadOnlyBase : FrmBase, IFormInstructions
    {
        protected AbstractContext _businessContext;
        protected IObjectBindingManager _objectBindingManager;
        protected IInstructionManager _instructionManager;

        public FrmReadOnlyBase()
        {
            InitializeComponent();

            if (!IsDesignerHosted)
            {
                InitBindingManager();
                InitInstructionManager();
                RegisterInstructionManagerEvents();
            }
        }

        #region Instruction Manager Methods

        protected virtual void InitInstructionManager()
        {
            _instructionManager = InstructionManagerFactory.GetNoInstructionManager();
        }

        protected virtual void RegisterInstructionManagerEvents()
        {
            _instructionManager.OnApplyInstruction +=
                new OnApplyInstructionEventHandler(InstructionManager_OnApplyInstruction);
        }

        protected virtual void ClearInstructionManager()
        {
            if (_instructionManager != null)
            {
                _instructionManager.OnApplyInstruction -=
                    new OnApplyInstructionEventHandler(InstructionManager_OnApplyInstruction);
                _instructionManager = null;
            }
        }

        protected virtual void InstructionManager_OnApplyInstruction(IInstructionManager sender,
            ApplyInstructionEventArgs e)
        {
            Debug.Assert(false, "Override InstructionManager_OnApplyInstruction is missing");
        }

        #endregion

        #region IFormInstructions Members

        public IInstructionManager InstructionManager
        {
            get { return _instructionManager; }
        }

        #endregion

        #region Binding Methods

        protected virtual void InitBindingManager()
        {
            _objectBindingManager = ObjectBindingManagerReadOnly.GetBindingManager();
        }

        /// <summary>
        /// Init all BindingSources here
        /// </summary>
        protected override void InitBindings()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Init complex Binding tree here
        /// </summary>
        protected override void InitBindingTree()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load and init all business data here
        /// </summary>
        protected override void InitBusinessData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clear all Bindings here
        /// </summary>
        protected override void ClearBindings()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Init all Controls here
        /// </summary>
        protected override void InitControls()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void FrmCsla_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearInstructionManager();
        }
    }
}