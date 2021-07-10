using System;

// using as alies
using thread = System.Threading.Thread;

// Allow access static members and nested types 
using static System.Math;
using static System.Console;
using Math_Space;
using System.IO;

namespace Math_Space
{
    class ProgramX
    {
        public static double[] indexArr;

        public ProgramX() => indexArr = new double[5];

        public double this[int index]
        {
            get => Pow(indexArr[index], 2);
            set => indexArr[index] = value;
        }
    }
}

namespace Features_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 0. using statement defines a scope at the end of which the object will be disposed.
             * 
             * 1. using statment defines a boundary for the object outside of which, the object is 
             *    automatically destroyed. The using statement in C# is exited when the end of the 
             *    using statement block or the execution exits the using statement block indirectly.
             *    
             * 2. The using statement allows us to specify multiple resources in a single statement. 
             *    The object could also be created outside the using statement. The objects specified
             *    within the using block must implement the IDisposable interface. The framework 
             *    invokes the Dispose method of objects specified within the using statement when the 
             *    block is exited. The using directive is used to provide an alias for a namepace or
             *    imports types defined in other namespaces. The using static directive imports the 
             *    members of a class in a single file. 
             *    
             *                                      Using directive 
             *                                     -----------------
             * 3. The using directive has three uses:
             *      a) To allow the use of types in namespace so that we do not have to qualify the type
             *         eg. using system.Text;
             *      b) To allow us to access static members and nested types of a type without having to 
             *         qualify the access with the type name. eg. using static System.Math;
             *      c) To create an alias for a namespace or a type. This is called using alias directive.
             *      
             *                                      Using statement 
             *                                     -----------------
             * 4. It provides a convenient syntas that ensures the connect use of IDisposable objects.
             */

            System.Threading.Thread.Sleep(100);   // Sleep for 100ms 
            thread.Sleep(100);      // thread works as an alies of System.Threading.Thread

            Console.WriteLine(Math.Sqrt(9) + "\n" + Sqrt(9));   // We don't have to use System.Math each time 
            WriteLine("Hello World!"); // We don't have to use System.Console.WriteLine() or Console.WriteLine()

            Math_Space.ProgramX prog1 = new Math_Space.ProgramX();
            ProgramX prog2 = new();   // We don't have to use Math_Space.ProgramX because of using directive
            prog2[0] = 2;
            WriteLine(prog2[0]);

            string manyLines = @"
            This is line one
            This is line two
            Here is line three
            The penultimate line is line four
            This is the final, fifth line.";

            using (var reader = new StringReader(manyLines))
            {
                string item;

                do
                {
                    item = reader.ReadLine();
                    Console.WriteLine(item);
                } while (item != null);
            }

            // C# 8.0 update of using statement, now using statement does not require braces

            using var readerX = new StringReader(manyLines);
            
            string itemX;

            do
            {
                itemX = readerX.ReadLine();
                Console.WriteLine(itemX);
            } while (itemX != null);
        }
    }
}