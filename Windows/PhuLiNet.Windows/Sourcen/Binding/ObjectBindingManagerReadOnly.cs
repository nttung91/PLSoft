using System;
using System.Windows.Forms;

namespace Windows.Core.Binding
{
    public class ObjectBindingManagerReadOnly : ObjectBindingManagerBase
    {
        private ObjectBindingManagerReadOnly()
        {
        }

        public static IObjectBindingManager GetBindingManager()
        {
            return new ObjectBindingManagerReadOnly();
        }

        public override void SaveBO(object rootBusinessObject, BindingSource rootBindingSource, bool rebind)
        {
            throw new NotImplementedException("Not allowed in BindingManagerReadOnly");
        }

        public override void SaveBO(object rootBusinessObject, BindingSource rootBindingSource,
            BindingSource[] childBindingSources, bool rebind)
        {
            throw new NotImplementedException("Not allowed in BindingManagerReadOnly");
        }

        public override void SaveBO(object rootBusinessObject, BindingSourceNode bindingSourceRootNode, bool rebind)
        {
            throw new NotImplementedException("Not allowed in BindingManagerReadOnly");
        }
    }
}