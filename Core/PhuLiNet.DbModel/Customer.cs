using DbModel.Core;

namespace PhuLiNet.DbModels
{
    public class Customer : EntityWithTypedId<int>
    {
        public override int Id { get { return ArtCusId; } }
        [DomainSignature]
        public virtual int ArtCusId { get; set; }
        public virtual string CusId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Descr { get; set; }
    }
}
