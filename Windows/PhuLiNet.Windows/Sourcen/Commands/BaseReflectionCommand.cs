using System;
using System.Diagnostics;
using System.Reflection;
using Technical.Reflection;
using Windows.Core.Forms;

namespace Windows.Core.Commands
{
    /// <summary>
    /// Base application command for calling a command that is not in the References of the project and need's to be called by reflection
    /// </summary>
    public abstract class BaseReflectionCommand : BaseCommand
    {
        protected string _assemblyName;
        protected string _completeTypeName;
        protected object[] _parameters;
        protected Type[] _parameterTypes;

        private object _applicationCommandInstance;

        protected BaseReflectionCommand(string assemblyName, string completeTypeName)
        {
            Debug.Assert(!string.IsNullOrEmpty(assemblyName), "AssemblyName fehlt");
            Debug.Assert(!string.IsNullOrEmpty(completeTypeName), "CompleteTypeName fehlt");

            _assemblyName = assemblyName;
            _completeTypeName = completeTypeName;
        }

        protected void SetParameters(params object[] parameters)
        {
            _parameters = new object[parameters.Length];

            int i = 0;

            foreach (object item in parameters)
            {
                _parameters[i++] = item;
            }
        }

        protected void SetParameterTypes(params Type[] parameterTypes)
        {
            _parameterTypes = new Type[parameterTypes.Length];

            int i = 0;

            foreach (Type item in parameterTypes)
            {
                _parameterTypes[i++] = item;
            }
        }

        protected T GetPropertyValue<T>(string propertyName)
        {
            T propertyValue = default(T);

            if (_applicationCommandInstance != null)
            {
                if (PropertyReflectionHelper.HasProperty(_applicationCommandInstance, propertyName))
                {
                    propertyValue = PropertyReflectionHelper.GetPropertyValue<T>(_applicationCommandInstance,
                        propertyName);
                }
                else
                {
                    string message = string.Format("Property {0} of command {1} in Assembly {2} not found", propertyName,
                        _completeTypeName, _assemblyName);
                }
            }

            return propertyValue;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            bool typeExists = false;
            bool constructorExists = false;

            if (_parameterTypes == null &&
                _parameters != null)
            {
                //try to get parameter types from values
                //this is not working with null values (use SetParameterTypes when you have errors)
                _parameterTypes = ActivatorHelper.GetParameterTypes(_parameters);
            }

            typeExists = ActivatorHelper.TypeExists(_assemblyName, _completeTypeName);

            if (!typeExists)
            {
                MessageBox.ShowError("Funktion nicht gefunden",
                    string.Format("Die Funktion [{0}, {1}] konnte nicht gefunden werden.", _assemblyName,
                        _completeTypeName), "Funktion ungültig");
            }

            if (typeExists && HasParameters)
            {
                constructorExists = EvaluateConstructorExists();

                if (!constructorExists)
                {
                    MessageBox.ShowError("Konstruktor nicht gefunden",
                        string.Format("Der Konstruktor für den Typ [{0}, {1}] konnte nicht gefunden werden.",
                            _assemblyName, _completeTypeName), "Konstruktor ungültig");
                }
            }

            if (typeExists)
            {
                _applicationCommandInstance = ActivatorHelper.CreateInstance(_assemblyName, _completeTypeName,
                    _parameters, _parameterTypes);

                if (_applicationCommandInstance != null && _applicationCommandInstance is IApplicationCommand)
                {
                    ((IApplicationCommand) _applicationCommandInstance).Execute();
                }
            }
        }

        #endregion

        private bool HasParameters
        {
            get { return _parameterTypes != null && _parameterTypes.Length > 0; }
        }

        private bool EvaluateConstructorExists()
        {
            bool constructorExists = false;

            constructorExists = ActivatorHelper.ConstructorExists(_assemblyName, _completeTypeName, _parameterTypes);

            return constructorExists;
        }
    }
}