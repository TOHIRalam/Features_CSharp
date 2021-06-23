using System;

namespace Features_CSharp
{
    class MATH
    {
        public static int x { get; set; }
        public static int y { get; set; }
        public static int z { get; set; }

        public MATH(int a, int b)
        {
            x = a;
            y = b;
        }

        static MATH() { z = 10; }

        public static int sum() => x + y;

        public static int some_math() => z * (x + y);
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Static constructor is used to initialize static fields
             * 2. Static constructor can't have any modifiers
             * 3. Static constructor is invoked implicitly
            */

            MATH math = new MATH(5, 6);
            Console.WriteLine("Result: " + MATH.some_math()); // Output 110
        }
    }
}