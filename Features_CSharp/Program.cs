using System;

namespace Features_CSharp
{
    class Delegate
    {
        public delegate int Perform(int[] arr);
        public static int sum(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }

        public static void processMath(int[] arr, Perform perform)
        {
            perform(arr);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4 };
            var logic = new Delegate.Perform(Delegate.sum);
            Console.WriteLine(Delegate.sum(arr));
        }
    }
}
