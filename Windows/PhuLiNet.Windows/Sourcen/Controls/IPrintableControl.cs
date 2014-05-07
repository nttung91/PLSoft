namespace Windows.Core.Controls
{
    /// <summary>
    /// Specifies that the control can be printed
    /// </summary>
    public interface IPrintableControl
    {
        /// <summary>
        /// Prints the control data
        /// </summary>
        void Print();
    }
}