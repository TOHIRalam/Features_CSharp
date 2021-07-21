using System;

namespace Features_CSharp
{
    public interface IDefault
    {
        int sum(int a, int b);
        int sub(int a, int b);

        // Default interface method
        public void display()
        {
            Console.WriteLine("Hello world");
        }
    }

    class IMP : IDefault
    {
        public int sum(int a, int b) => a + b;
        public int sub(int a, int b) => a - b;

    }

    class Program
    {
        static void Main(string[] args)
        {
            IMP imp = new();
            Console.WriteLine(imp.sum(1, 2) + "\n" + imp.sub(2, 1));

            // Using the default implementation 
            IDefault def = new IMP();
            def.display();
        }
    }
}