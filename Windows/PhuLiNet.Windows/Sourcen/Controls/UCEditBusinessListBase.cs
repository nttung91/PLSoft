using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Csla.Core;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using PhuLiNet.Business.Common.CslaBase;
using PhuLiNet.Business.Common.Rules;
using Windows.Core.Commands;
using Windows.Core.Controls.Adapters;
using Windows.Core.Helpers;
using Windows.Core.Instructions;

namespace Windows.Core.Controls
{
    /// <summary>
    /// A base control for an editable business list.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class UCEditBusinessListBase : UCGridBase
        // ReSharper restore InconsistentNaming
    {
        protected virtual object BusinessObjectToBind { get; set; }

        /// <summary>
        /// Set the BusinessObjectToBind property based on the root form object before InitBusiness is called
        /// </summary>
        public virtual void SetBusinessObjectToBindFromRoot(IPhuLiBusinessBase root)
        {
            BusinessObjectToBind = root;
        }

        /// <summary>
        /// Set the BusinessObjectToBind property based on the root form object before InitBusiness is called
        /// </summary>
        public virtual void SetBusinessObjectToBindFromList(IExtendedBindingList list)
        {
            BusinessObjectToBind = list;
        }

        /// <summary>
        /// returns by default the BusinessObjectList. This will bind the root data source to the BusienssObject list.
        /// </summary>
        /// <returns></returns>
        protected override object GetRootToBind()
        {
            return BusinessObjectToBind;
        }

        protected override void InitControls()
        {
            if (!ListControl.NotAllowToAddOrDeleteRow)
            {
                ListControl.KeyDown += ListControl_KeyDown;
                ListControl.DeleteCurrentRow += (sender, args) => ExecuteDeleteInstruction();
            }
            ListControl.ElementUpdated += ListControl_ElementUpdated;

            base.InitControls();
        }

        public void GetScrollbarPosition(IDictionary<string, int> ucScrollbarPositions)
        {
            if (!ucScrollbarPositions.ContainsKey(Name))
            {
                ucScrollbarPositions.Add(Name, ListControl.GetScrollbarPosition());
            }
        }

        public void GetFocusedRow(IDictionary<string, object> ucFocusedRows)
        {
            if (!ucFocusedRows.ContainsKey(Name))
            {
                ucFocusedRows.Add(Name, ListControl.GetFocusedRow());
            }
        }

        public void SetScrollbarPositions(IDictionary<string, int> positions)
        {
            foreach (var position in positions.Where(position => position.Key == Name))
            {
                ListControl.RestoreScrollbarPosition(position.Value);
            }
        }

        public void RestoreFocusedRows(IDictionary<string, object> focusedRows)
        {
            foreach (var focusedRow in focusedRows.Where(p => p.Key == Name))
            {
                ListControl.RestoreFocusedRow(focusedRow.Value);
            }
        }

        public override void ClearBusiness()
        {
            _objectBindingManager.EndEditBinding(BindingSource.BindingSource);
            base.ClearBusiness();
        }

        private void ListControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyHelper.IsNewKey(e))
            {
                ApplyInstruction(InstructionFactory.NewInstruction());
                e.Handled = true;
            }
            else if (KeyHelper.IsDeleteKey(e))
            {
                ApplyInstruction(InstructionFactory.DeleteInstruction());
                e.Handled = true;
            }
        }

        protected virtual void ListControl_ElementUpdated(object sender, ElementUpdatedEventArgs args)
        {
            var validatableObject = args.Element as IValidateBusiness;
            if (validatableObject != null)
            {
                validatableObject.Validate();
            }
        }

        protected void GridPreventEditIfSaved(GridView gridView, CancelEventArgs e, params GridColumn[] columnsToLock)
        {
            if (!columnsToLock.Contains(gridView.FocusedColumn))
            {
                return;
            }

            var edit = gridView.GetRow(gridView.FocusedRowHandle) as IPhuLiBusinessBase;
            if (edit != null && !edit.IsNew)
            {
                e.Cancel = true;
            }
        }

        protected override sealed void ExecuteNewInstruction(IInstruction instruction)
        {
            if (!ListControl.Editable)
            {
                return;
            }
            ExecuteNewInstruction();
        }

        protected virtual void ExecuteNewInstruction()
        {
            ListControl.AddRow();
        }

        protected override sealed void ExecuteDeleteInstruction(IInstruction instruction)
        {
            if (!ListControl.Editable)
            {
                return;
            }
            ListControl.CancelEdit();
            ExecuteDeleteInstruction();
        }

        protected virtual bool ExecuteDeleteInstruction()
        {
            // Get selected rows
            var rows = ListControl.GetSelectedRows().ToList();
            if (rows.Count == 0)
            {
                return false;
            }

            return ListControl.AllowMultiSelection ? rows.All(ExecuteDeleteCommand) : ExecuteDeleteCommand(rows[0]);
        }

        private static bool ExecuteDeleteCommand(IPhuLiBusinessBase row)
        {
            var cmd = new DeleteChildBusinessObjectCommand(row);
            cmd.Execute();
            return cmd.WasDeleted;
        }
    }
}