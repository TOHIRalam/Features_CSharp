using System;

namespace Features_CSharp
{
    class Program
    {
        public enum Days
        {
            Sat,
            Sun,
            Mon, 
            Tue = 13,
            Wed, 
            Thu,
            Fri
        }

        static void Main(string[] args)
        {
            /*
             *  1. Enum is also known as enumeration
             *  2. It is used to store named constants 
             *  3. The enum constants are also known as enumerators
             *  3. Enumrators has default values which starts from 0
             *     and incrementd to one by one.
             *  4. We can change the default value of enumrators
            */

            foreach (string str in Enum.GetNames(typeof(Days)))
                Console.Write(str + " ");
            Console.WriteLine("\n");
            foreach (int i in Enum.GetValues(typeof(Days)))
                Console.WriteLine(Enum.GetName(typeof(Days), i) + " = " + i);

            Console.WriteLine("\nFriday is " + (int)Days.Fri);
        }
    }
}