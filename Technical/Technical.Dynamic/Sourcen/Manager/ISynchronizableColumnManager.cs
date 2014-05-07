using Techical.Dynamic.Property;

namespace Techical.Dynamic.Manager
{
    /// <summary>
    /// ColumnManager mit Rück-Synchronisierung der Eingaben für Edit-Modus
    /// </summary>
    public interface ISynchronizableColumnManager<T>
    {
        /// <summary>
        /// Gibt eine Default Datenzeile für neue Zeilen zurück
        /// </summary>
        /// <returns></returns>
        IDynamicPropertyList CreateDataDefault();

        /// <summary>
        /// Synchronisierung der kompletten Spalten der Zeile
        /// </summary>
        void Sync(T line);

        /// <summary>
        /// Synchronisierung einer dynamischen Spalte über Schlüssel
        /// </summary>
        /// <param name="line"></param>
        /// <param name="key"></param>
        void Sync(T line, string key);
    }
}