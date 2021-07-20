using System;

namespace Features_CSharp
{
    class Program
    {
        enum Color { Red, Green, Blue }
        enum Direction { Up, Down, Left, Right }
        enum Orientation { North, South, East, West }
        enum Brightness { NotBright, VeryBright }

        private static string GetResult(Color color, Brightness brightness)
        {
            // Switch statement
            /*switch (color)
            {
                case Color.Red:
                    return "Red";
                case Color.Green:
                    return "Green";
                case Color.Blue:
                    return "Blue";
                default:
                    break;
            }
            return "Failed-Condition!";*/


            /*         Switch expression (Tuple Pattern)
             * Here we can switch on both the color and brightness 
             * by treating them as tuple, this is tuple pattern.
             */
            return (color, brightness) switch
            {
                (Color.Red, Brightness.VeryBright) => "Bright Red",
                (Color.Green, Brightness.VeryBright) => "Bright bright Green",
                (Color.Blue, Brightness.VeryBright) => "Bright Blue",
                (Color.Red, Brightness.NotBright) => "Not Bright Red",
                (Color.Green, Brightness.NotBright) => "Not Bright bright Green",
                (Color.Blue, Brightness.NotBright) => "Not Bright Blue",
                _ => "Failed-Condition!" // default 
            };
        }

        private static Orientation ToOrientation(Direction direction) => direction switch
        {
            Direction.Up => Orientation.North,
            Direction.Down => Orientation.South,
            Direction.Left => Orientation.West,
            Direction.Right => Orientation.East,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value {direction}")
        };

        // Property Pattern
        public class CalculateMultipleProperty
        {
            public string multiplyBy { get; set; }
            public bool isAdditionApplicable { get; set; }
        }

        public static void ExecutePropertyPattern()
        {
            CalculateMultipleProperty calculate = new CalculateMultipleProperty { multiplyBy = "5 times", isAdditionApplicable = true };
            Console.WriteLine($"Result: {ComputeOverallPrice(calculate, 10M)}");
        }

        private static decimal ComputeOverallPrice(CalculateMultipleProperty calculate, decimal price) => calculate switch
        {
            { multiplyBy: "10 times", isAdditionApplicable: true } => 10 * price + 100,
            { multiplyBy: "5 times", isAdditionApplicable: true } => 5 * price + 50,
            { multiplyBy: "20 times", isAdditionApplicable: true } => 20 * price + 70,
            _ => 0M
        };

        // Positional Pattern

        public readonly struct Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) => (X, Y) = (x, y);

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        }

        static string Classify(Point point) => point switch
        {
            (0, 0) => "Origin",
            (1, 0) => "positive X basis end",
            (0, 1) => "positive Y basis end",
            _=> "Just a point"
        };

        static void Main(string[] args)
        {
            /*
             * 0. Switch expression are similar to switch statement
             * 1. It has three new patterns which are tuple pattern, property pattern and positional pattern.
             * 2. Tuple patttern allows us to leverage switch expression to swich on muliple values at the same time.
             * 3. The positional pattern leverages the deconstruct method that we have on our class. We can express a 
             *    pattern that matches given values that we get our the deconstructor. 
             * 4. The property pattern enables us to match on properties of the object examined. It matches an expression
             *    when an expression result is non-null and every nested pattern matches the corresponding property
             *    of field of the expression result. 
             */

            var result = GetResult(Color.Blue, Brightness.VeryBright);
            Console.WriteLine($"Color {result}\nYou are going {ToOrientation(Direction.Left)} of the map");
        }
    }
}
