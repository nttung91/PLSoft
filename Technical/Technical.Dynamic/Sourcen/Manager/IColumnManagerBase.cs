using Techical.Dynamic.Property;

namespace Techical.Dynamic.Manager
{
    /// <summary>
    /// Basis Interface für alle ColumnManager. 
    /// Die ColumnManager erstellen und verwalten eine dynamische Liste von Spalten.
    /// </summary>
    public interface IColumnManagerBase
    {
        /// <summary>
        /// Erstellt den Spaltenkopf für die dynamischen Spalten
        /// </summary>
        /// <returns></returns>
        IDynamicPropertyList GetHeader();

        /// <summary>
        /// Erstellt die Datenzeilen für die Spalten
        /// </summary>
        void CreateData();

        /// <summary>
        /// Löscht den Spaltenkopf
        /// </summary>
        void ClearHeader();

        /// <summary>
        /// Löscht alle Datenzeilen
        /// </summary>
        void ClearData();

        /// <summary>
        /// Löscht alle Daten, d.h. Kopf und Datenzeilen
        /// </summary>
        void ClearComplete();

        /// <summary>
        /// Ist der ColumnManager OK und alle Daten geladen?
        /// </summary>
        bool DataOk { get; }

        /// <summary>
        /// Ist der Schlüssel ein Column-Schlüssel der dynamischen Spalten?
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsColumnKey(string key);
    }
}