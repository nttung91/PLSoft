namespace PhuLiNet.Business.Common.Processing
{
    public interface IBusinessProcessLogger
    {
        void Log(string message);
        void Log(string message, int foreignKey, string foreignType);
    }
}