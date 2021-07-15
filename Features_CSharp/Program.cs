using System;
using System.Threading;
using System.Threading.Tasks;

namespace Features_CSharp
{
    class Program
    {
        private static void RunMillionIterations()
        {
            string x = "";
            for (int i = 0; i < 1000000; i++)
                x += 's';
        }

        static void DoWork(int id, int sleep)
        {
            Console.WriteLine($"Task {id} is beginning.....");
            Thread.Sleep(sleep);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Task {id} is completed.....");
            Console.ResetColor();
        }

        static void DoOtherTask(int id, int sleep)
        {
            Console.WriteLine($"Other task {id} is beginning.....");
            Thread.Sleep(sleep);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Other task {id} is completed.....");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            /* 1. Task Parallel Library (TPL), basically provides a higher level of abstraction. 
             *    Fundamentally, it boils down to a “task” which is equivalent to a thread except 
             *    that it is more lightweight and comes without the overhead of creating an OS thread. 
             *    In other words, a task is an easier way to execute something asynchronously and in 
             *    parallel compare to a thread.
             *    
             * 2. The Task Parallel Library (TPL) is a set of public types and APIs in the System.
             *    Threading and System.Threading.Tasks namespaces. The purpose of the TPL is to 
             *    make developers more productive by simplifying the process of adding parallelism and 
             *    concurrency to applications. The TPL scales the degree of concurrency dynamically to 
             *    most efficiently use all the processors that are available. In addition, the TPL 
             *    handles the partitioning of the work, the scheduling of threads on the ThreadPool, 
             *    cancellation support, state management, and other low-level details. */

            //Thread thread = new Thread(RunMillionIterations);
            //thread.Start();

            // Parallel.For(0, 1000000, x => RunMillionIterations());

            // As soon as task t1 completed DoOtherTask will start
            Task t1 = Task.Factory.StartNew(() => DoWork(1, 2000)).ContinueWith((prev) => DoOtherTask(1, 1000));
            Task t2 = Task.Factory.StartNew(() => DoWork(2, 2500));
            Task t3 = Task.Factory.StartNew(() => DoWork(3, 1500));

            // Faster way to execute for loop but it won't be seqential 
            Parallel.For(0, 10, i => {
                Console.WriteLine($"i = {i}");
                Thread.Sleep(1000);
            });

            /*var t1 = new Task(() => DoWork(1, 1000));
            t1.Start();
            var t2 = new Task(() => DoWork(2, 3000));
            t2.Start();
            var t3 = new Task(() => DoWork(3, 1500));
            t3.Start();*/

            Console.WriteLine("Press any key to exit...!!");
            Console.ReadLine();
        }
    }
}