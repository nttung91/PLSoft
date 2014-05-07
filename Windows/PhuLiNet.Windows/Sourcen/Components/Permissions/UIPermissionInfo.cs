namespace Windows.Core.Components.Permissions
{
    public class UIPermissionInfo
    {
        public string Permission { get; set; }
        public bool? Visible { get; set; }

        public UIPermissionInfo()
        {
            Permission = string.Empty;
            Visible = true;
        }
    }
}