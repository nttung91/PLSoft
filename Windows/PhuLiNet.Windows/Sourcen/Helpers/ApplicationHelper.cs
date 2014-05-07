using System;
using System.IO;
using System.Reflection;

namespace Windows.Core.Helpers
{
    public static class ApplicationHelper
    {
        private static string applicationName;
        private static Version applicationVersion;
        private static DateTime? applicationDate;

        public static string ApplicationName
        {
            get
            {
                if (applicationName == null)
                {
                    applicationName = AssemblyProduct;
                }
                return applicationName;
            }
            set { applicationName = value; }
        }

        public static Version ApplicationVersion
        {
            get
            {
                if (applicationVersion == null)
                {
                    applicationVersion = AssemblyVersion;
                }
                return applicationVersion;
            }
            set { applicationVersion = value; }
        }

        public static DateTime? ApplicationDate
        {
            get
            {
                if (applicationDate == null)
                {
                    applicationDate = AssemblyDate;
                }
                return applicationDate;
            }
            set { applicationDate = value; }
        }

        public static string ApplicationDateString
        {
            get
            {
                return (ApplicationDate.Value.ToShortDateString() + " " + ApplicationDate.Value.ToShortTimeString());
            }
        }

        public static string ApplicationCompany
        {
            get { return AssemblyCompany; }
        }

        public static string ApplicationCopyright
        {
            get { return AssemblyCopyright; }
        }

        private static Version AssemblyVersion
        {
            get { return Assembly.GetEntryAssembly().GetName().Version; }
        }

        private static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetEntryAssembly()
                    .GetCustomAttributes(typeof (AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        private static string AssemblyCopyright
        {
            get
            {
                object[] attributes =
                    Assembly.GetEntryAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
            }
        }

        private static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetEntryAssembly()
                    .GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute) attributes[0]).Company;
            }
        }

        private static DateTime AssemblyDate
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string fileName = assembly.Location;
                var fi = new FileInfo(fileName);
                return fi.LastWriteTime;
            }
        }
    }
}