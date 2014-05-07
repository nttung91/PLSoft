using System.Security.Principal;

namespace Technical.Utilities.Security
{
    public class FakeIdentity : IIdentity
    {
        public string Name { get; private set; }
        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }

        public FakeIdentity(string name)
        {
            Name = name;
            IsAuthenticated = true;
            AuthenticationType = "Fake";
        }
    }
}