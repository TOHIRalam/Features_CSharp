using System;

namespace Features_CSharp
{
    class Program
    {
        static bool isUpperCase(string str) => str.Equals(str.ToUpper());
        static bool isLowercase(string str) => str.Equals(str.ToLower());
        static void Main(string[] args)
        {
            /*
             * 1. Predicate is a delegate like Func and Action with small difference that it only returns Boolean. 
             * 2. It works with those methods which contain some set of criteria and determine 
             *    whether the passed parameter fulfill the given criteria or not.
             * 3. A predicate delegate methods must take one input parameter and return a boolean - true or false
             * 4. Signature: public delegate bool Predicate <in T>(T obj);
             * 5. Predicate can also be used with any method, anonymous method, or lambda expression.
             */

            Predicate<string> isUpperCaseString = new Predicate<string>(isUpperCase);
            Predicate<string> isLowerCaseString = new Predicate<string>(isLowercase);
            string[] conditions = { "all uppercase", "all lowercase" };
            InvokeDelegates("HELLO WORLD!", conditions, isUpperCaseString, isLowerCaseString);

            // With anonymouse method
            Predicate<int> isEvenNumber = delegate (int number)
            {
                return number % 2 == 0; 
            };

            // With lambda expression 
            Predicate<int> isOddNumber = number => number % 2 != 0;

            Console.WriteLine("Is 10 even number? {0}\n" +
                "Is 10 odd number? {1}", isEvenNumber.Invoke(10), isOddNumber.Invoke(10));
        }

        public static void InvokeDelegates(string str, string[] conditionas, params Predicate<string>[] pred)
        {
            for(var i = 0; i < conditionas.Length; i++)
            {
                Console.WriteLine($"Is '{str}' {conditionas[i]}: {pred[i].Invoke(str)}");
            }
        }
    }
}
