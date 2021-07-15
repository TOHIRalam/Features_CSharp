using System;

namespace Features_CSharp
{
    class Box
    {
        private double length;   // Length of a box
        private double breadth;  // Breadth of a box
        private double height;   // Height of a box

        public double getVolume()
        {
            return length * breadth * height;
        }
        public void setLength(double len)
        {
            length = len;
        }
        public void setBreadth(double bre)
        {
            breadth = bre;
        }
        public void setHeight(double hei)
        {
            height = hei;
        }

        // Overload + operator to add two Box objects.
        public static Box operator +(Box b, Box c)
        {
            Box box = new Box();
            box.length = b.length + c.length;
            box.breadth = b.breadth + c.breadth;
            box.height = b.height + c.height;
            return box;
        }
    }

    // With virtual function 
    class Shapes
    {
        protected int width, height;

        public Shapes(int a = 0, int b = 0)
        {
            width = a;
            height = b;
        }
        public virtual int area()
        {
            Console.WriteLine("Parent class area :");
            return 0;
        }
    }
    class Rectangles : Shapes
    {
        public Rectangles(int a = 0, int b = 0) : base(a, b)
        {

        }
        public override int area()
        {
            Console.WriteLine("Rectangle class area :");
            return (width * height);
        }
    }
    class Triangle : Shapes
    {
        public Triangle(int a = 0, int b = 0) : base(a, b)
        {
        }
        public override int area()
        {
            Console.WriteLine("Triangle class area :");
            return (width * height / 2);
        }
    }
    class Caller
    {
        public void CallArea(Shapes sh)
        {
            int a;
            a = sh.area();
            Console.WriteLine("Area: {0}", a);
        }
    }

    // With abstract class
    abstract class Shape
    {
        public abstract int area();
    }

    class Rectangle : Shape
    {
        private int length;
        private int width;

        public Rectangle(int a = 0, int b = 0)
        {
            length = a;
            width = b;
        }
        public override int area()
        {
            Console.WriteLine("Rectangle class area :");
            return (width * length);
        }
    }

    class Program
    {
        void print(int i)
        {
            Console.WriteLine("Printing int: {0}", i);
        }
        void print(double f)
        {
            Console.WriteLine("Printing float: {0}", f);
        }
        void print(string s)
        {
            Console.WriteLine("Printing string: {0}", s);
        }
        static void Main(string[] args)
        {
            /* 1. The word polymorphism means having many forms. In object-oriented programming paradigm,
             *    polymorphism is often expressed as 'one interface, multiple functions'.
             * 2. Polymorphism can be static or dynamic. In static polymorphism, the response to a function 
             *    is determined at the compile time. In dynamic polymorphism, it is decided at run-time.
             *    
             *                                  Static Polymorphism
             *                                 ---------------------
             * #) The mechanism of linking a function with an object during compile time is called early binding. 
             *    It is also called static binding. C# provides two techniques to implement static polymorphism. They are −
             *         
             *         1> Function overloading: We can have multiple definition for the same function name in 
             *            the same scope. The definition of the function must differ from each other by the types 
             *            and/or the number of arguments. We cannot differ from function declarations that differ
             *            only by return type.
             *             
             *          2> Operator overloading: We can redefine or overload most of the built-in operators available. So, 
             *             we can use operators with user-defined types as well. Overloaded operators are functions with 
             *             special names the keyword operator followed by the symbol for the operator being defined. Similar
             *             to anyother function, an overloaded operator has a return type and a parameter list. 
             *  
             *                                  Dynamic Polymorphism
             *                                 ----------------------
             * #) C# allows you to create abstract classes that are used to provide partial class implementation of 
             *    an interface. Implementation is completed when a derived class inherits from it. Abstract classes contain 
             *    abstract methods, which are implemented by the derived class.
             * #) When you have a function defined in a class that you want to be implemented in an inherited class(es), you 
             *    use virtual functions. The virtual functions could be implemented differently in different inherited class 
             *    and the call to these functions will be decided at runtime. Dynamic polymorphism is implemented by abstract 
             *    classes and virtual functions. */

            Program p = new Program();

            // Call print to print integer
            p.print(5);

            // Call print to print float
            p.print(500.263);

            // Call print to print string
            p.print("Hello C++");
            Console.ReadKey();

            //*** For abstract class
            Rectangle r = new Rectangle(10, 7);
            double a = r.area();
            Console.WriteLine("Area: {0}", a);
            Console.ReadKey();

            //*** For the virtual function
            Caller c = new Caller();
            Rectangles rs = new Rectangles(10, 7);
            Triangle ts = new Triangle(10, 5);

            c.CallArea(rs);
            c.CallArea(ts);
            Console.ReadKey();

            //*** For operator overloading 
            Box Box1 = new Box();   // Declare Box1 of type Box
            Box Box2 = new Box();   // Declare Box2 of type Box
            Box Box3 = new Box();   // Declare Box3 of type Box
            double volume = 0.0;    // Store the volume of a box here

            // box 1 specification
            Box1.setLength(6.0);
            Box1.setBreadth(7.0);
            Box1.setHeight(5.0);

            // box 2 specification
            Box2.setLength(12.0);
            Box2.setBreadth(13.0);
            Box2.setHeight(10.0);

            // volume of box 1
            volume = Box1.getVolume();
            Console.WriteLine("Volume of Box1 : {0}", volume);

            // volume of box 2
            volume = Box2.getVolume();
            Console.WriteLine("Volume of Box2 : {0}", volume);

            // Add two object as follows:
            Box3 = Box1 + Box2;

            // volume of box 3
            volume = Box3.getVolume();
            Console.WriteLine("Volume of Box3 : {0}", volume);
            Console.ReadKey();
        }
    }
}