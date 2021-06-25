using System;

namespace Features_CSharp
{
    // Delegates
    public delegate double CircleDelegate(double radius);
    public delegate void RectangleDelegate(double width, double height);
    public delegate T TriangleDelegate<T>(T value1, T value2); // Generic delegate
    class Rectangle
    {
        public void getArea(double width, double height)
        {
            Console.WriteLine($"Area of Rectangle: {(width * height):F2}");
        }

        public void getPerimeter(double width, double height)
        {
            Console.WriteLine($"Perimeter of Rectangle: {2 * (width * height):F2}");
        }
    }

    class Circle
    {
        public double area(double radius) => Math.PI * radius * radius;
        public double circumference(double radius) => 2 * Math.PI * radius;
    }

    class Triangle
    {
        public double area(double b, double h) => (b * h) / 2;
        public string Name(string name, string type) => name + " " + type;
    }

    class Program
    {
        // Pass delegate as an argument
        public void invokeDelegateCircle(double radius, CircleDelegate circleDelegate) => Console.WriteLine($"" +
            $"The {circleDelegate.Method.Name} of the circle is {circleDelegate.Invoke(radius):F2}");
        static void Main(string[] args)
        {
            /*
                1. C# delegates are similar to pointers to functions, a delegate is a reference type 
                   variable that holds the reference to a method. 
                2. Delegates are especially used for implementing events and the call-back methods.
                3. There are three steps involved while working with delegates:
                        a) Declare a delegate
                        b) Set a target method
                        c) Invoke a delegate
                4. When a delegate that points to multiple method is called multicast delegate
                5. If a delegate returns a value then the last assigned target method's value will be returned.
                6. A delegate that is defined by using generic parameter or return type is called generic delegate.
                7. Delegate is used to declare an event and anonymous method in C#.
             */

            // We can set the target method or a lambda expression in following ways
            Rectangle rectangle = new Rectangle();
            //RectangleDelegate delegateObject2 = rectangle.getArea;
            RectangleDelegate delegateObject = new RectangleDelegate(rectangle.getArea);
            delegateObject += rectangle.getPerimeter;
            delegateObject += (double x, double y) => Console.WriteLine($"Width of the rectangle: {x:F2}\n" +
                $"Height of the rectangle: {y:F2}");
            delegateObject.Invoke(17.77, 23.33);
            // We can also invoke like: delegateObject(17.77, 23.33);

            Circle circle = new Circle();
            CircleDelegate circleDelegate = new CircleDelegate(circle.area) + new CircleDelegate(circle.circumference);
            // The code bellow will return the circumference of the circle as it is the last assigned target method
            new Program().invokeDelegateCircle(5.32, circleDelegate);
            circleDelegate = circleDelegate - circle.circumference;
            new Program().invokeDelegateCircle(5.32, circleDelegate);

            // Invoking generic delegate
            Triangle triangle = new Triangle();
            TriangleDelegate<string> triangleInfo = new TriangleDelegate<string>(triangle.Name);
            Console.WriteLine($"\nThis is {triangleInfo.Invoke("Equilateral", "Triangle")}");
            Console.WriteLine($"Area of the triangle is " +
                $"{new TriangleDelegate<double>(triangle.area).Invoke(4.4, 4.0):F2}");
        }
    }
}