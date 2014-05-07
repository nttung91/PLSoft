using System.Data.SqlClient;

namespace Core.DbModel.Infrastructure
{
    /// <summary>
    /// This class has no functional usage. It uses a class from ODP.Net ensuring that the Oracle assembly is copy to all build output
    /// directories. Otherwise this exception is thrown during unit testing:
    /// 
    /// Test method "Some test method" threw exception: 
    /// NHibernate.HibernateException: Could not create the driver from NHibernate.Driver.OracleDataClientDriver. 
    /// ---> System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. 
    /// ---> System.NullReferenceException: Object reference not set to an instance of an object.
    /// </summary>
    internal abstract class OracleReferenceDummy
    {
        private OracleReferenceDummy()
        {
        }

        private void Dummy()
        {
            var cmd = new SqlCommand();
        }
    }
}