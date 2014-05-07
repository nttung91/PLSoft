namespace Techical.Dynamic.Property.Filtering
{
    public class FilterCriteria : IFilterCriteria
    {
        public string FilterString { get; set; }

        public FilterCriteria(string filterString)
        {
            FilterString = filterString;
        }
    }
}