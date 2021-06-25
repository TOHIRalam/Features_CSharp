using System;

namespace Features_CSharp
{
    interface IMATH
    {
        int Sum(int x, int y);
        int Sub(int x, int y);
    }

    interface ISTRING
    {
        string string_data(string funcName1, string funcName2);
    }

    class IMPL : IMATH, ISTRING
    {
        public int Sum(int x, int y) => x + y;
        public int Sub(int x, int y) => x - y;
        public string string_data(string funcName1, string funcName2) => $"{funcName1} and {funcName2} is: ";
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Interface is a completely abstract class which can only contain abstract methods and properties
             * 2. Interface members are by default abstract and public
             * 3. An interface can not contain a constructor.
             * 4. C# does not support multiple inheritance, however it can be achieved with interface, because
             *    the class can implement multiple interfaces. 
             */

            IMPL impl = new IMPL();
            Console.Write(impl.string_data("Sum", "Sub") + impl.Sum(10, 8) + " and " + impl.Sub(12, 8));
        }
    }
}