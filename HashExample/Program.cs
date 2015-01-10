using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace HashExample
{
    class HashExample
    {
        // Hash a string and return the hash as a hexadecimal string.
        static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify hashes for two potentially different strings
        static bool verifyMd5Hash(string input, string hash)
        {
            // Create a StringComparer to compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        static void Main()
        {
            Console.WriteLine("Enter a string to hash");
            string source1 = Console.ReadLine();
            string hash1 = getMd5Hash(source1);

            Console.WriteLine("The hash of " + source1 + " is: " + hash1 + ".");

            Console.WriteLine("\nEnter another string to hash");
            string source2 = Console.ReadLine();
            string hash2 = getMd5Hash(source2);
            Console.WriteLine("The hash of " + source2 + " is: " + hash2 + ".");

            if (verifyMd5Hash(hash1, hash2))
            {
                Console.WriteLine("\nThe hashes are the same.  The string values are unchanged.\n");
            }
            else
            {
                Console.WriteLine("\nThe hashes are the different.  The string values are different.\n");
            }
            Console.ReadLine();

        }
    }
}