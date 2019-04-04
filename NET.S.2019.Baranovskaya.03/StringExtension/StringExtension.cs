namespace StringExtension
{
    using System.Text;

    /// <summary>
    /// Includes extension methods for double values
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Returns string representation of double number
        /// </summary>
        /// <param name="number">input number</param>
        /// <returns>string representation</returns>
        public static string ToBinaryString(this double number)
        {
            StringBuilder result = new StringBuilder();

            ulong ul;

            unsafe
            {
                ul = *(ulong*)&number;
            }

            int highInt = (int)(ul >> 32);
            int lowInt = (int)(ul & 0xFFFFFFFF);

            for (int i = 0; i < 32; i++)
            {
                int digit = lowInt & 1;
                result.Append(digit);
                lowInt >>= 1;
            }

            for (int i = 0; i < 32; i++)
            {
                int digit = highInt & 1;
                result.Append(digit);
                highInt >>= 1;
            }

            for (int i = 0; i < 32; i++)
            {
                char buf = result[i];
                result[i] = result[result.Length - 1];
                result[result.Length - 1] = buf;
            }
            
            return result.ToString();
        }
    }
}
