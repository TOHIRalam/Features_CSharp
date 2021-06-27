using System;
using System.Globalization;

namespace Features_CSharp
{
    public delegate void printToUpper(string str);
    class Program
    {
        public static void print_upper(string str) => Console.WriteLine(str.ToUpper());
        static void Main(string[] args)
        {
            /*
             * 1. C# includes built-in generic delegate type Func and Action, so that we don't need 
             *    to define custom delegates manually in most cases. 
             * 2. Action is a generic delegate included in the System namespace. It has zero or more 
             *    input paramters.
             * 3. Action delegate can have 0 to 16 input paramters.
             * 4. Action delegate is same as func delegate except that it does not return a value. 
             *    An action delegate can be used with a method that has a void return type.
             * 5. Action delegate type can be used with an anonymous method or lambda expression
             */

            // Normal delegate
            printToUpper stringToUpper = new printToUpper(print_upper);
            stringToUpper.Invoke("tasnimul alam");

            // Action delegate
            // Action<string> actionPrintToUpper = print_upper;
            Action<string> actionPrintToUpper = new Action<string>(print_upper);
            actionPrintToUpper.Invoke("tasnimul alam");

            // With anonymouse method 
            Action<string> actionPrintToLower = delegate (string str) { Console.WriteLine(str.ToLower()); };
            actionPrintToLower.Invoke("TASnimul AlAm");

            // With lambda expression 
            Action<string> actionStringLambda = (string str) => Console.WriteLine("\nLower: " + str.ToLower());
            actionStringLambda += (string str) => Console.WriteLine("Upper: " + str.ToUpper() + "\n");
            actionStringLambda += delegate (string str) {
                string[] words = str.Split(" ");
                foreach(var i in words)
                {
                    char ch = i[0];
                    string newStr = i.Remove(0, 1);
                    Console.WriteLine($"{char.ToUpper(ch) + newStr.ToLower()}'s length: {i.Length}");
                    //Console.WriteLine($"{i.ToLower().Replace(i[0].ToString(), i[0].ToString().ToUpper())}'s length: {i.Length}");
                }
            };
            actionStringLambda += delegate (string str) {
                Console.WriteLine($"Spaces: {str.Length - string.Join("", str.Split(" ")).Length}");
            };
            actionStringLambda += (string str) => Console.WriteLine("Total length: " + str.Length);
            //actionStringLambda.Invoke("tAsniMuL aLAm");
            InvokeDelegate(actionStringLambda, "tAsniMuL aLAm");
        }

        public static void InvokeDelegate(Action<string> act, string str)
        {
            act.Invoke(str);
        }
    }
}