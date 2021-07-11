using System;

namespace Features_CSharp
{
    // Sealed class demonstration 
    sealed class SUM
    {
        public int Add(int a, int b) => a + b;
    }

    // Sealed method demonstration 
    class BaseClass
    {
        public virtual void Print()
        {
            Console.WriteLine("World!");
        }
    }

    class DerivedClass : BaseClass
    {
        public override sealed void Print()
        {
            Console.WriteLine("Hello World!");
        }
    }

    /*
        class SecondDerivedClass : DerivedClass
        {
            // Error
            public override void Print()
            {
                Console.WriteLine("Hello");
            }
        }
    */

    class SecondDerivedClass : BaseClass
    {
        public override void Print()
        {
            Console.WriteLine("Hello");
        }
    }

    // Error
    /*
        class XYZ : SUM
        {

        }
    */

    class Program
    {
        static void Main(string[] args)
        {
            /* 0. Sealed classes is used to stop class to be inherited and sealed method is
             *    implemented so that no other class can overthrow it and implement its own method. 
             * 1. The sealed classes are used to restrict the users from inheriting the class. 
             * 2. A class can be sealed by using the sealed keyword, the keyword tells the 
             *    compiler that the class is sealed and therefor cannot be extended. So, no class
             *    can be derived from sealed class.
             * 3. A method can be sealed, and in that case the method cannot be overriden. However, 
             *    a method can be sealed in the classes in which they have been inherited. I we have
             *    to declare a method as sealed then it has to be declared as virtual in its base class. */

            Console.WriteLine(new SUM().Add(5, 6));
        }
    }
}