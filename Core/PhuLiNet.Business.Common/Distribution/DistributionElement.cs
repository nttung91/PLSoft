namespace PhuLiNet.Business.Common.Distribution
{
    public class DistributionElement<T>
    {
        public T ElementId { get; set; }
        public decimal DistributionFactor { get; set; }
        public decimal DistributedQuantity { get; set; }

        public DistributionElement(T elementId)
        {
            ElementId = elementId;
            DistributionFactor = 1.0M;
        }

        public DistributionElement(T elementId, decimal distributionFactor)
        {
            ElementId = elementId;
            DistributionFactor = distributionFactor;
        }
    }
}