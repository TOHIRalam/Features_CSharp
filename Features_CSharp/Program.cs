using System;

namespace Features_CSharp
{
    public class DATA
    {
        public int x_axis;
        public int y_axis;

        public DATA(int x, int y)
        {
            x_axis = x;
            y_axis = y;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Constructor of the base class called");
            Console.ResetColor();
        }

        public void print_data()
        {
            Console.WriteLine("Data");
        }
    }

    // Single level inheritance
    public class OPERATION : DATA
    {
        public OPERATION(int m, int n) : base(m, n)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Constructor of the operation class called");
            Console.ResetColor();
        }

        public int sum() => x_axis + y_axis;
        public int sub() => x_axis - y_axis;

        public void print_data(int x, int y)
        {
            x_axis += x + 2;
            y_axis += y + 2;
            Console.WriteLine(sum() + " " + sub());
        }
    }

    // Multi level inheritance
    public class PRINT : OPERATION
    {
        public PRINT(int m, int n) : base(m, n)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Constructor of the print class called");
            Console.ResetColor();
        }

        public void print_values()
        {
            print_data(10, 5);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PRINT pr = new PRINT(2, 2);
            pr.print_values();
        }
    }
}