namespace Windows.Core.Reporting
{
    public interface IPrepareReport
    {
        void GetAndBindData();
        void SetPrintingDefaults();
    }
}