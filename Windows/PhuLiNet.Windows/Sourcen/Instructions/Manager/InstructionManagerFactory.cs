namespace Windows.Core.Instructions.Manager
{
    /// <summary>
    /// Creates all instruction managers
    /// </summary>
    public static class InstructionManagerFactory
    {
        public static IInstructionManager GetNoInstructionManager()
        {
            return new NoInstructionManager();
        }

        public static IInstructionManager GetDefaultInstructionManager()
        {
            return new DefaultInstructionManager();
        }
    }
}