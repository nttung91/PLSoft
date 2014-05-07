using System;
using DbModel.Core;
using PhuLiNet.Business.Common.Authorization;
using PhuLiNet.Business.Common.CslaBase;

namespace PhuLiNet.Business.Common.Commands
{
    /// <summary>
    /// Don’t allow to delete if business object already saved
    /// </summary>
    [Serializable]
    public class BusinessObjectDeleteCheckCommand<T, TK> : CheckCommand<T, TK>
        where T : PhuLiBusinessBaseVersionable<T>
        where TK : IUnitOfWork
    {
        private readonly string _notAllowedReason;
        private Func<Boolean> _additionalCondition;

        public BusinessObjectDeleteCheckCommand(string notAllowedReason)
        {
            _notAllowedReason = notAllowedReason;
        }

        protected override CheckCommandResult ExecuteBusinessCheck()
        {
            return ExecuteCheck();
        }

        protected CheckCommandResult ExecuteBusinessCheck(Func<Boolean> additionalCondition)
        {
            _additionalCondition = additionalCondition;
            return ExecuteCheck();
        }

        private CheckCommandResult ExecuteCheck()
        {
            if (BusinessObject != null && !BusinessObject.IsNew)
            {
                if (_additionalCondition == null || _additionalCondition())
                {
                    return new CheckCommandResult(false, _notAllowedReason);
                }
            }
            return base.ExecuteBusinessCheck();
        }
    }
}