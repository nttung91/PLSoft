namespace Technical.Utilities.Extensions
{
    /// <summary>
    /// 	Extension methods for byte-Arrays
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// 	Find the first occurence of an byte[] in another byte[]
        /// </summary>
        /// <param name = "buf1">the byte[] to search in</param>
        /// <param name = "buf2">the byte[] to find</param>
        /// <returns>the first position of the found byte[] or -1 if not found</returns>
        /// <remarks>
        /// 	Contributed by blaumeister, http://www.codeplex.com/site/users/view/blaumeiser
        /// </remarks>
        public static int FindArrayInArray(this byte[] buf1, byte[] buf2)
        {
            int i, j;
            for (j = 0; j < buf1.Length - buf2.Length; j++)
            {
                for (i = 0; i < buf2.Length; i++)
                {
                    if (buf1[j + i] != buf2[i])
                        break;
                }
                if (i == buf2.Length)
                    return j;
            }
            return -1;
        }
    }
}