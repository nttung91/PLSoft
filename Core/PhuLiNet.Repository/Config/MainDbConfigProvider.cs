using Core.DbModel.Infrastructure;
using NHibernate.Mapping.ByCode;
using PhuLiNet.Maps;

namespace PhuLiNet.Repository.Config
{
    public class MainDbConfigProvider : DbConfigProviderBase
    {
        public MainDbConfigProvider() : base("PhuLiNet.Repository.Config.hibernate.cfg.xml")
        {            
        }

        protected override void AddModelMappings(ModelMapper mapper)
        {
            mapper.AddMappings(typeof(CustomerMap).Assembly.GetTypes());
        }
    }
}
