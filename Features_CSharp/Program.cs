using System;
using System.Globalization;

namespace Features_CSharp
{
    // Func delegate with at least one input and one output parameter
    public delegate TMoney Func<in T, out TMoney>(T money);
    public delegate TSalary Func <in T1, in T2, out TSalary>(T1 timeSpent, T2 currentSalary);

    class SALARY
    {
        public static double Money(double salary) => salary - ((salary * 10) / 100);
        public static double Salary(double timeSpent, double currentSalary)
        {
            if(timeSpent > 60)
            {
                return currentSalary + 10000;
            }
            else if(timeSpent > 40)
            {
                return currentSalary + 5000;
            }
            else if(timeSpent > 10)
            {
                return currentSalary + 1000;
            }
            return currentSalary;
        }
    }

    class Program
    {
        public static int sum(int a, int b) => a + b;
        static void Main(string[] args)
        {
            /* 
             * 1. C# includes built-in generic delegate type Func and Action, so that we don't need 
             *    to define custom delegates manually in most cases. 
             * 2. Func is a generic delegate included in the System namespace. It has zero or more 
             *    input paramters and one out parameter. The last paramter is considered as an out parameter.
             * 3. A Func delegate type can include 0 to 16 input paramters of different types. However, 
             *    it must include an out paramter for the result. 
             * 4. A Func delegate type must return a value.
             * 5. Func delegate type does not allow ref and out paramters
             * 6. Func delegate type can be used with an anonymous method or lambda expression
             */

            // This Func delegate takes two input parameter and one output parameter
            Func<int, int, int> Sum = sum;
            Console.WriteLine($"Sum: {Sum.Invoke(10, 5)}");

            // We can assign an anonymous method to the Func delegate by using the delegate keyword
            Func<int> getRandomNumer = delegate ()
            {
               Random rand = new Random();
               return rand.Next(1, 100);
            };
            Console.WriteLine($"Random Number1: {getRandomNumer()}");

            // A Func delegate can also be used with a lambda expression
            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);
            Console.WriteLine($"Random Number2: {getRandomNumber2.Invoke()}");

            // Every Func delegate must have one output parameter
            Func<double, double> totalSalary = SALARY.Money;
            Func<double, double, double> getSalary = SALARY.Salary;
            Console.WriteLine($"Salary: {totalSalary.Invoke(getSalary.Invoke(40.5, 24000)).ToString("C2", CultureInfo.CreateSpecificCulture("jp-JP"))}");
        }
    }
}