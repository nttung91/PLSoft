using System;
using System.Windows.Forms;

namespace Windows.Core.Binding
{
    public interface IObjectBindingManager
    {
        /// <summary>
        /// Binds a BindingSource to an business object
        /// </summary>
        /// <param name="businessObject">The editable business object</param>
        /// <param name="bindingSource">BindingSource to bind</param>
        void BindBO(object businessObject, BindingSource bindingSource);

        /// <summary>
        /// Unbinds a BindingSource from the business object
        /// </summary>
        /// <param name="bindingSource">BindingSource to unbind</param>
        /// <param name="apply">true, apply all changes to the datasource</param>
        /// <param name="isRoot">true, BindingSource is root business object.</param>
        void UnbindBO(BindingSource bindingSource, bool apply, bool isRoot);

        /// <summary>
        /// Saves an editable business object
        /// </summary>
        /// <param name="rootBusinessObject">The editable business object</param>
        /// <param name="rootBindingSource">BindingSource to rebind</param>
        /// <param name="rebind">true, rebinds the saved business object. If the from will be closed
        /// after the save operation use false here.</param>
        void SaveBO(Object rootBusinessObject, BindingSource rootBindingSource, bool rebind);

        /// <summary>
        /// Saves an editable business object
        /// </summary>
        /// <param name="rootBusinessObject">The editable business object</param>
        /// <param name="rootBindingSource">BindingSource to rebind</param>
        /// <param name="childBindingSources"></param>
        /// <param name="rebind">true, rebinds the saved business object. If the from will be closed
        /// after the save operation use false here.</param>
        void SaveBO(Object rootBusinessObject, BindingSource rootBindingSource, BindingSource[] childBindingSources,
            bool rebind);

        void SaveBO(Object rootBusinessObject, BindingSourceNode bindingSourceRootNode, bool rebind);

        /// <summary>
        /// Restores/Connects the root BindingSource to the underlying datasource
        /// </summary>
        /// <param name="rootBindingSource">Bindingsource for root business object</param>
        /// <param name="forceUpdate">Causes the controls to reread all datasource values</param>        
        void RestoreBindings(BindingSource rootBindingSource, bool forceUpdate);

        /// <summary>
        /// Restores/Connects the root- and child BindingSources to the underlying datasource, for N-Level Parent-Child's use the RestoreBindings(BindingSourceNode ...
        /// </summary>
        /// <param name="rootBindingSource">Bindingsource for root business object</param>
        /// <param name="childBindingSources">Child BindingSources</param>
        /// <param name="forceUpdate">Causes the controls to reread all datasource values</param>
        void RestoreBindings(BindingSource rootBindingSource, BindingSource[] childBindingSources, bool forceUpdate);

        /// <summary>
        /// Restores/Connects the root- and child BindingSources to the underlying datasource, the Parent-Childs are in a tree of BindingSourceNode
        /// </summary>
        /// <param name="bindingSourceRootNode"></param>
        /// <param name="forceUpdate"></param>
        void RestoreBindings(BindingSourceNode bindingSourceRootNode, bool forceUpdate);

        /// <summary>
        /// Clears/Disconnects the root BindingSource from the underlying datasource
        /// </summary>
        /// <param name="rootBindingSource">BindingSource for root business object</param>
        /// <param name="apply">Apply all changes to the datasource</param>
        void ClearBindings(BindingSource rootBindingSource, bool apply);

        /// <summary>
        /// Clears/Disconnects the root- and child BindingSources from the underlying datasource, for N-Level Parent-Child's use the RestoreBindings(BindingSourceNode ...
        /// </summary>
        /// <param name="rootBindingSource">Bindingsource for root business object</param>
        /// <param name="childBindingSources">Child BindingSources</param>
        /// <param name="apply">Apply all changes to the datasource</param>
        void ClearBindings(BindingSource rootBindingSource, BindingSource[] childBindingSources, bool apply);

        /// <summary>
        /// Clears/Disconnects the root- and child BindingSources from the underlying datasource, the Parent-Childs are in a tree of BindingSourceNode
        /// </summary>
        /// <param name="bindingSourceRootNode"></param>
        /// <param name="apply"></param>
        void ClearBindings(BindingSourceNode bindingSourceRootNode, bool apply);

        /// <summary>
        /// Calls EndEdit on the BindingSource
        /// </summary>
        /// <param name="rootBindingSource"></param>
        void EndEditBinding(BindingSource rootBindingSource);

        /// <summary>
        /// Calls EndEdit on the focused control
        /// </summary>
        bool EndEditFocusedControl();
    }
}