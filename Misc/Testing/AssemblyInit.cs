using Manor.ConnectionStrings.Configurators;
using Manor.ConnectionStrings.DbTypes;
using Manor.DbModel.Infrastructure.Profiling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Manor
{
    [TestClass]
    public class AssemblyInit
    {
        [AssemblyInitialize]
        public static void Setup(TestContext testContext)
        {
            Profiler.Get().Initialize();

            var dbModeConfigurator = new DatabaseModeConfigurator(EDatabaseMode.Kopie);
            dbModeConfigurator.Configure();
        }
    }
}