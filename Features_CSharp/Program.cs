using System;
using System.Text;

namespace Features_CSharp
{
    // Delegate
    public delegate void Rectangle(double width, double height);
    class Delegate
    {
        public void getArea(double width, double height)
        {
            Console.WriteLine($"Area of Rectangle: {width * height}");
        }

        public void getPerimeter(double width, double height)
        {
            Console.WriteLine($"Perimeter of Rectangle: {2 * (width * height)}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Delegate delegateClassObject = new Delegate();
            Rectangle rectangle = new Rectangle(delegateClassObject.getArea);
            rectangle += delegateClassObject.getPerimeter;

            /*
             * 1. StringBuilder is used to change or modify the string without occupying
             *    extra memory space on the heap. If we change the original string without 
             *    StringBuilder then the string will create a new string object on the heap instead
             *    of modifying the original string at the same memory which will hinder the performance.
             * 2. StringBuilder is mutable but string is immutable 
             * 3. StringBuilder perform faster than string when appending multiple string values
             */

            // We can optionally specify the maximum capacity of the StringBuilder object using overloaded constructor
            // The capacity will automatically doubled once it reaches the specified capacity. 
            StringBuilder sb = new StringBuilder("Hello World!", 50);
            
            // The StringBuilder is not the string so, we have to use ToString() method to retrieve a string from the StringBuilder object

            Console.WriteLine(sb.ToString());

            // Iteration

            for (var i = 0; i < sb.Length; i++)          // sb.Length will return the length of the string and sb.Capacity will return the maximum capacity of the string
                Console.Write(sb[i]);
            Console.WriteLine();
            
            // Append 

            sb.Append(" 2021");                         // Append at the end of the string
            sb.AppendLine("/June-29");                  // Append and add a new line at the end of the string
            sb.AppendFormat("I have {0:C2}\n", 25);     // Format string and append it

            // Insert

            sb.Insert(5, " C# ");                       // Insert at fifth index 

            // Remove 

            sb.Insert(5, 4);                            // Remove string from fifst index of length 4

            // Replace

            sb.Replace("Hello", "Hi");                  // Replace 'Hello' with 'Hi' 

            Console.WriteLine(sb.ToString());
        }
    }
}
