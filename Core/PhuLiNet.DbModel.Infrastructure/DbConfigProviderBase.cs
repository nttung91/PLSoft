using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace Core.DbModel.Infrastructure
{
    public abstract class DbConfigProviderBase : IConfigurationProvider
    {
        private readonly Configuration _configuration;

        protected DbConfigProviderBase(string hibernateConfigResourceName) : this(new Configuration())
        {
            InitalizeConfiguration(_configuration, hibernateConfigResourceName);
        }
        
        protected DbConfigProviderBase(Configuration configuration)
        {
            _configuration = configuration;            
        }

        protected void InitalizeConfiguration(Configuration configuration, string hibernateConfigResourceName)
        {
            _configuration.Configure(GetType().Assembly, hibernateConfigResourceName);
            
            var mapper = new ModelMapper();
            AddModelMappings(mapper);
            _configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
        }

        protected abstract void AddModelMappings(ModelMapper mapper);

        public virtual Configuration Configuration
        {
            get { return _configuration; }
        }

        public virtual ISessionFactory BuildSessionFactory()
        {
            return _configuration.BuildSessionFactory();
        }
    }
}