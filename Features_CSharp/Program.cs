using System;

namespace Features_CSharp
{
    class Program
    {
        public int maxMinSum(out int x, out int y, params int[] arr)
        {
            x = arr[0];
            y = arr[0];
            for(int i = 1; i < arr.Length; i++)
            {
                x = (arr[i] > x) ? arr[i] : x;
                y = (arr[i] < y) ? arr[i] : y;
                arr[0] += arr[i];
            }
            return arr[0];
        }

        static void Main(string[] args)
        {
            // By using out keyword we can return multiple values from methods
            int x, y, sum = new Program().maxMinSum(out x, out y, 1, 2, 3, 4, 5);
            Console.WriteLine($"Max: {x}\nMin: {y}\nSum: {sum}\n\n");
        }
    }
}