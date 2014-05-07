using System;
using Csla;
using DbModel.Core;
using PhuLiNet.Business.Common.CslaBase;

namespace PhuLiNet.Business.Common.Authorization
{
    [Serializable]
    public class CheckCommand<T, TU> : CommandBase<CheckCommand<T, TU>>, ICheckCommand<T>
        where T : PhuLiBusinessBase<T>
        where TU : IUnitOfWork
    {
        public CheckCommandResult CheckResult { get; private set; }
        protected T BusinessObject;

        public CheckCommandResult Execute(T businessObject)
        {
            BusinessObject = businessObject;
            var checkSuccessBusiness = ExecuteBusinessCheck();
            if (!checkSuccessBusiness.Allowed)
            {
                return checkSuccessBusiness;
            }

            // For "new" objects, we dont need to check in the database
            if (businessObject.IsNew)
            {
                return true;
            }

            return DataPortal.Execute(this).CheckResult;
        }

        protected virtual CheckCommandResult ExecuteBusinessCheck()
        {
            return true;
        }

        protected virtual CheckCommandResult ExecuteDatabaseCheck(IUnitOfWork uow)
        {
            return true;
        }

        public CheckCommandResult ExecuteDatabaseCheckOnly(T businessObject)
        {
            BusinessObject = businessObject;
            using (var ctx = UnitOfWorkContextManager<TU>.Get())
            {
                var result = ExecuteDatabaseCheck(ctx.UnitOfWork);
                ctx.Complete();
                return result;
            }
        }

        protected override void DataPortal_Execute()
        {
            using (var ctx = UnitOfWorkContextManager<TU>.Get(true))
            {
                CheckResult = ExecuteDatabaseCheck(ctx.UnitOfWork);
                ctx.Complete();
            }
        }
    }
}