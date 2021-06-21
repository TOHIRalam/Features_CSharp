using System;

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

            rectangle.Invoke(17.77, 40.22);
        }
    }
}