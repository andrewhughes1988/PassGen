using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen
{
    internal class Generator
    {
        public static string Generate(byte length) 
        {
            string password = "";
            int startingChar = 33, endingChar = 122; // ASCII set ! to z
            List<char> charSet = new List<char>();
            Random random = new Random();

            //Get character set symbols converting int from range to a char
            foreach (int i in Enumerable.Range(startingChar, endingChar - startingChar + 1))
            {
                charSet.Add((char) i);
            }

            //Generate Password - append n* random symbols in the character set
            for (byte i = 0; i < length; i++)
            {
                password += charSet.ElementAt(random.Next(0, charSet.Count));
            }

            return password;
        }
    }
}
