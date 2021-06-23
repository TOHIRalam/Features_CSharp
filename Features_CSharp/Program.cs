using System;

namespace Features_CSharp
{
    class Program
    {
        public int sum(params int [] numbers)
        {
            int sum = 0;
            foreach(var i in numbers) { sum += i; }
            return sum;
        }
        static void Main(string[] args)
        {
            // We can pass a variable number of arguments by using params keyword in methods

            Program pr = new Program();
            Console.WriteLine(pr.sum(1, 2, 3, 4));
            Console.WriteLine(pr.sum(1, 2, 3, 4, 5, 6));
        }
    }
}