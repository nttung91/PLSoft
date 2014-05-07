using System;
using System.Diagnostics;

namespace PhuLiNet.Business.Common.Languages
{
    [Serializable]
    public class Language : IComparable, IComparable<Language>, IEquatable<Language>
    {
// ReSharper disable InconsistentNaming
        public const string Lang_Id_English = "1";
        public const string Lang_Id_German = "2";
        public const string Lang_Id_French = "3";
        public const string Lang_Id_Italian = "4";
        public const string Lang_Id_Dutch = "5";
// ReSharper restore InconsistentNaming

        public string Name { get; set; }
        public string LangId { get; set; }
        public string WindowsCultureName { get; set; }
        public string HelpfileSuffix { get; set; }

        public Language LanguageObject
        {
            get { return this; }
        }

        public int DisplaySequence
        {
            get
            {
                switch (LangId)
                {
                    case Lang_Id_German:
                        return 1;
                    case Lang_Id_French:
                        return 2;
                    case Lang_Id_Italian:
                        return 3;
                    case Lang_Id_English:
                        return 4;
                    case Lang_Id_Dutch:
                        return 5;
                    default:
                        return 9;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public string IsoCode
        {
            get { return WindowsCultureName.Substring(0, 2); }
        }

        public Language(string name, string langId, string windowsCultureName)
            : this(name, langId, windowsCultureName, windowsCultureName.Substring(0, 1))
        {
        }

        public Language(string name, string langId, string windowsCultureName, string helpfileSuffix)
        {
            Name = name;
            LangId = langId;
            WindowsCultureName = windowsCultureName;
            HelpfileSuffix = helpfileSuffix;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is Language))
            {
                throw new ArgumentException("Argument must be correct type");
            }
            return CompareTo((Language) obj);
        }

        #endregion

        #region IComparable<Language> Members

        public int CompareTo(Language other)
        {
            return String.CompareOrdinal(ToString(), other.ToString());
        }

        #endregion

        #region IEquatable<Language> Members

        public override int GetHashCode()
        {
            Debug.Assert(LangId != null, "_langId != null");
            return LangId.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj is Language) && Equals((Language) obj);
        }

        public bool Equals(Language other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return (LangId == other.LangId);
        }

        #endregion
    }
}