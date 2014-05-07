using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using Csla.Core;

namespace PhuLiNet.Business.Common.Rules
{
    public class EditTreeValidator
    {
        private readonly object _parentBusinessObject;

        public EditTreeValidator(BusinessBase parentBusinessObject)
        {
            _parentBusinessObject = parentBusinessObject;
        }

        public EditTreeValidator(IEditableCollection parentBusinessObjectList)
        {
            _parentBusinessObject = parentBusinessObjectList;
        }

        public void Validate()
        {
            ValidateRules(_parentBusinessObject);
        }

        private MethodInfo TryLocateGetChildrenMethod()
        {
            const string CSLA_MANAGE_INTERFACE = "Csla.Core.IManageProperties";
            const string GET_CHILDREN_METHOD = "GetChildren";

            MethodInfo getChildrenMethod = null;
            Type editObjectType = typeof (BusinessBase);
            Type managePropertiesInterface = editObjectType.GetInterface(CSLA_MANAGE_INTERFACE);

            Debug.Assert(managePropertiesInterface != null);

            if (managePropertiesInterface != null)
            {
                InterfaceMapping mapping = editObjectType.GetInterfaceMap(managePropertiesInterface);
                foreach (var m in mapping.InterfaceMethods)
                {
                    if (m.Name == GET_CHILDREN_METHOD)
                    {
                        getChildrenMethod = m;
                        break;
                    }
                }
            }

            return getChildrenMethod;
        }

        private void ValidateRules(object obj)
        {
            // is this a single editable object 
            if (obj is BusinessBase)
            {
                var checkRules = obj as ICheckRules;
                if (checkRules != null)
                {
                    checkRules.CheckRules();
                }

                // get managed child properties
                MethodInfo getChildrenMethod = TryLocateGetChildrenMethod();
                if (getChildrenMethod != null)
                {
                    var children = getChildrenMethod.Invoke(obj, null) as IEnumerable;
                    foreach (var child in children)
                    {
                        ValidateRules(child);
                    }
                }
                else
                {
                    Debug.Assert(false, "Could not found GetChildren method");
                }
            }
                // or a list og EditableObject (both BindingList and ObservableCollection)
            else if (obj is IEditableCollection)
            {
                foreach (object child in (IEnumerable) obj)
                {
                    ValidateRules(child);
                }
            }
        }
    }
}