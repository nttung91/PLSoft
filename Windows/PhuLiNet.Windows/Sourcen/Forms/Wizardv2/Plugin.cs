using System.Reflection;
using Technical.Utilities.Exceptions;

namespace Windows.Core.Forms.Wizardv2
{
    /// <summary>
    /// Manages the plugin.
    /// </summary>
    public class Plugin
    {
        protected string _assemblyPath;
        protected string _typeName;
        protected Assembly _assembly;
        protected IPlugin _instance;

        /// <summary>
        /// The assembly name that manages a frame of the wizard.
        /// This property is intended to be used during declarative instantiation.
        /// </summary>
        public string AssemblyPath
        {
            get { return _assemblyPath; }
            set { _assemblyPath = value; }
        }

        /// <summary>
        /// The type name [namespace].[class] of the type to be instantiated.
        /// This property is intended to be used during declarative instantiation.
        /// </summary>
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        /// <summary>
        /// Returns the plugin instance as an interface.
        /// </summary>
        public IPlugin Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Constructor.  The default constructor is intended to be
        /// used for declarative instantiation.
        /// </summary>
        public Plugin()
        {
        }

        /// <summary>
        /// Constructor for imperative instantiation.
        /// </summary>
        /// <param name="assemblyPath">The full assembly path.</param>
        /// <param name="typeName">The [namespace].[class] type name to instantiate.</param>
        public Plugin(string assemblyPath, string typeName)
        {
            _assemblyPath = assemblyPath;
            _typeName = typeName;
        }

        /// <summary>
        /// Constructor for direct instantiation without assembly
        /// </summary>
        /// <param name="instance"></param>
        public Plugin(IPlugin instance)
        {
            _assemblyPath = null;
            _typeName = null;
            _assembly = null;
            _instance = instance;
        }

        /// <summary>
        /// Loads the assembly and creates the instance.
        /// </summary>
        public void LoadAndCreate()
        {
            if (_assemblyPath != null && _typeName != null)
            {
                _assembly = Assembly.LoadFile(_assemblyPath);
                _instance = (IPlugin) _assembly.CreateInstance(_typeName);

                if (_instance == null)
                {
                    throw new PhuLiException("Unable to create " + _typeName + " for " + _assemblyPath);
                }
            }
        }

        /// <summary>
        /// Returns the page that the plugin specifies as belonging in the wizard container.
        /// </summary>
        public FrmWizardPageBase GetPage()
        {
            return _instance.GetPage();
        }
    }
}