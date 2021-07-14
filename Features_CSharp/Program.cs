using System;

namespace Features_CSharp
{
    class Program
    {
        public int maxMinSum(out int x, out int y, params int[] arr)
        {
            x = arr[0];
            y = arr[0];
            for(int i = 1; i < arr.Length; i++)
            {
                x = (arr[i] > x) ? arr[i] : x;
                y = (arr[i] < y) ? arr[i] : y;
                arr[0] += arr[i];
            }
            return arr[0];
        }

        static bool ChangeValue(out dynamic x, out dynamic y)
        {
            x = "Hello World!";
            y = 43;
            return true;
        }

        static void Main(string[] args)
        {
            /* 1. By using out keyword we can return multiple values from methods
             * 2. Using out keyword any value that is assigned to a variable will be discarded, 
             *    So, it does not require variable to initialize before passing. 
             *    
             *                           ref vs out vs in Modifiers
             *                          ----------------------------
             * 1. ref is used to state that the parameter passed maybe modified by the method.
             * 2. in is used to state that the paramter passed cannot be modified by the method.
             * 3. out is used to state that the parameter passed must be modified by the method. 
             * 4. Both ref and in require the parameter to have been initialized before being p
             *    passed to a method. The out modifier does not require this and is typically not
             *    initialized prior to being used in a method. */

            dynamic a = 10, b;
            ChangeValue(out a, out b);
            Console.WriteLine(a + " " + b);

            int x, y, sum = new Program().maxMinSum(out x, out y, 1, 2, 3, 4, 5);
            Console.WriteLine($"Max: {x}\nMin: {y}\nSum: {sum}\n\n");

            var input = "10x";
            if (int.TryParse(input, out y))
                Console.WriteLine("Parsed Value: {0}", y);
            else
                Console.WriteLine("Could not parse the variable");
        }
    }
}