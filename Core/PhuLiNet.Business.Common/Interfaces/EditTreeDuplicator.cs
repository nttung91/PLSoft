using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Csla;
using Csla.Core;
using Csla.Reflection;
using Technical.Utilities.Exceptions;
using MethodInfo = System.Reflection.MethodInfo;

namespace PhuLiNet.Business.Common.Interfaces
{
    public class EditTreeDuplicator<T> where T : BusinessBase<T>
    {
        private readonly T _parentBusinessObject;

        public EditTreeDuplicator(T parentBusinessObject)
        {
            _parentBusinessObject = parentBusinessObject;
        }

        public T Duplicate()
        {
            T businessObjectClone = _parentBusinessObject.Clone();

            MarkAsNew(businessObjectClone);

            return businessObjectClone;
        }

        private MethodInfo TryLocateGetChildrenMethod()
        {
            const string cslaManageInterfaceName = "Csla.Core.IManageProperties";
            const string getChildrenMethodName = "GetChildren";

            Type editObjectType = typeof (BusinessBase);
            Type managePropertiesInterface = editObjectType.GetInterface(cslaManageInterfaceName);

            if (managePropertiesInterface == null) throw new PhuLiException(cslaManageInterfaceName + " not found");

            InterfaceMapping mapping = editObjectType.GetInterfaceMap(managePropertiesInterface);
            return mapping.InterfaceMethods.FirstOrDefault(m => m.Name == getChildrenMethodName);
        }

        private void MarkAsNew(object obj)
        {
            // is this a single editable object 
            if (obj is BusinessBase)
            {
                MethodCaller.CallMethodIfImplemented(obj, "MarkNew", null);

                var markableAsDuplicate = obj as IMarkableAsDuplicate;
                if (markableAsDuplicate != null)
                {
                    markableAsDuplicate.MarkAsDuplicate();
                    var versionable = obj as IVersionableBusiness;
                    if (versionable != null)
                    {
                        versionable.Version = 0;
                    }
                }
                else
                {
                    throw new PhuLiException("Duplicate not possible. Please implement IMarkableAsDuplicate on " +
                                             obj.GetType().FullName);
                }

                // get managed child properties
                MethodInfo getChildrenMethod = TryLocateGetChildrenMethod();
                if (getChildrenMethod != null)
                {
                    var children = getChildrenMethod.Invoke(obj, null) as IEnumerable;
                    if (children != null)
                    {
                        foreach (var child in children)
                        {
                            MarkAsNew(child);
                        }
                    }
                }
                else
                {
                    throw new PhuLiException("Could not found GetChildren method");
                }
            }
                // or a list og EditableObject (both BindingList and ObservableCollection)
            else if (obj is IEditableCollection)
            {
                foreach (object child in (IEnumerable) obj)
                {
                    MarkAsNew(child);
                }
            }
        }
    }
}