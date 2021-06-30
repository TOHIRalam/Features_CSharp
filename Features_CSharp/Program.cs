using System;

namespace Features_CSharp
{
    class Program
    {
        // Assignment is not necessary as 'yt' is a global variable
        public Nullable<int> yt;
        static void Main(string[] args)
        {
            /*
             * 1. A dynamic type escapes type checking at compile-time;
             *    instead it resolves type at run time.
             * 2. The compiler compiles dynamic types into object types in most cases.
             *    However, the actual type of dynamic type variable would be resolved at run-time.
             * 3. Dynamic types change types at run-time based on the assigned value.
             * 4. If we assign a class object to the dynamic type then the compiler would not check
             *    for correct methods and properties name of a dynamic type that holds the custom class object.
             */

            dynamic myDynamic = 10;
            Console.WriteLine($"{myDynamic} {myDynamic.GetType()}");
            myDynamic = "Hello World!";
            Console.WriteLine($"{myDynamic} {myDynamic.GetType()}");
            myDynamic = true;
            Console.WriteLine($"{myDynamic} {myDynamic.GetType()}");
            myDynamic = DateTime.Now;
            Console.WriteLine($"{myDynamic} {myDynamic.GetType()}");

            /*
             * 1. As we cannot assigne a null value to a value type for example; int i = null
             *    we can assign a null value through nullable types.
             * 2. A nullable of type int is the same as an ordinary int plus a flag that says 
             *    whether the int has a value or not (is null or not). All the rest is compiler 
             *    magic that treats "null" as a valid value.
             * 3. We can use the '?' operator to shorthand the e.g. int?, long? instead of using Nullable<T>.
             * 4. We can use the '??' operator to assign a nullable to a non-nullable type.
             * 5. If nullable types are declared in a function as local variable it must be assigned a value before using it.
             */

            Nullable<int> i = null;
            if(!i.HasValue)
                i = new Random().Next(10, 20);
            Console.WriteLine(i);

            // Shorthand Syantax

            int? j = null;   // Same as; Nullable <int> j = null

            int m = j ?? 0;  // If value of j is null assign m to zero otherwise assign the value of j
            j = 10;
            int n = j ?? 0;  // The value of j is not null here so n = 10
            Console.WriteLine($"m: {m}\nn: {n}");

            // Nullable static class is a helper class that provides a compare method to compare nullable types
            
            // We can only use == or != operator with nullable type, for other comparison we have to use Nullable static class

            int? k = null;
            m = 10;

            // Without nullable compare

            if (k < m)
                Console.WriteLine("k(null) < m(10)");
            else
                Console.WriteLine("Could not compare");

            // With nullable compare

            if (Nullable.Compare<int>(k, m) < 0)
                Console.WriteLine("k(null) < m(10)");
            else
                Console.WriteLine("Could not compare");
        }
    }
}