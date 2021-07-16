using System;

namespace Features_CSharp
{
    class Rectangle
    {
        private int _length;
        private int _width;

        public int Length {
            get => _length;
            set => _length = value;
        }

        public int Width
        {
            get => _width;
            set => _width = value;
        }

        public static int operator +(Rectangle lhs, Rectangle rhs) => (lhs.Length * lhs.Width) + (rhs.Length * rhs.Width);
        public static bool operator >(Rectangle lhs, Rectangle rhs) => (lhs.Length * lhs.Width) > (rhs.Length * rhs.Width);
        public static bool operator <(Rectangle lhs, Rectangle rhs) => (lhs.Length * lhs.Width) < (rhs.Length * rhs.Width);
        public static bool operator ==(Rectangle lhs, Rectangle rhs) => (lhs.Length * lhs.Width) == (rhs.Length * rhs.Width);
        public static bool operator !=(Rectangle lhs, Rectangle rhs) => (lhs.Length * lhs.Width) != (rhs.Length * rhs.Width);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* 1. Overloaded operators are functions with special names the keyword 
             *    operator followed by the symbol for the operator being defined. 
             *    similar to any other function, an overloaded operator has a return 
             *    type and a parameter list.
             * 2. The conditional logical operators (&&, ||) cannot be overloaded directly.
             * 3. The assignment operators (+=, -=, *=, /=, %=) cannot be overloaded.
             * 4. (=, ., ?:, ->, new, is, sizeof, typeof) these operators can't be overloaded. 
             * 5. The general form of operator function for unary operators is as follows: 
             *    public static return_type operator op (Type t){ } where type must be a class or struct.
             * 6. Operator overload methods can't return void.
             * 7. User defined operator implementations are given preference over predefined implementations. */

            Rectangle rect1 = new Rectangle();
            Rectangle rect2 = new Rectangle();

            rect1.Length = 10;
            rect1.Width = 10;

            rect2.Length = 20;
            rect2.Width = 20;

            Console.WriteLine($"First rectangle largest? ({rect1 > rect2})");
            Console.WriteLine($"Both rectangle same? ({rect1 == rect2})");
            Console.WriteLine($"Sum of the area of both rectangle is ({rect1 + rect2})");
        }
    }
}