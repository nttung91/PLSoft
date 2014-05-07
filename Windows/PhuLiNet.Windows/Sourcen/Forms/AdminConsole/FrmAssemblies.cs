using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using Technical.Reflection;
using Windows.Core.BaseForms;

namespace Windows.Core.Forms.AdminConsole
{
    internal partial class FrmAssemblies : FrmReadOnlyBase, ILoadableForm
    {
        private IList<AssemblyInformation> _assemblyInfoList;

        public FrmAssemblies()
        {
            InitializeComponent();
        }

        protected override void InitBindings()
        {
            _objectBindingManager.BindBO(_assemblyInfoList, assemblyBindingSource);
        }

        protected override void InitBusinessData()
        {
            _assemblyInfoList = new List<AssemblyInformation>();

            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                bool dynamicAssembly;
                try
                {
                    string codeBase = a.CodeBase;
                    dynamicAssembly = false;
                }
                catch (NotSupportedException)
                {
                    dynamicAssembly = true;
                }

                if (!dynamicAssembly)
                {
                    var assemblyInformation = new AssemblyInformation();
                    assemblyInformation.FullName = a.FullName;
                    assemblyInformation.Location = a.Location;
                    assemblyInformation.GlobalAssemblyCache = a.GlobalAssemblyCache;
                    if (!string.IsNullOrEmpty(a.Location))
                    {
                        assemblyInformation.FileVersion = FileVersionInfo.GetVersionInfo(a.Location).FileVersion;
                    }
                    assemblyInformation.AssemblyVersion = a.GetName().Version.ToString();
                    assemblyInformation.BuildType = BuildTypeFinder.GetBuildType(a);

                    if (!string.IsNullOrEmpty(assemblyInformation.Location))
                    {
                        var fi = new FileInfo(assemblyInformation.Location);
                        if (fi.Exists)
                        {
                            assemblyInformation.FileDate = fi.LastWriteTime.ToString(CultureInfo.InvariantCulture);
                        }
                    }

                    _assemblyInfoList.Add(assemblyInformation);
                }
            }
        }

        #region ILoadableForm Members

        public void LoadBusiness()
        {
            InitBusinessData();
            InitBindings();
        }

        #endregion
    }
}