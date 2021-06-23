using System;
using System.Collections.Generic;
using System.Threading;

namespace Features_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Hello World!";
            Console.WriteLine("Hello World! starts with 'H': " + str.StartsWith('H') + "\nHello World! ends with '!': " + str.EndsWith('!') + "\n");

            string str1 = "abcd";
            string str2 = "abc";
            Console.WriteLine("abcd > abc: " + str1.CompareTo(str2));               // Returns 1 because abcd is greater than abc
            Console.WriteLine("abc < abcd: " + str2.CompareTo(str1));               // Returns -1 because abc is less than abcd
            Console.WriteLine("abcd == abcd: " + str1.CompareTo("abcd"));           // Returns 0 because abcd is equal to abcd
            Console.WriteLine("abcd < d: " + string.Compare(str1, "d"));            // Returns -1 as the first char in abcd is less than char d
            Console.WriteLine("abcd > d: " + string.Compare("abcd", "ac"));         // Returns -1 as the second char in "ac" is greater than the second char in "abcd"
            Console.WriteLine("abcd != abc: " + str1.Equals(str2) + "\n");          // Returns false as equals method check if the two string is matched or not


            Console.WriteLine("abcd > abc: " + string.CompareOrdinal(str1, str2)); 
            Console.WriteLine("abc < abcd: " + string.CompareOrdinal(str2, str1));  
            Console.WriteLine("abcd == abcd: " + string.CompareOrdinal(str1, "abcd") + "\n"); 

            string str3 = "abx";
            string str4 = "abz";
            Console.WriteLine("abx < abz: " + str3.CompareTo(str4)); 
            Console.WriteLine("abz > abx: " + str4.CompareTo(str3));  
            Console.WriteLine("abx == abx: " + str3.CompareTo("abx") + "\n");

            Console.WriteLine("abx < abz: " + string.CompareOrdinal(str3, str4));  
            Console.WriteLine("abz > abx: " + string.CompareOrdinal(str4, str3));  
            Console.WriteLine("abz > abc: " + string.CompareOrdinal(str4, "abc") + "\n");  // Returns 23 as position of 'z' in English alphabet is 26 and 'c' is 3 so, 26 - 3 = 23 

            Console.WriteLine("Concat str3, str4: " + string.Concat(str3, str4) + "\n");

            string countries = "Bangladesh, India, Pakistan, Russia, Thailand";
            Console.WriteLine("Check if countries string contains 'Russia': " + countries.Contains("Russia"));  // Contains method

            Console.WriteLine("String format: " + String.Format("{0:D} | {1:d}", DateTime.Now, DateTime.Now));  // String.Format

            Console.WriteLine("Index of India: " + countries.IndexOf("India"));                                 // IndexOf method
            countries = countries.Insert(12, "Japan, ");
            Console.WriteLine("After inserting another country: " + countries);

            int[] arr = { 1, 2, 3, 4 };
            string arrString = string.Join(", ", arr);                                                          // Join method
            Console.WriteLine("String representation of array: " + arrString);

            Console.WriteLine("\nFirst index of 'a' in countires string: " + countries.IndexOf('a'));           // IndexOf method
            Console.WriteLine("Last index of 'a' in countires string: " + countries.LastIndexOf('a'));          // LastIndexOf method

            Console.WriteLine("Left padding to arrString: " + arrString.PadLeft(20));

            string firstCountry = countries.Remove(10);                                                         // Remove method
            Console.WriteLine("Remove everything after index 9 in countries string: " + firstCountry);
            Console.WriteLine("Keep only first two country: " + countries.Remove(17, countries.Length-17));
            
            countries = countries.Replace("Japan", "China");                                                    // Replace method
            Console.WriteLine("After replacing 'Japan': " + countries);
            
            string[] countriesArray = countries.Split(", ");                                                    // Split method
            Console.Write("Countries string array: ");
            foreach(var i in countriesArray) { Console.Write(i + " "); }
            
            countriesArray[0] = countriesArray[0].ToUpper();                                                    // ToUpper method
            Console.WriteLine("\nUpper case string: " + countriesArray[0]);

            string temp = "   Hello World   ";
            Console.WriteLine("Normal String: " + temp);

            temp = temp.Trim();
            Console.WriteLine("After trim: " + temp);                                                           // Trim method
        }
    }
}