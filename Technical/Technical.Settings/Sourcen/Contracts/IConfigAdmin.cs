namespace Technical.Settings.Contracts
{
    /// <summary>
    /// Administration interface
    /// </summary>
    public interface IConfigAdmin
    {
        IConfigSection CreateSection(string sectionId, string description);
    }
}