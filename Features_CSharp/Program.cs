using System;

namespace Features_CSharp
{
    public class SHAPE
    {
        public const double PI = Math.PI;
        protected double x, y;

        public SHAPE() { }
        public SHAPE(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual double Area() => x * y;
    }

    public class CIRCLE : SHAPE
    {
        public CIRCLE(double raidus) : base(raidus, 0) { }
        public override double Area() => PI * x * x;
    }

    public class SPHERE : SHAPE
    {
        public SPHERE(double r) : base(r, 0) { }

        public override double Area() => 4 * Math.PI * x * x;
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* 1. The virtual keyword is useful to override base class members such as 
             *    properties, methods etc. in the derived class to modify it based on our requirements.
             * 2. When a virtual method is invoked, the run-time type of the object is checked
             *    for an overriding member. The overriding member in the most derived class is called,
             *    which might be the original member, if no derived class has overriden the member.
             * 3. By default methods are non-virtual. We cannot override a non virtual method.
             * 4. We cannot use the virtual modifier with the static, abstract, private or override modifiers.
             * 5. Virtual properties behave like virtual methods, except for the difference in declaration and invokation
             *      a) It is an error to use the virtual modifier on a static property.
             *      b) A virtual inherited property can be overridden in a derived class by including 
             *         a property declaration that uses the override modifier. */

            double r = 3.0, h = 5.0;
            SHAPE c = new CIRCLE(r);
            SHAPE s = new SPHERE(r);
            // Display results.
            Console.WriteLine("Area of Circle   = {0:F2}", c.Area());
            Console.WriteLine("Area of Sphere   = {0:F2}", s.Area());
        }
    }
}