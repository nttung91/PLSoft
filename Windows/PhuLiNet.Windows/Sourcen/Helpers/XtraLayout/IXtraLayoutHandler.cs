using System.Collections.Generic;

namespace Windows.Core.Helpers.XtraLayout
{
    public interface IXtraLayoutHandler
    {
        List<FormsLayoutControlInfos> FormsLayoutControlInfos { get; set; }
        void ApplyDefaultLayout();
        void ApplySpecialLayout();
        void ApplyLayout();
        void SetDefaultLayout();
    }
}