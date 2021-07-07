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

        public void print_data(int x, int y, int z)
        {
            x_axis += x;
            y_axis += y;
            Console.WriteLine($"R1({x} + {x_axis-x})...R2({y} + {y_axis-y})\nR1 + R2 = {sum()}\nR1 - R2 = {sub()}");
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

    // Hierarchical Inheritance
    public class PRINT2 : DATA
    {
        public PRINT2(int m, int n) : base(m, n)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Constructor of the print2 class called");
            Console.ResetColor();
        }

        public void print_values() => print_data();
    }

    // Multiple Inheritance
    interface RANDOM_GENERATE_1
    {
        public int random_number_1(int x, int y);
    }

    interface RANDOM_GENERATE_2
    {
        public int random_number_2(int x, int y);
    }

    class SUM_OF_RANDOMS : PRINT, RANDOM_GENERATE_1, RANDOM_GENERATE_2
    {
        public int random_number_1(int x, int y) => new Random().Next(x, y);
        public int random_number_2(int x, int y) => new Random().Next(x, y);

        public SUM_OF_RANDOMS(int x, int y) : base(x, y)
        {
            x_axis = x; y_axis = y;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"x: {x_axis} | y: {y_axis-1} | SUM_OF_RANDOMS class called");
            Console.ResetColor();
        }

        public new void print_values() => print_data(random_number_1(x_axis, y_axis), random_number_2(x_axis, y_axis), 0);
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* 1. In C#, inheritance is a process in which one object acquires all the properties 
             *    and behaviors of its parent object automatically.
             * 2. The class which inherits the members of another class is called derived class
             * 3. The class whose members are inherited is called base class, derived class is the 
             *    specialized class for the base class. 
                 
             * 4. Single Level Inheritance: When one class inherits another class. (base <- derived) 
             * 5. Multi level Inheritance: When one class inherits another class which is further 
             *    inherited by another class, it is known as multi level inheritance. (base<-derived(base2)<-derived)
             * 6. Hierarchical Inheritance: When more than one class is inherited from
             *    a single parent or base class. (derived -> base <- derived) 
             * 7. Multiple Inheritance: When a class inherits features and characteristics from
             *    more than one base class. (base <- derived -> base)
             *    
             * 8. C# deos not support multiple inheritance, but with interface we can achieve multiple inheritance. */


            Console.WriteLine("PRINT pr = new PRINT(2, 2)\npr.print_values()\n");

            PRINT pr = new PRINT(2, 2);
            pr.print_values();

            Console.WriteLine("\nnew SUM_OF_RANDOMS(1, 11).print_values()\n");

            new SUM_OF_RANDOMS(1, 11).print_values();
        }
    }
}                        