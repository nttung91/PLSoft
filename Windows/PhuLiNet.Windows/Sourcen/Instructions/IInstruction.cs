namespace Windows.Core.Instructions
{
    public interface IInstruction
    {
        string Id { get; }

        string Name { get; }

        bool Active { get; }
    }
}