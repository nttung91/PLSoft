using System;
using Csla.Rules;
using Technical.Utilities.Extensions;

namespace PhuLiNet.Business.Common.Authorization.Rules
{
    public static class AuthorizationRulesHelper
    {
        private static string GetProgramId(Type type)
        {
            var programIdAttribute = type.GetAttribute<AuthorizationProgramIdAttribute>(false);
            if (programIdAttribute != null)
            {
                return programIdAttribute.ProgramId;
            }
            return null;
        }

        public static void AddRulesForType<T>()
        {
            string programId = GetProgramId(typeof (T));
            if (!string.IsNullOrEmpty(programId))
            {
                BusinessRules.AddRule(typeof (T), new CanRead(AuthorizationActions.GetObject, programId));
                BusinessRules.AddRule(typeof (T), new CanWrite(AuthorizationActions.CreateObject, programId));
                BusinessRules.AddRule(typeof (T), new CanWrite(AuthorizationActions.EditObject, programId));
                BusinessRules.AddRule(typeof (T), new CanDelete(AuthorizationActions.DeleteObject, programId));
            }
        }
    }
}