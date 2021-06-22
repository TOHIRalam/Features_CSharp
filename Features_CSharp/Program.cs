using System;
using System.Collections.Generic;
using System.Threading;

namespace Features_CSharp
{
    class Program
    {
        public static void printArr(int[] arr)
        {
            foreach (var i in arr)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // One dimensional array
            int[] arr = { 1, 2, 3, 4 };
            
            // Two dimensional array
            int[,] arr2 =
            {
                {1, 2, 3, 4 },
                {3, 4, 5, 6 },
                {5, 6, 7, 8 }
            };

            // Jagged array
            int[][] arr3 =
            {
                new int[] {1, 2, 3, 4 },
                new int[] {3, 4, 5, 6, 7, 8, 9 },
                new int[] {5, 4, 3}
            };

            // Iterations
            Console.WriteLine("One dimensional array:\n");
            printArr(arr);

            // 2D array iteration
            Console.WriteLine("\nTwo dimensional array:\n");
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write(arr2[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Jagged array iteration
            Console.WriteLine("\nJagged array:\n");
            for (int i = 0; i < arr3.Length; i ++)
            {
                for(int j = 0; j < arr3[i].Length; j++)
                {
                    Console.Write(arr3[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            // Array properties and methods

            // Reverse the array
            Array.Reverse(arr);
            Console.Write("Reversed Array: ");
            printArr(arr);

            // Sort the array
            Array.Sort(arr);
            Console.Write("Sorted Array: ");
            foreach (var i in arr) { Console.Write(i + " "); }
            Console.WriteLine();

            // Dimension
            int[,,,] arr4 = {
                {
                    {
                        { 1, 2 }, { 1, 3 }
                    },
                    {
                        { 3, 4 }, { 8, 9 }
                    }
                },
                {
                    {
                        { 1, 5 }, { 8, 9 }
                    },
                    {
                        { 3, 4 }, { 8, 9 }
                    }
                }
            };
            Console.WriteLine($"Dimensions of array4: {arr4.Rank}\narr4 length: {arr4.LongLength}");
            
            // Binary search the array
            Console.WriteLine($"The element 3 in the array arr1 exist. ({(Array.BinarySearch(arr, 1) >= 0)})");
            Console.WriteLine($"The element 25 in the array arr1 exist. ({Array.BinarySearch(arr, 25) >= 0})\n\n");

            // Binary search the array using IComparer 
            int x = 6;
            int[] arr5 = { 1, 3, 6, 8, 9, 10 };
            int index = Array.BinarySearch(arr5, x, StringComparer.CurrentCulture);
            if(index < 0)
            {
                Console.WriteLine("The element {0} does not exist in the array.\n" +
                    "Next larger object is at index {1}", x, ~index);
            }
            else
            {
                Console.WriteLine("The element {0} exist in the array at index {1}", x, index);
            }

            x = 7;
            index = Array.BinarySearch(arr5, x, StringComparer.CurrentCulture);
            if (index < 0)
            {
                Console.WriteLine("The element {0} does not exist in the array.\n" +
                    "Next larger object is at index {1}", x, ~index);
            }
            else
            {
                Console.WriteLine("The element {0} exist in the array at index {1}", x, index);
            }

            // Set the default value of the array to 0 from givenIndex to number of element from that index
            Array.Clear(arr, 1, 3);
            printArr(arr);

            /*
                This is not the way to copy an array to another array in c#.
                If we assign an array to another array then both arrays will 
                point to the same array of element. So, if we change one array
                the difference will be created in another array.
            */
            /*arr = arr5;
            arr[0] = 568;
            Console.WriteLine(arr5[0]);*/

            // Copy elements of one array to another
            //arr.CopyTo(arr5, 0);
            //printArr(arr5);

            /// int[] arr5 = { 1, 3, 6, 8, 9, 10 };

            // Find element of an array based on given predicate 
            Console.WriteLine(Array.Find<int>(arr5, element => element > 6));

            // Index of element that is greater than 6
            Console.WriteLine(Array.IndexOf(arr5, Array.Find<int>(arr5, element => element > 6)));
        }
    }
}