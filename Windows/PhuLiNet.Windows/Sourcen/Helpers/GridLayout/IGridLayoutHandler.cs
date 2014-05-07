namespace Windows.Core.Helpers.GridLayout
{
    /// <summary>
    /// Basis Interface für die Verwaltung von mehreren Layout Managern
    /// </summary>
    public interface IGridLayoutHandler
    {
        void AddLayoutManager(IGridLayoutManager manager);
        void SetLayoutName(string layoutName);
        void SaveLayouts();
        void RestoreLayouts();
        void ResetLayouts();
        void SaveLayout(string layoutName);
        void RestoreLayout(string layoutName);
    }
}