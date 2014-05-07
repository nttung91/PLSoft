using System.ComponentModel;

namespace Technical.Utilities.Extensions
{
    /// <summary>
    /// 	Extension methods for IComponent data type.
    /// </summary>
    public static class ComponentExtensions
    {
        /// <summary>
        /// 	Returns <c>true</c> if target component is in design mode.
        /// 	Othervise returns <c>false</c>.
        /// </summary>
        /// <param name = "target">Target component. Can not be null.</param>
        /// <remarks>
        /// 	Contributed by tencokacistromy, http://www.codeplex.com/site/users/view/tencokacistromy
        /// </remarks>
        public static bool IsInDesignMode(this IComponent target)
        {
            var ret = false;
            var site = target.Site;
            if (false == ReferenceEquals(site, null))
                ret = site.DesignMode;

            return ret;
        }

        /// <summary>
        /// 	Returns <c>true</c> if target component is NOT in design mode.
        /// 	Othervise returns <c>false</c>.
        /// </summary>
        /// <param name = "target">Target component.</param>
        /// <remarks>
        /// 	Contributed by tencokacistromy, http://www.codeplex.com/site/users/view/tencokacistromy
        /// </remarks>
        public static bool IsInRuntimeMode(this IComponent target)
        {
            var ret = true;
            var site = target.Site;
            if (false == ReferenceEquals(site, null))
                ret = !site.DesignMode;

            return ret;
        }
    }
}