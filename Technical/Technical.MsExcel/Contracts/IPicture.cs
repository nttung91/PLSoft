using System.Drawing;
using Manor.MsExcel.Contracts;

namespace Techical.MsExcel.Contracts
{
    public interface IPicture : IDrawing
    {
        Image Image { get; }
    }
}