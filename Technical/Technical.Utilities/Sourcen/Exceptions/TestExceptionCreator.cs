namespace Technical.Utilities.Exceptions
{
    public class TestExceptionCreator
    {
        public static void Throw()
        {
            throw new TestException("Test exception handling and logging");
        }
    }
}