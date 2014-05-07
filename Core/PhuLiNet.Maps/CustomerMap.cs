using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PhuLiNet.DbModels;

namespace PhuLiNet.Maps
{
    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            Table("CUSTOMERS");

            Id(x => x.ArtCusId, m =>
            {
                m.Column("ART_CUS_ID");
                m.Generator(Generators.Identity);
            });

            Property(x => x.CusId, m => { m.Column("CUS_ID"); m.NotNullable(true); });
            Property(x => x.Descr, m => { m.Column("DESCR"); m.NotNullable(true); });
            Property(x => x.Address, m => { m.Column("ADDRESS"); m.NotNullable(false); });
        }
    }
}
