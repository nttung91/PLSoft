namespace Technical.Utilities.Converter
{
    public static class FlagConverter
    {
        public static bool ToBoolean(string flag)
        {
            bool valueBool = false;

            if (flag.ToUpper().Equals("J") || flag.ToUpper().Equals("Y") || flag.ToUpper().Equals("1"))
                valueBool = true;

            return valueBool;
        }

        public static bool ToBoolean(object flag)
        {
            if (flag != null)
            {
                return ToBoolean(flag.ToString());
            }
            else
            {
                return false;
            }
        }

        public static string ToFlag(bool flag, FlagType flagType)
        {
            string valueString = null;

            switch (flagType)
            {
                case FlagType.Number:
                    if (flag)
                        valueString = "1";
                    else
                        valueString = "0";
                    break;
                case FlagType.EnglishChar:
                    if (flag)
                        valueString = "Y";
                    else
                        valueString = "N";
                    break;
                case FlagType.GermanChar:
                    if (flag)
                        valueString = "J";
                    else
                        valueString = "N";
                    break;
                default:
                    break;
            }

            return valueString;
        }
    }
}