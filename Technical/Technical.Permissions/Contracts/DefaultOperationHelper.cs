using System;
using System.Collections.Generic;
using System.Linq;
using Technical.Utilities.Helpers;

namespace Technical.Permissions.Contracts
{
    public static class DefaultOperationHelper
    {
        public static readonly List<string> DefaultOperationIds =
            Enum.GetValues(typeof (EDefaultOperation))
                .Cast<object>()
                .Select(p => EnumHelper.GetEnumDescription((EDefaultOperation) p))
                .ToList();

        public static bool IsDefaultOperation(string operationId)
        {
            return DefaultOperationIds.Contains(operationId);
        }
    }
}