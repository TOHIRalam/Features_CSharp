using System;
using System.Threading;

namespace Features_CSharp
{
    class ThreadClass
    {
        public static void PrintThreadInfo()
        {
            for (int i = 0; i < 10; i++)
                Console.Write("{0} ", i);
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Function1()
        {
            for (var i = 1; i <= 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{i} ");
            }
            Console.WriteLine("\nDone");
        }

        static void Function2()
        {
            for (var i = 1; i <= 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{i} ");
            }
            Console.WriteLine("\nDone");
        }

        static void Function()
        {
            Console.WriteLine("Entered to the funciton");
            Console.ReadLine();
            Console.WriteLine("Exited the funciton");
        }

        static void Main(string[] args)
        {
            /* a) Thread is a basic unit of execution within the process, and it's responsible for executing the application logic.
             * b) By default every application or program will carry one thread to execute the application logic, and that thread is
             *    called the Main thread. So we can say that every program of application is by default a single-thread model.
             * c) In C# we need to import System.Threading namespace in our program to work with threads. After importing System.Threading
             *    namespace we can create or access the threading using Thread class. 
             * d) In c#, the Main thread is responsible for executing the programming logic in a synchronous way that means one after another. 
             *    If we want to execute the few tasks simultaneously (asynchronous way), we need to create the child threads in our application.
             * e) There are two types of threads which are:-
             *      (1) Foreground Thread: These threads will keep running until the last foreground thread is terminated. In another way, the 
             *          application is closed when all the foreground threads are stopped. By default threads are foreground threads. We can
             *          specify foreground threads for business critical tasks. A foreground thread is thread that has a high percentage of the
             *          focus for any particular moment, this means that it spends more of its time executing.
             *      (2) Background Thread: These threads will get terminated when all foreground threads are closed. The application won't 
             *          wait for the background threads to complete. Background threads can be useful for polling services or logging services
             *          which could be discontinued once the application closed. A background thread is a thread that doesn't have complete 
             *          focus at the moment. By focus, we mean processor time. 
             * 
             * f) If we create any other threads in our program by using Thread class those will become child threads for the Main thread.
             * g) If we want to access the Main thread that is executing the current program code, we can get it by using CurrentThread
             *    property of the Thread class.
             * h) Join(): It causes all the calling threads to wait until the current thread (joined thread) is terminated or completes its task.
             * i) Abort(): The Abort() method is used to terminate the thread. It raises ThreadAbortException if Abort operation is not done.
             *    
             *    
             *                                                             Thread Life Cycle
             *                                                            -------------------
             * # Each thread will have a life cycle, and it will start when we create an instance of the object using Thread class. Once the task
             *   execution of the thread is completed, then the life cycle of the thread will get an end. States of thread life cycle:-
             *          1) Unstarted: When we create the thread, that will be in the unstarted state.
             *          2) Runnable: When we call the start() method, the thread will move to ready to run or Runnable() state.
             *          3) Running: Only one thread within a process can be executed at a time. At the time of execution, thread is in 
             *                      running state.It indicates that the thread is in a running state. 
             *          4) Not Runnable: If the thread is in a not runnable state means there is a chance that the Sleep() or Wait() or Suspend()
             *                           method is called on the thread or blocked by I/O operations.
             *          5) Dead: If the thread is in a dead state, it means the thread completes its task execution or is aborted.      
             *          
             * @ Thread class, properties and methods:-
             *      (1) https://www.javatpoint.com/c-sharp-thread-class
             *      (2) https://www.tutlane.com/tutorial/csharp/csharp-threading
             */

            #region Asynchronous Threading
            /*
            // Created two threads
            Thread thread1 = new Thread(Function1);
            Thread thread2 = new Thread(Function2);

            // Invoke threads
            thread1.Start();
            thread2.Start();
            */
            #endregion

            #region Foreground Thread

            /*    Foreground Thread example     */

            //Thread threadObject = new Thread(Function);
            //threadObject.Start();

            #endregion

            #region Background Thread

            /*    Background Thread example     */

            //Thread threadObjectBackground = new Thread(Function);
            //threadObjectBackground.IsBackground = true;
            //threadObjectBackground.Start();

            #endregion

            #region Start a thread from a class

            /* Start a thread from a class */

            //Thread ThreadClassObject = new Thread(new ThreadStart(ThreadClass.PrintThreadInfo));
            //new Thread(new ThreadStart(ThreadClass.PrintThreadInfo)).Start();
            //new Thread(new ThreadStart(Function1)).Start();

            #endregion

            #region Thread Join() 

            /* Thread Join() */

            Thread t1 = new Thread(Function1);
            Thread t2 = new Thread(Function2);

            t1.Start();
            t1.Join();
            t2.Start();


            #endregion

            Console.WriteLine("The main application has exited.");
            Console.ResetColor();
        }
    }
}