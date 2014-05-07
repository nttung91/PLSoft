namespace Windows.Core.Forms.AdminConsole
{
    internal class AssemblyInformation
    {
        public string FullName { get; set; }
        public string Location { get; set; }
        public bool GlobalAssemblyCache { get; set; }
        public string FileVersion { get; set; }
        public string AssemblyVersion { get; set; }
        public string FileDate { get; set; }
        public string BuildType { get; set; }

        internal AssemblyInformation()
        {
        }
    }
}