using System.Collections;
using System.Reflection;
using DevExpress.XtraEditors;

namespace Windows.Core.Helpers
{
    public static class MruHelper
    {
        public static void SaveMruList(ArrayList mruList, MRUEdit mruEdit, object objSettings)
        {
            if (mruEdit.Properties.Items.Count == 0 || objSettings == null) return;

            int cnt = 0;
            mruList.Clear();

            foreach (string mruItem in mruEdit.Properties.Items)
            {
                if (cnt++ < 20)
                {
                    mruList.Add(mruItem);
                }
            }

            MethodInfo miSave = objSettings.GetType().GetMethod("Save");
            if (miSave == null) return;

            miSave.Invoke(objSettings, null);
        }

        public static void SetMruList(ArrayList mruList, MRUEdit mruEdit)
        {
            if (mruList == null || mruList.Count == 0) return;

            for (int i = mruList.Count - 1; i >= 0; i--)
            {
                mruEdit.Properties.Items.Add(mruList[i]);
            }
        }
    }
}