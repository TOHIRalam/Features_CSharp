using System;

namespace Features_CSharp
{
    abstract class MATH
    {
        public int x, y;
        public abstract int sum(int a, int b);
        public abstract int sub(int a, int b);
        public abstract int mul(int a, int b);
        public abstract int div(int a, int b);
        public void print()
        {
            Console.WriteLine(sum(x, y) + " " + sub(x, y) + " " + mul(x, y) + " " + div(x, y));
        }
    }

    class IMPL : MATH
    {
        public IMPL(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override int sum(int x, int y) => x + y;
        public override int sub(int x, int y) => x - y;
        public override int mul(int x, int y) => x * y;
        public override int div(int x, int y) => x / y;

    }
    class Program
    {
        static void Main(string[] args)
        {

            /*
                                     Access Modifier
                1. public: The code is accessible for all classes
                2. private: The code is only accessible within the same class 
                3. protected: The code is accessible within the same class or
                   in a class that is inherited from that class. 
                4. internal: The type or member can be accessed by any code in 
                   the same assembly, but not from another assembly.
             */

            /*
             *                         Abstract Class Info.
             * 
             * 1. Abstract class are the way to achieve abstraction, it hides 
             *    implementation detail showing functionality only.
             * 2. Abstract class can have abstract or non-abstract methods. 
             * 3. It can't be instantiated, implementation must be provided by derived class
             */
            
            IMPL imp = new IMPL(10, 5);
            imp.print();
        }
    }
}
