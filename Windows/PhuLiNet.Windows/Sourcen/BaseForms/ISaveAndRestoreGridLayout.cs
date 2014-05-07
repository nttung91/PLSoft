namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies that the form can restore and save it's grid layout
    /// </summary>
    public interface ISaveAndRestoreGridLayout
    {
        void RestoreGridLayout(string layoutName);
        void SaveGridLayout(string layoutName);
    }
}