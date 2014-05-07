namespace Windows.Core.Messaging
{
    public interface IMessage
    {
        string Id { get; }
        string Name { get; }
        bool Active { get; }
    }
}