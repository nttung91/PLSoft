namespace Windows.Core.Instructions
{
    public static class InstructionFactory
    {
        public static IInstruction NewInstruction()
        {
            return new NewInstruction("NEW", "Neu");
        }

        public static IInstruction EditInstruction()
        {
            return new EditInstruction("EDIT", "Bearbeiten");
        }

        public static IInstruction CopyInstruction()
        {
            return new CopyInstruction("COPY", "Kopieren");
        }

        public static IInstruction DeleteInstruction()
        {
            return new DeleteInstruction("DELETE", "Löschen");
        }

        public static IInstruction SearchInstruction()
        {
            return new SearchInstruction("SEARCH", "Suchen");
        }

        public static IInstruction TransmitInstruction()
        {
            return new TransmitInstruction("TRANSMIT", "Senden");
        }

        public static IInstruction CloseInstruction()
        {
            return new TransmitInstruction("CLOSE", "Schliessen");
        }
    }
}