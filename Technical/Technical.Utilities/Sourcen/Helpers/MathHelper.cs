using System;

namespace Technical.Utilities.Helpers
{
    public static class MathHelper
    {
        public static int RoundToMagnitude(double d, int mag)
        {
            int result = Convert.ToInt32(d);

            double temp = result/mag;
            temp = Math.Round(temp, 0);

            result = Convert.ToInt32(temp);
            return result*mag;
        }
    }
}