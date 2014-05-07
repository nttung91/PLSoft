using System.Collections.Generic;
using System.Windows.Forms;

namespace Windows.Core.DxExtensions
{
    public static class ControlExtensions
    {
        public static IEnumerable<T> GetAllControls<T>(this Control container) where T : class
        {
            var controlList = new List<T>();
            foreach (Control c in container.Controls)
            {
                controlList.AddRange(GetAllControls<T>(c));
                if (c is T)
                    controlList.Add(c as T);
            }
            return controlList;
        }
    }
}