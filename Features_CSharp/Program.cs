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

        static void Main(string[] args)
        {
            /*
             * 0. Switch expression are similar to switch statement
             * 1. It has three new patterns which are tuple pattern, property pattern and positional pattern.
             * 2. Tuple patttern allows us to leverage switch expression to swich on muliple values at the same time.
             * 3. 
             */

            var result = GetResult(Color.Blue, Brightness.VeryBright);
            Console.WriteLine($"Color {result}\nYou are going {ToOrientation(Direction.Left)} of the map");
        }
    }
}