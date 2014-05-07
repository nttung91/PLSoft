using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Windows.Core.Helpers;

namespace Windows.Core.Binding
{
    public abstract class ObjectBindingManagerBase : IObjectBindingManager
    {
        #region IBindingManager Members

        public void BindBO(object businessObject, BindingSource bindingSource)
        {
            Debug.Assert(businessObject != null, "businessObject is null");
            bindingSource.DataSource = businessObject;
        }

        public void UnbindBO(BindingSource bindingSource, bool apply, bool isRoot)
        {
            Debug.Assert(bindingSource != null, "bindingSource is null");

            IEditableObject current;

            try
            {
                current = bindingSource.Current as IEditableObject;
            }
            catch (IndexOutOfRangeException)
            {
                current = null;
            }

            if (isRoot)
            {
                bindingSource.EndEdit();
                bindingSource.DataSource = null;
            }
            if (current != null)
                if (apply)
                    current.EndEdit();
                else
                    current.CancelEdit();
        }

        public abstract void SaveBO(object rootBusinessObject, BindingSource rootBindingSource, bool rebind);

        public abstract void SaveBO(object rootBusinessObject, BindingSource rootBindingSource,
            BindingSource[] childBindingSources, bool rebind);

        public abstract void SaveBO(object rootBusinessObject, BindingSourceNode bindingSourceNode, bool rebind);

        public void RestoreBindings(BindingSource rootBindingSource, bool forceUpdate)
        {
            RestoreBindings(rootBindingSource, new BindingSource[0], forceUpdate);
        }

        #region Mit BindingSource Nodes

        public void ClearBindings(BindingSourceNode bindingSourceRootNode, bool apply)
        {
            Debug.Assert(bindingSourceRootNode != null, "bindingSourceNode darf nicht null sein");
            Debug.Assert(bindingSourceRootNode.IsRoot, "bindingSourceNode muss IsRoot sein");

            NodeRaiseListChangedEvents(bindingSourceRootNode, false);
            NodeUnbind(bindingSourceRootNode, apply);
            NodeDataSource(bindingSourceRootNode);
        }

        public void RestoreBindings(BindingSourceNode bindingSourceRootNode, bool forceUpdate)
        {
            Debug.Assert(bindingSourceRootNode != null, "bindingSourceNode darf nicht null sein");
            Debug.Assert(bindingSourceRootNode.IsRoot, "bindingSourceNode muss IsRoot sein");

            NodeDataSource(bindingSourceRootNode);
            NodeRaiseListChangedEvents(bindingSourceRootNode, true);
            NodeResetBindings(bindingSourceRootNode, forceUpdate);
        }

        private void NodeRaiseListChangedEvents(BindingSourceNode bindingSourceNode, bool raise)
        {
            bindingSourceNode.BindingSource.RaiseListChangedEvents = raise;

            // Für alle Childs
            foreach (BindingSourceNode bindingSourceNodeChild in bindingSourceNode.BindingSourceChilds)
            {
                NodeRaiseListChangedEvents(bindingSourceNodeChild, raise);
            }
        }

        private void NodeResetBindings(BindingSourceNode bindingSourceNode, bool forceUpdate)
        {
            bindingSourceNode.BindingSource.ResetBindings(forceUpdate);

            // Für alle Childs
            foreach (BindingSourceNode bindingSourceNodeChild in bindingSourceNode.BindingSourceChilds)
            {
                NodeResetBindings(bindingSourceNodeChild, forceUpdate);
            }
        }

        private void NodeUnbind(BindingSourceNode bindingSourceNode, bool apply)
        {
            // unbind the UI, child binding sources first
            foreach (BindingSourceNode bindingSourceNodeChild in bindingSourceNode.BindingSourceChilds)
            {
                NodeUnbind(bindingSourceNodeChild, apply);
            }

            UnbindBO(bindingSourceNode.BindingSource, apply, bindingSourceNode.IsRoot);
        }

        private void NodeDataSource(BindingSourceNode bindingSourceNode)
        {
            foreach (BindingSourceNode bindingSourceNodeChild in bindingSourceNode.BindingSourceChilds)
            {
                NodeDataSource(bindingSourceNodeChild);
                bindingSourceNodeChild.BindingSource.DataSource = bindingSourceNode.BindingSource;
            }
        }

        #endregion

        public void RestoreBindings(BindingSource rootBindingSource, BindingSource[] childBindingSources,
            bool forceUpdate)
        {
            // set datasources
            foreach (BindingSource bs in childBindingSources)
            {
                bs.DataSource = rootBindingSource;
            }

            // restore events
            rootBindingSource.RaiseListChangedEvents = true;
            foreach (BindingSource bs in childBindingSources)
            {
                bs.RaiseListChangedEvents = true;
            }

            // refresh the UI
            rootBindingSource.ResetBindings(forceUpdate);
            foreach (BindingSource bs in childBindingSources)
            {
                bs.ResetBindings(forceUpdate);
            }
        }

        public void ClearBindings(BindingSource rootBindingSource, bool apply)
        {
            ClearBindings(rootBindingSource, new BindingSource[0], apply);
        }

        public void ClearBindings(BindingSource rootBindingSource, BindingSource[] childBindingSources, bool apply)
        {
            // disable events
            rootBindingSource.RaiseListChangedEvents = false;
            foreach (BindingSource bs in childBindingSources)
            {
                bs.RaiseListChangedEvents = false;
            }

            // unbind the UI, child binding sources first
            foreach (BindingSource bs in childBindingSources)
            {
                UnbindBO(bs, apply, false);
            }
            UnbindBO(rootBindingSource, apply, true);

            // reset datasources
            rootBindingSource.DataSource = null;
            foreach (BindingSource bs in childBindingSources)
            {
                bs.DataSource = rootBindingSource;
            }
        }

        public void EndEditBinding(BindingSource rootBindingSource)
        {
            Debug.Assert(rootBindingSource != null, "rootBindingSource is null");

            var current = rootBindingSource.Current as IEditableObject;

            rootBindingSource.EndEdit();

            if (current != null)
                current.EndEdit();
        }

        public bool EndEditFocusedControl()
        {
            bool result = true;
            Control focusedControl = FormsControlHelper.GetFocusedControl();

            if (focusedControl is TextBoxMaskBox)
            {
                var maskedEditor = focusedControl as TextBoxMaskBox;
                if (maskedEditor.OwnerEdit.DoValidate())
                {
                    result = EditorHelper.EndEdit(maskedEditor.OwnerEdit);
                }
            }
            else if (focusedControl is BaseEdit)
            {
                var editor = focusedControl as BaseEdit;
                if (editor.DoValidate())
                {
                    result = EditorHelper.EndEdit(editor);
                }
            }
            return result;
        }

        #endregion
    }
}