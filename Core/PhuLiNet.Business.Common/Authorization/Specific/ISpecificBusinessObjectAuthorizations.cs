using System.Collections.Generic;
using PhuLiNet.Business.Common.Authorization.State;

namespace PhuLiNet.Business.Common.Authorization.Specific
{
    public interface ISpecificBusinessObjectAuthorizations
    {
        Dictionary<EAuthorizationType, IStateAuthorization> Authorizations { get; }
    }
}