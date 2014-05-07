namespace Techical.Dynamic.Property.Grouping
{
    public class GroupCriteria : IGroupCriteria
    {
        public string Key { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public GroupCriteria()
        {
        }

        public GroupCriteria(string key, string displayName, string description)
        {
            Key = key;
            DisplayName = displayName;
            Description = description;
        }
    }
}