namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies that the forms root object can be viewed in object spy.
    /// </summary>
    public interface ISpyObject
    {
        object SpyObject();
    }
}