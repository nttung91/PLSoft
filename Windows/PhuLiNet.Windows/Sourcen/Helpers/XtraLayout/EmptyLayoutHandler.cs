using System;
using System.Collections.Generic;

namespace Windows.Core.Helpers.XtraLayout
{
    public class EmptyLayoutHandler : IXtraLayoutHandler
    {
        public static EmptyLayoutHandler GetEmptyLayoutHandler()
        {
            return new EmptyLayoutHandler();
        }

        #region IXtraLayoutHandler Members

        public List<FormsLayoutControlInfos> FormsLayoutControlInfos
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void ApplyDefaultLayout()
        {
        }

        public void ApplySpecialLayout()
        {
        }

        public void ApplyLayout()
        {
        }

        public void SetDefaultLayout()
        {
        }

        #endregion
    }
}