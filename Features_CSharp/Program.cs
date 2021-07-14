using System;
using System.Threading;

namespace Features_CSharp
{
    class Maths
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        Random rand = new Random();
        public void Divide()
        {
            for (int i = 0; i < 100000; i++)
            {
                /* At the given moment of time only one thread can execute it.
                   Without the lock keyword this program will return an exception
                   because two threads - the main thread and the child thread will try 
                   two execute the same program, where main thread will try to execute
                   int result = Num1 / Num2 and the child thread will execute the lines 
                   after that which are Num1 = 0 & Num2 = 0. Because of this main 
                   thread will divide 0/0 which will throw the exception divide by zero. */

                lock(this)
                {
                    Num1 = rand.Next(1, 2);
                    Num2 = rand.Next(1, 2);
                    int result = Num1 / Num2;
                    Num1 = 0;
                    Num2 = 0;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* 1. Multithreading means executing multiple threads simultaneously to perform multiple tasks at a time.
             * 2. When we start execution, the Main thread will create automatically, and it is responsible for executing
             *    the programming logic in a sychronous way that means one after another. 
             * 3. Synchronization is a technique that allows only one thread to access the resource for the particular 
             *    time. No other thread can interrupt until the assigned thread finishes its task.
             * 4. There are three synchronization techniques:- 
             *          1) Lock: This allows only one thread to enter the part that's locked and the lock
             *                    is not shared with any other processes. 
             *          2) Mutex: A mutex is the same as a lock but can be system wide (shared by multiple processes).
             *          3) Semaphore: A sepmaphore does the same as a mutex but allows n number of threads to enter, this
             *                        can be used for example to limit the number of CPU, IO or ram intensive tasks
             *                        running at the same time.
             */

            // Thread threadObj = new Thread(new ThreadStart(new Maths().Divide));

            Maths maths = new Maths();

            Thread threadObject = new Thread(maths.Divide);
            threadObject.Start(); // Child thread
            maths.Divide(); // Main thread
        }
    }
}