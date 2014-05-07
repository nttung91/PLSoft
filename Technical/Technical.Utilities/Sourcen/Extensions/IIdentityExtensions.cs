using System;
using System.Security.Principal;

namespace Technical.Utilities.Extensions
{
    public static class IIdentityExtensions
    {
        public static string NameWithoutDomain(this IIdentity identity)
        {
            string nameWithoutDomain = null;

            string[] split = {@"\"};
            string[] nameDomain = identity.Name.Split(split, StringSplitOptions.None);
            if (nameDomain.Length > 1)
                nameWithoutDomain = nameDomain[1];
            else if (nameDomain.Length == 1)
                nameWithoutDomain = nameDomain[0];

            return nameWithoutDomain;
        }

        public static string NameWithoutDomainToUpper(this IIdentity identity)
        {
            return NameWithoutDomain(identity).ToUpperInvariant();
        }

        public static string NameWithoutDomainTruncated(this IIdentity identity, int maxLength)
        {
            return NameWithoutDomain(identity).PadRight(maxLength).Substring(0, maxLength).Trim();
        }
    }
}