using System;
using System.Collections.Generic;

namespace Features_CSharp
{
    class Program
    {
        public static List<int> item_list = new List<int>();

        public static void fillValues()
        {
            for (var i = 0; i < 10; i++)
            {
                item_list.Add(i);
            }
        }

        // Return numbers that are greater than 3
        static IEnumerable<int> filter()
        {
            List<int> temp = new List<int>();
            foreach (var item in item_list)
            {
                if (item > 3)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        // Efficient Filter() function
        static IEnumerable<int> efficient_filter()
        {
            foreach(var item in item_list)
            {
                if(item > 3)
                {
                    // Instead of returning a list yield returns one item at a time.
                    yield return item;
                }
            }
        }

        static void Main(string[] args)
        {
            /* 1. yield return statement to return each element one at a time.
             * 2. We can not use yield return or yield break in lambda expression or anonymous method
             * 3. A yield return statement can't be located in a try-catch block.
             * 4. A yield return statement can be located in the try block of a try-finally statement.
             * 5. A yield break statement can be located in a try block or a catch block but not a finally block. */

            fillValues();
            
            foreach(var i in filter())
                Console.Write(i + " ");
            
            Console.WriteLine();

            foreach (var it in efficient_filter())
                Console.Write(it + " ");

            Console.WriteLine();
        }
    }
}