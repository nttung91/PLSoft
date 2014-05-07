using System.Windows.Forms;
using PhuLiNet.Business.Common.Interfaces;

namespace Windows.Core.Filter
{
    public interface IFrmFilterEnabled
    {
        IFilterSelection Selection { get; set; }
        void LoadBusiness();
        DialogResult ShowDialog();
        void Dispose();
        void Show();
    }
}