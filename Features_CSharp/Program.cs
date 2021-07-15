using System;
using System.Threading;
using System.Threading.Tasks;

namespace Features_CSharp
{
    class Program
    {
        public static async void Method()
        {
            // await: Wait at this line until LongTask finishes
            await Task.Run(new Action(LongTask));

            // Wait until the long task finishes
            Console.WriteLine("New Thread");
        }

        public static void LongTask()
        {
            Thread.Sleep(1200);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Long task finished");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            /* 0. Async and await are markers which mark code positions from where control should resume 
             *    after a task (thread) completes.
             * 1. An async method runs synchronously until it reaches its first await expression, at which
             *    point the method is suspended until the awaited task is complete. In the meantime, control 
             *    returns to the caller of the method, as the example in the next section shows.
             * 2. If the method that the async keyword modifies doesn't contain an await expression or 
             *    statement, the method executes synchronously. A compiler warning alerts you to any async 
             *    methods that don't contain await statements, because that situation might indicate an error. 
             * 3. We cannot use await without async or vise-versa, we have to use them in pair. */

            Method();
            Console.WriteLine("Main thread");
            Console.ReadLine();
        }
    }
}