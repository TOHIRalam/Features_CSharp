using System;

namespace Features_CSharp
{
    class A
    {
        // const int y; // Error
        public readonly int x;
        public const int y = 23;
        public A()
        {
            x = 49;
            x = 4;
        }
    }

    class Program
    {
        public const int cmToMeters = 100; // Compile time constant
        public readonly double PI = 3.1;   // Runtime constant
        static void Main(string[] args)
        {
            /* A const is a compile-time constant whereas readonly allows a value to be calculated at run-time and set in 
             * the constructor or field initializer. So, a 'const' is always constant but 'readonly' is read-only once it is assigned. 
             * 
             * # const
             *      1. They can't be declared as static
             *      2. The value of constant is evaluated at compile time
             *      3. constants are initialized at declaration only
             *  
             * # readonly
             *      1. They are by default static
             *      2. The vlaue is evaluated at run time
             *      3. readonly can be initialized in declaration or by code in the constructor 
             * 
             */

            Console.WriteLine(new A().x);
        }
    }
}