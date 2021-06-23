using System;

namespace Features_CSharp
{
    static class MATH
    {
        public static int x { get; set; }
        public static int y { get; set; }

        public static int sum()
        {
            return x + y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Static class can't be instantiate and
            // Static class can have only static members

            MATH.x = 4;
            MATH.y = 6;
            Console.WriteLine("Sum: " + MATH.sum());
        }
    }
}