using System.Drawing;

namespace Techical.MsExcel.Contracts
{
    public interface IDrawings
    {
        /// <summary>
        /// Add picture
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="image"></param>
        IPicture AddPicture(string name, Image image);

        /// <summary>
        /// Get picture, chart or shape
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IDrawing GetDrawing(int index);

        /// <summary>
        /// Number of drawings
        /// </summary>
        int Count { get; }
    }
}