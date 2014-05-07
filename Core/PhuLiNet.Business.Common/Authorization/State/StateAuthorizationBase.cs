using System;

namespace PhuLiNet.Business.Common.Authorization.State
{
    /// <summary>
    /// Business object authorization via current object state
    /// New, Remove and Edit depend on object state (Not user rights)
    /// </summary>
    [Serializable]
    public abstract class StateAuthorizationBase : IStateAuthorization
    {
        public virtual void InitState()
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateState()
        {
            throw new NotImplementedException();
        }

        #region IBaseAuthorization Members

        public virtual bool AllowNew()
        {
            return false;
        }

        public virtual bool AllowRemove()
        {
            return false;
        }

        public virtual bool AllowEdit()
        {
            return false;
        }

        #endregion
    }
}