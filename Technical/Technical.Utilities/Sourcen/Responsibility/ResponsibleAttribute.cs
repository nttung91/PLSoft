using System;

namespace Technical.Utilities.Responsibility
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ResponsibleAttribute : Attribute
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ECompany Company { get; set; }
        public EOperationalTeam OperationalTeam { get; set; }

        public ResponsibleAttribute(string firstName, string lastName, ECompany company,
            EOperationalTeam operationalTeam)
        {
            FirstName = firstName;
            LastName = lastName;
            Company = company;
            OperationalTeam = operationalTeam;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}, {3}", OperationalTeam, FirstName, LastName, Company);
        }
    }
}