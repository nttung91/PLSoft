using PhuLiNet.Business.Common.CslaBase;

namespace PhuLiNet.Business.Common.Authorization
{
    public interface ICheckCommand<in T> where T : PhuLiBusinessBase<T>
    {
        CheckCommandResult ExecuteDatabaseCheckOnly(T businessObject);
        CheckCommandResult Execute(T businessObject);
    }
}