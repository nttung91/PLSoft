using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using Windows.Core.BaseForms;

namespace Windows.Core.Helpers.XtraLayout
{
    public class XtraLayoutHandler : IXtraLayoutHandler
    {
        public List<FormsLayoutControlInfos> FormsLayoutControlInfos { get; set; }

        public XtraLayoutHandler(List<FormsLayoutControlInfos> formsLayoutControls)
        {
            FormsLayoutControlInfos = formsLayoutControls;
            SetDefaultLayout();
        }

        public void ApplyDefaultLayout()
        {
            foreach (FormsLayoutControlInfos info in FormsLayoutControlInfos)
                ApplyDefaultLayout(info.LayoutControl);
        }

        public void ApplySpecialLayout()
        {
            foreach (FormsLayoutControlInfos info in FormsLayoutControlInfos)
                ApplySpecialLayout(info.LayoutControl, info.Form, info.LayoutFileName);
        }

        public void ApplyLayout()
        {
            foreach (FormsLayoutControlInfos info in FormsLayoutControlInfos)
            {
                Debug.Assert(info.Form != null, "Form ist null");
                Debug.Assert(info.RegistryLayoutName != null, "RegistryLayoutName ist null");
                Debug.Assert(info.LayoutFileName != null, "LayoutFileName ist null");
                Debug.Assert(info.LayoutControl != null, "LayoutControl ist null");

                if (info.Form == null || info.RegistryLayoutName == null || info.LayoutFileName == null ||
                    info.LayoutControl == null) continue;
                var layout = info.Form as IFormLayout;
                if (layout != null)
                {
                    if (layout.SpecialLayout)
                    {
                        ApplySpecialLayout(info.LayoutControl, info.Form, info.LayoutFileName);
                    }
                    else
                    {
                        ApplyDefaultLayout(info.LayoutControl);
                    }
                }
            }
        }

        public void SetDefaultLayout()
        {
            foreach (FormsLayoutControlInfos info in FormsLayoutControlInfos)
            {
                info.LayoutControl.SetDefaultLayout();
            }
        }

        private void ApplyDefaultLayout(LayoutControl layoutControl)
        {
            layoutControl.RestoreDefaultLayout();
        }

        private void ApplySpecialLayout(LayoutControl layoutControl, Form form, string layoutFileName)
        {
            Type type = form.GetType();
            string nameSpace = type.Namespace;
            using (Stream s = Assembly.GetAssembly(type).GetManifestResourceStream(nameSpace + "." + layoutFileName))
            {
                Debug.Assert(s != null, "RessourceStream not found");
                if (s != null)
                {
                    var reader = new StreamReader(s);
                    layoutControl.RestoreLayoutFromStream(reader.BaseStream);
                }
            }
        }
    }
}