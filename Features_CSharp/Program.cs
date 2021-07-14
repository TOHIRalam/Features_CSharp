using System;

namespace Features_CSharp
{
    class Program
    {
        static bool checkInput(in int x) => x > 10;
        static void Main(string[] args)
        {
            /*
             * 1. The in keyword causes arguments to be passed by reference
             *    but ensures the argument is not modified. 
             * 2. When we are using in keyword we don't have to use an in 
             *    in the caller side.
             */

            int userInpur = Convert.ToInt32(Console.ReadLine());
            if(checkInput(userInpur))
                Console.WriteLine("Greater than 10");
            else
                Console.WriteLine("Not greater than 10");
        }
    }
}