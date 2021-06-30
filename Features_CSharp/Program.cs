using System;

namespace Features_CSharp
{
    interface IMATH
    {
        int Sum(int x, int y);
        int Sub(int x, int y);
        string string_data(string funcName1, string funcName2);
    }

    interface ISTRING
    {
        string string_data(string funcName1, string funcName2);
    }

    class IMPL : IMATH, ISTRING
    {
        public int Sum(int x, int y) => x + y;
        public int Sub(int x, int y) => x - y;
        string IMATH.string_data(string funcName1, string funcName2) => $"{funcName1}/{funcName2}";
        string ISTRING.string_data(string funcName1, string funcName2) => $"{funcName1} and {funcName2} is: ";
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
             * 5. We cannot apply access modifier in an interface, all the members are by default public
             * 6. A class or a Struct can implement one or more interface using colon (:)
             * 7. An interface can be implemented explicitly using <InterfaceName>.<MemberName>, 
             *    it is more useful when interfaces have the same method name coincidently.
             */

            IMPL impl = new IMPL();
            
            /* When we implement an interface explicitly, we can access interface members only
               through the instance the instance of an interface type. */ 

            IMATH imath = new IMPL();
            ISTRING istring = new IMPL();
            Console.Write($"{imath.string_data("Sum", "Sub")}\n{istring.string_data("Sum", "Sub")}" +
                $" {impl.Sum(10, 8)} and {impl.Sub(12, 8)}");
        }
    }
}