using System;
using System.Collections;

namespace Features_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  1. Boxing is the process of converting a value type to the reference type.
             *     It is implicit conversion process in which object type (super type) is used.
             *     The value type in always stored in stack and reference type is stored in heap.
             *  2. Unboxing is the process of converting a reference type to the value type.
             *     It is explicit conversion process.
             *  3. Boxing and Unboxing enables a unified view of the type system in which a value 
             *     of any type can be treated as an object.
             */

            int x = 10;                  // The value type is int and assinged value is 10
           
            Object obj = x;              // Boxing
            
            int number = (int)obj;       // Unboxing

            Console.WriteLine($"{ obj }\n{ number }");


            ArrayList list = new ArrayList();

            list.Add(10);         // boxing

            /* ArrayList is a class in C# and so it is a reference type. 
             * We add an int value 10 in it. So, .NET will perform the 
             * boxing process here to assign value type to reference type. */

            list.Add("Hello");
        }
    }
}