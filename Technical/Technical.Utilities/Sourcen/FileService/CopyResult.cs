namespace Technical.Utilities.FileService
{
    public class CopyResult
    {
        public string Message { get; set; }
        public bool HasError { get; set; }

        public CopyResult()
        {
            HasError = false;
            Message = "Files erfolgreich kopiert";
        }
    }
}