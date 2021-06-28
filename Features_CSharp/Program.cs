using System;

namespace Features_CSharp
{
    struct Coordinate
    {
        public int x;
        public int y;
       
        // Constructor in struct
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Static constructor in struct
        public static Coordinate GetOrigin() => new Coordinate();

        public int X
        {
            get => x;
            set { x = value; }
        }

        public int Y
        {
            get => y;
            set { y = value; }
        }
    }

    // A struct can contain events to notify subscribers about some action
    struct EventCoordinate
    {
        private int _x, _y;
        public int x
        {
            get => _x;
            set
            {
                _x = value;
                CoordinatesChanged(_x);
            }
        }

        public int y
        {
            get => _y;
            set
            {
                _y = value;
                CoordinatesChanged(_y);
            }
        }

        public event Action<int> CoordinatesChanged;
    }

    class Program
    {
        static void StructEventHandler(int point) => Console.WriteLine($"EventCoordinate changed to {point}");
        static void Main(string[] args)
        {
             /*
                1. struct is the value type data type that represents data structures.
                2. It can contain parameterized constructor, static constructor, constants, 
                   fields, methods, properties, indexers, operators, events, and nested types.
                3. It can be used to hold small data values that do not require inheritance. 
             */

            // A struct object can be created with or without the new operator, same as primitive type variables
            
            Coordinate point = new Coordinate();
            Console.WriteLine($"Point x: {point.x}\n" +
                $"Point y: {point.y}");

            /* 
               Above, an object of the Coordinate structure is created using the new keyword.
               It calls the default prameterless constructor of the struct, which initializes 
               all the members to their default value of the specified data type.
                
               If we declare a variable of struct type without using the new keyword then it does
               not call any constructor, so all the members remain unassigned. Therefor, we must 
               assign values to each member before accessing them, otherwise, 
               it will give compile-time error. 
            */

            Coordinate coordinate;

            coordinate.x = 0;
            coordinate.y = 0;

            Console.WriteLine($"Coordinate x: {coordinate.x}\n" +
                $"Coordinate y: {coordinate.y}");

            Coordinate point_2 = Coordinate.GetOrigin();
            Console.WriteLine($"Point_2 x: {point_2.x}\nPoint_2 y: {point_2.y}");

            // The above structure contains CoordinatesChanged event, which will be raised when x or y coordinate changes
            EventCoordinate e = new EventCoordinate();
            e.CoordinatesChanged += StructEventHandler;
            e.x = 10; e.y = 20;
        }
    }
}