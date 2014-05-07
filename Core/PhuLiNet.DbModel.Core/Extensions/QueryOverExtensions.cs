using System;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Criterion;

namespace DbModel.Core.Extensions
{
    public static class QueryOverExtensions
    {
        /// <summary>
        /// Restriction for string properties: <c>TRIM(value) IS NOT NULL</c>
        /// </summary>
        /// <example>
        /// <code>
        /// return TheUnitOfWork.Session.QueryOver&lt;Program&gt;()
        ///     .WhereStringIsNotNullOrEmpty(p => p.Shortcut)
        ///     .List();
        /// </code>
        /// </example>
        public static IQueryOver<TE, TF> WhereStringIsNotNullOrEmpty<TE, TF>(this IQueryOver<TE, TF> query,
            Expression<Func<TE, object>> propExpression)
        {
            return
                query.Where(
                    Restrictions.IsNotNull(
                        (Projections.SqlFunction("TRIM", NHibernateUtil.String, Projections.Property(propExpression)))));
        }
    }
}