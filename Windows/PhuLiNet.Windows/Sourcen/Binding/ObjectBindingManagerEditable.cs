using System.Diagnostics;
using System.Windows.Forms;
using Csla;
using Csla.Core;
using Technical.Utilities.Exceptions;

namespace Windows.Core.Binding
{
    public class ObjectBindingManagerEditable : ObjectBindingManagerBase
    {
        private ObjectBindingManagerEditable()
        {
        }

        public static IObjectBindingManager GetBindingManager()
        {
            return new ObjectBindingManagerEditable();
        }

        public override void SaveBO(object rootBusinessObject, BindingSource rootBindingSource, bool rebind)
        {
            SaveBO(rootBusinessObject, rootBindingSource, new BindingSource[0], rebind);
        }

        public override void SaveBO(object rootBusinessObject, BindingSource rootBindingSource,
            BindingSource[] childBindingSources, bool rebind)
        {
            Debug.Assert(rootBusinessObject != null, "rootBusinessObject is null");
            Debug.Assert(rootBindingSource != null, "rootBindingSource is null");

            // disable events and unbind the business object
            ClearBindings(rootBindingSource, childBindingSources, true);

            try
            {
                rootBusinessObject = ((ISavable) rootBusinessObject).Save();
            }
            catch (DataPortalException ex)
            {
                EvaluateDataPortalException(ex);
                throw;
            }
            finally
            {
                if (rebind)
                {
                    // rebind UI
                    BindBO(rootBusinessObject, rootBindingSource);

                    // restore events and refresh UI
                    RestoreBindings(rootBindingSource, childBindingSources, false);
                }
            }
        }

        /// <summary>
        /// Save N-Level Parent-Child Relations
        /// </summary>
        /// <param name="rootBusinessObject"></param>
        /// <param name="bindingSourceRootNode"></param>
        /// <param name="rebind"></param>
        public override void SaveBO(object rootBusinessObject, BindingSourceNode bindingSourceRootNode, bool rebind)
        {
            Debug.Assert(rootBusinessObject != null, "rootBusinessObject is null");
            Debug.Assert(bindingSourceRootNode != null, "bindingSourceNode is null");

            // disable events and unbind the business object
            ClearBindings(bindingSourceRootNode, true);

            try
            {
                rootBusinessObject = ((ISavable) rootBusinessObject).Save();
            }
            catch (DataPortalException ex)
            {
                EvaluateDataPortalException(ex);
                throw;
            }
            finally
            {
                if (rebind)
                {
                    // rebind UI
                    BindBO(rootBusinessObject, bindingSourceRootNode.BindingSource);

                    // restore events and refresh UI
                    RestoreBindings(bindingSourceRootNode, false);
                }
            }
        }

        private void EvaluateDataPortalException(DataPortalException dataPortalException)
        {
            if (IsDataPortalExceptionOfType<ConcurrencyException>(dataPortalException))
            {
                throw new ConcurrencyException("Concurrent access", dataPortalException);
            }
            if (IsDataPortalExceptionOfType<InvalidStateException>(dataPortalException))
            {
                throw new InvalidStateException("Invalid state", dataPortalException);
            }
            if (IsDataPortalExceptionOfType<NotAllowedException>(dataPortalException))
            {
                throw new NotAllowedException("Not allowed", dataPortalException);
            }
            if (IsDataPortalExceptionOfType<EntityNotFoundException>(dataPortalException))
            {
                throw new EntityNotFoundException("Not found", dataPortalException);
            }
        }

        private bool IsDataPortalExceptionOfType<T>(DataPortalException dataPortalException)
        {
            return dataPortalException.BusinessException is T ||
                   dataPortalException.Message.Contains(typeof (T).FullName);
        }
    }
}