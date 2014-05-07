namespace Windows.Core.Helpers.GridLayout
{
    /// <summary>
    /// Basis Interface für die Verwaltung (Laden, Speichern, ...) von GridLayouts
    /// </summary>
    public interface IGridLayoutManager
    {
        string LayoutName { get; set; }
        void SaveLayout();
        void RestoreLayout();
        void ResetLayout();
        bool HasLayout(string layoutName);
    }
}