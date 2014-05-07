using System;
using NHibernate;

namespace DbModel.Core
{
    public class DbExceptionUtil
    {
        public static bool IsDbConcurrencyException(Exception catchedException)
        {
            return catchedException is StaleObjectStateException;
        }
    }
}