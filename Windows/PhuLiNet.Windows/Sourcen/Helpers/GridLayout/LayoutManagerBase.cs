using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Technical.Settings;
using Technical.Settings.Contracts;
using Technical.Utilities.Extensions;

namespace Windows.Core.Helpers.GridLayout
{
    /// <summary>
    /// Basisklasse für alle GridLayoutManager
    /// </summary>
    public abstract class LayoutManagerBase : IGridLayoutManager
    {
        protected Form HostForm;
        protected string ViewNameInternal;
        protected string LayoutNameInternal;
        protected string LayoutTypeInternal;

        protected LayoutManagerBase()
        {
            LayoutNameInternal = DefaultLayouts.Standard;
        }

        #region IGridLayoutManager Members    

        public string LayoutName
        {
            get { return LayoutNameInternal; }
            set { LayoutNameInternal = value; }
        }

        public abstract void SaveLayout();
        public abstract void RestoreLayout();

        public virtual void SaveLayoutToDataStore(Stream layoutStream)
        {
            layoutStream.SeekToBegin();
            string layoutData = new StreamReader(layoutStream).ReadToEnd();

            IConfigProvider configProvider = Provider.Get();
            IConfigSection section = configProvider.LoadSingleSetting(GetLayoutSectionId(), GetLayoutId());
            section.GetSetting<string>(GetLayoutId(), null, true).Value = layoutData;
            configProvider.SaveSection(section);
        }

        public virtual Stream RestoreLayoutFromDataStore()
        {
            IConfigProvider configProvider = Provider.Get();
            IConfigSection section = configProvider.LoadSingleSetting(GetLayoutSectionId(), GetLayoutId());

            if (section.ContainsSetting(GetLayoutId()))
            {
                string layoutData = section.GetSetting<string>(GetLayoutId(), null).Value;
                if (!string.IsNullOrEmpty(layoutData))
                {
                    byte[] byteArray = Encoding.Unicode.GetBytes(layoutData);
                    var layoutStream = new MemoryStream(byteArray);
                    return layoutStream;
                }
            }
            return null;
        }

        public virtual void ResetLayout()
        {
            Debug.Assert(HostForm != null, "HostForm is null");
            Debug.Assert(LayoutNameInternal != null, "_layoutName is null");

            string sectionId = GetLayoutSectionId();
            string layoutId = GetLayoutId();

            IConfigProvider configProvider = Provider.Get();
            IConfigSection section = configProvider.LoadSingleSetting(sectionId, layoutId);

            if (section.ContainsSetting(layoutId))
            {
                section.GetSetting<string>(GetLayoutId(), null).Value = null;
                configProvider.SaveSection(section);
            }
        }

        public virtual bool HasLayout(string layoutName)
        {
            Debug.Assert(HostForm != null, "HostForm is null");
            Debug.Assert(LayoutNameInternal != null, "_layoutName is null");

            string sectionId = GetLayoutSectionId();
            string layoutId = GetLayoutId(layoutName);

            IConfigProvider configProvider = Provider.Get();
            IConfigSection section = configProvider.LoadSingleSetting(sectionId, layoutId);
            bool hasLayout = section.ContainsSetting(layoutId);

            return hasLayout;
        }

        #endregion

        protected string GetLayoutSectionId()
        {
            return LayoutTypeInternal + "Layouts";
        }

        protected string GetLayoutId(string layoutName)
        {
            Debug.Assert(LayoutTypeInternal != null, "layoutType is null");
            Debug.Assert(LayoutNameInternal != null, "layoutName is null");
            Debug.Assert(ViewNameInternal != null, "viewName is null");
            Debug.Assert(HostForm != null, "HostForm is null");

            string layoutId = string.Format("{0}-{1}-{2}", HostForm.GetType().FullName, ViewNameInternal, layoutName);
            return layoutId;
        }

        protected string GetLayoutId()
        {
            return GetLayoutId(LayoutNameInternal);
        }
    }
}