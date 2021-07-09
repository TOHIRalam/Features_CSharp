using System;

namespace Features_CSharp
{
    class Program
    {
        public int X = 19;
        public int Y = 34;
        static void Main(string[] args)
        {
            /* 0. Nameapce is a collection of classes and classes are collection of objects
             *    and methods. Using namespace we can easily access all the classes and 
             *    methods just by importing the namespace in our application.
             * 1. Namespace is used to organize the multiple classes in our application,
             *    reducing the code redundancy in our .NET applications. By using namepace
             *    keyword, we can define the namespaces in our applications. 
             * 2. A namespace is designed for providing a way to keep one set of names seperate
             *    from another. The class names declared in one namespace doesn't conflict with 
             *    the same class names declared in another. 
             * 3. We import the System namespace in our application and use the associated classes
             *    and methods with using keyword. 
             *    
             *                         Various namespaces of .NET Frameword
             *                         ------------------------------------
             * 1) System: It contains classes that allows to perform basic operations 
             *            such as mathematical and data conversion.
             * 2) System.IO: It contains classes to perform Input and Output operations. 
             * 3) System.Net: It contains classes that are useful to network protocols.
             * 4) System.Data: It contains classes that are useful to work with ADO.Net architecture.
             * 5) System.Collection: It contains classes that are useful to implement tha collection 
             *                       of objects, such as lists.
             * 6) System.Drawing: It contains classes that are useful to implement GUI functionalities.
             * 7) System.Web: It contains classes that are helpful to perform HTTP requests. */


            Program p1 = new Program();
            Namespace1_CSharp.Program p2 = new Namespace1_CSharp.Program();
            Namespace2_CSharp.Namespace1_CSharp.Program p3 = new Namespace2_CSharp.Namespace1_CSharp.Program();
            p2.X = 10; p2.Y = 20;
            p3.X = 11; p3.Y = 12;
            Console.WriteLine(p1.X + ":X p1 Y:" + p1.Y + "\n" + p2.X + ":X p2 Y:" + p2.Y + "\n" + p3.X + ":X p3 Y:" + p3.Y);
        }
    }
}

// Namespace
namespace Namespace1_CSharp
{
    class Program
    {
        private int _x, _y;
        public int X { get => _x; set { _x = value; } }
        public int Y { get => _y; set { _y = value; } }
    }
}

// Nested Namespace
namespace Namespace2_CSharp
{
    namespace Namespace1_CSharp
    {
        class Program
        {
            private int _x, _y;
            public int X { get => _x; set { _x = value; } }
            public int Y { get => _y; set { _y = value; } }
        }
    }
}