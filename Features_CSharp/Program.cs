using System;
using System.Globalization;

namespace Features_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * 1. The maximum size of a String object in memory is 2GB or about 1 billion character
             * 2. Essentially there is no difference between String and string in C#
             * 3. String is a class in the .NET framework in the System namespace whereas, 
             *    the lower case string is an alias of System.String
             * 4. We must import System namespace at the top of our .cs file to use String class
             *    whereas string keyword can be used directly without any namespace
             */

            string str = "Hello World!";

            // str.StartsWith() and str.EndsWith()

            Console.WriteLine("Hello World! starts with 'H': " + str.StartsWith('H') + "\n" +
                "Hello World! ends with '!': " + str.EndsWith('!') + "\n");

            // A string is a collection or an array of character so, string can be created using char array
            char[] charStr = { 'H', 'E', 'L', 'L', 'O' };
            
            string strChar = new string(charStr);
            String strChar2 = new String(charStr);

            // We can use escaping character \ (backslash) before these special character to include in a string
            string myStr = "Hello \"World\"";

            /*
             * However, it will be very tedious to prefix \ for every special character. Prefixing the string
             * with an @ indicates that it should be treated as a literal and should not escape any character.
             */

            string path = @"\\mypc\shared\project";
            string email = @"test@test.com";

            // We can also use @ to declare multi-line string

            string multiLineString = @"this is a \
                                        multi line \
                                        string";

            // String interpolation: Mixture of static string and string variables that are in between {} brackets
            Console.WriteLine($"{multiLineString} #007");

            // We have to use two {{}} to include { or } in a string
            Console.WriteLine($"{{or}} #007");

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


            /*
             * 
             *                           Standard numeric format strings
             *                          ---------------------------------
             * 1. Standard numeric format strings are used to format common numeric types. 
             * 2. A standard numeric format string takes the form [format specifier][precision specifier]
             * 3. Format specifier: a single alphabetic character that specifies the type of number format
             * 4. Precision specifier: it is an optional integer that affects the number of digits in the string
             * 
             */


            Console.ForegroundColor = ConsoleColor.Cyan;

            // Currency

            Console.WriteLine($"Dollar: {465.25654651}");
            Console.WriteLine($"Japanese currency: {465.25654651.ToString("C3", CultureInfo.CreateSpecificCulture("jp-JP"))}");
            
            // Decimal

            Console.WriteLine($"Six digit decimal: {45:D6}");

            // Exponential

            Console.WriteLine($"Exponential: {45.25654651:E2}");

            // Integral and decimal digits

            Console.WriteLine($"Four digit decimal: {4.25654651:F4}");

            // Scientific notation

            Console.WriteLine($"Fixed point or scientific notation: {43335.25654651:G4}");

            // Integral and decimal digit group seperator

            Console.WriteLine($"Integral and decimal digit group seperator: {45.25654651:N3}");

            // Multiplied by 100 with percent symbol

            Console.WriteLine($"Multiplied by 100 with percent Symbol: {45.25654651:P}");

            /*
             * The round-trip ("R") format specifier attempts to ensure that a numeric value 
             * that is converted to a string is parsed back into the same numeric value.
             */

            Console.WriteLine($"The round-trip: {1234.24123451:R17}");

            // Hexadecimal string

            Console.WriteLine($"Hexadecimal String: {13:X4}");
        }
    }
}