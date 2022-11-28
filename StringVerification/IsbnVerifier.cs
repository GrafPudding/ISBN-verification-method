using System;
using System.Linq;

namespace StringVerification
{
    public static class IsbnVerifier
    {
        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 identification number of book.
        /// </summary>
        /// <param name="number">The string representation of book's number.</param>
        /// <returns>true if number is a valid ISBN-10 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if number is null or empty or whitespace.</exception>
        public static bool IsValid(string number)
        {
#pragma warning disable CA1305
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Use somthing!");
            }

            if (number.All(char.IsWhiteSpace))
            {
                throw new ArgumentException("Use somthing!");
            }

            int indifikator = 0;
            char[] falseCheck = number.ToCharArray();
            int k = 1;
            for (int j = 0; j < falseCheck.Length; j++)
            {
                if (falseCheck[j] == '-')
                {
                    indifikator++;
                }

                if (falseCheck[j] == '-' && falseCheck[k] == '-')
                {
                    return false;
                }

                k++;
            }

            string[] charsWithoutDefis = number.Split('-');
            string skip = string.Concat(charsWithoutDefis);
            char[] chars = skip.ToCharArray();
            int[] aint = new int[chars.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsDigit(chars[i]))
                {
                    aint[i] = Convert.ToInt32(chars[i].ToString());
                }
                else if (chars[i] == 'X' && i != 9)
                {
                    return false;
                }
                else if (chars[i] == 'X')
                {
                    aint[i] = 10;
                }
                else
                {
                    return false;
                }
            }

            if (indifikator > 3)
            {
                return false;
            }
            else if (chars.Length < 10 || chars.Length > 10)
            {
                return false;
            }
            else if (((aint[0] * 10) + (aint[1] * 9) + (aint[2] * 8) + (aint[3] * 7) + (aint[4] * 6) + (aint[5] * 5) + (aint[6] * 4) + (aint[7] * 3) + (aint[8] * 2) + (aint[9] * 1)) % 11 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            throw new ArgumentException("You need to implement this method.");
        }
    }
}
