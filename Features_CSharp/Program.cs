using System;

namespace Features_CSharp
{
    class A
    {
        public void Print()
        {
            Console.WriteLine("Base Class");
        }
    }

    class B : A
    {
        public void Print()
        {
            Console.WriteLine("Derived Class");
        }
    }

    class C
    {
        public void Print()
        {
            Console.WriteLine("Base Class");
        }
    }

    class D : C
    {
        public new void Print()
        {
            Console.WriteLine("Derived Class");
        }
    }

    class E
    {
        public virtual void Print()
        {
            Console.WriteLine("Base Class");
        }
    }

    class F : E
    {
        public override void Print()
        {
            Console.WriteLine("Derived Class");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* 0. For hiding the base class method from derived class simply declare the derived class method 
             *    with a new keyword. In this way the base class method will be hidden from the derived class.
             *                    
             *                    Difference between method overriding & method hiding
             *                    ----------------------------------------------------
             * 
             * 1. The "override" modifier extends the base class method, and the "new" modifier hides it.
             * 2. The "virtual" keyword modifies a method, property, indexer, or event declared in the base 
             *    class and allows it to be overridden in the derived class.
             * 3. The "override" keyword extends or modifies a virtual/abstract method, property, indexer, 
             *    or event of the base class into the derived class.
             * 4. The "new" keyword is used to hide a method, property, indexer, or event of the base class 
             *    into the derived class.
             * 5. If a method is not overriding the derived method then it is hiding it. A hiding method 
             *    must be declared using the new keyword.
             * 6. Shadowing is another commonly used term for hiding. The C# specification only uses "hiding" 
             *    but either is acceptable. Shadowing is a VB concept. */

            #region Without the 'new' keyword
            Console.WriteLine("\nWithout the 'new' keyword\n");

            
            A a = new A();
            a.Print();                   // From class A

            B b = new B();
            b.Print();                   // From class B

            A ab = new B();
            ab.Print();                  // From class A

            #endregion

            // B ba = new A();            // Error: We cannot give the parent reference to the child 

            /* There will be no difference in the output whether we add the new keyword or not but without the new keyword the 
             * compiler will implicitly hide the derived method 'Print()' but we are hiding the method explicitly with the new keyword. */

            #region With the 'new' keyword
            Console.WriteLine("\nWith the 'new' keyword\n");

            C c = new C();
            c.Print();

            D d = new D();
            d.Print();

            C cd = new D();
            cd.Print();

            #endregion

            #region With Virtual & Override keyword
            Console.WriteLine("\nWith Virtual & Override keyword\n");

            E e = new E();
            e.Print();

            F f = new F();
            f.Print();

            E ef = new F();
            ef.Print();
            #endregion
        }
    }
}