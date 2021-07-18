using System;
using System.Text;

namespace Features_CSharp
{
    public static class IntExtension
    {
        public static bool IsGreaterThan(this int i, int value) => i > value;
        public static bool IsDivisibleByFive(this int i) => i % 5 == 0;
        public static string UpperCaseEvenChars(this string str)
        {
            StringBuilder st = new StringBuilder(str); 
            for (var i = 1; i < str.Length; i += 2)
                st[i] = Char.ToUpper(str[i]);
            return st.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* 1. Extension methods are additional custom methods which were originally not included with the class.
             * 2. Extension methods can be added to custom, .NET Framework or third party classes, structs or interfaces.
             * 3. The first parameter of the extension method must be of the type for which the extension method is applicable, preceded by the this keyword.
             * 4. Extension methods can be used anywhere in the application by including the namespace of the extension method. */

            int number = 10;
            string str = "helloWorld";
            Console.WriteLine(number.IsGreaterThan(5));
            Console.WriteLine(number.IsDivisibleByFive());
            Console.WriteLine(str.UpperCaseEvenChars());
        }
    }
}