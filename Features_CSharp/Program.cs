using System;

namespace Features_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. using statment defines a boundary for the object outside of which,
             *    the object is automatically destroyed. The using statement in C# is
             *    exited when the end of the using statement block or the execution 
             *    exits the using statement block indirectly. 
             * 2. The using statement allows us to specify multiple resources in a single
             *    statement. The object could also be created outside the using statement. 
             *    The objects specified within the using block must implement the IDisposable 
             *    interface. The framework invokes the Dispose method of objects specified 
             *    within the using statement when the block is exited. 
             * 3. The using directive is used to provide an alias for a namepace. 
             */
        }
    }
}