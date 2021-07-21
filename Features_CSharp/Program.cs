using System;
using System.Collections.Generic;

namespace Features_CSharp
{
    public record RECORD
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }

    // Here, Class1 and Record1 is kind of similar 
    public record Record1(string FirstName, string LastName);
    
    public class Class1
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Class1(string FName, string LName)
        {
            FirstName = FName;
            LastName = LName;
        }

        public void Deconstruct(out string FirstName, out string LastName)
        {
            FirstName = this.FirstName;
            LastName = this.LastName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* 0. C# 9 introduces records, a new reference type that you can create instead 
             *    of classes or structs. Records are distinct from classes in that record 
             *    types use value-based equality.
             * 1. record keyword makes an object immutable and behave like a value type. 
             *    To make the whole object immutable you have to set init keyword on each property.
             * 2. Immutable means it cannot change. By default, Record types are immutable.
             * 3. Record acts like readonly class where we can not change the values or properties
             * 4. Two variables of a record type are equal if the record type definitions are 
             *    identical, and if for every field, the values in both records are equal. 
             * 5. A record cannot inherit a class or inherit from a clas but a record can inherit other records.  */

            Record1 recordObject1 = new("Tasnimul", "Alam");
            Record1 recordObject2 = new("Tasnimul", "Alam");
            Record1 recordObject3 = new("Sue", "Storm");

            Class1 classObject1 = new("Tasnimul", "Alam");
            Class1 classObject2 = new("Tasnimul", "Alam");
            Class1 classObject3 = new("Sue", "Storm");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Record Type: ");
            Console.WriteLine($"To String: { recordObject1 }");     // It overrides the to string method

            /* Two variables of a record type are equal if the record type definitions are identical, 
             * and if for every field, the values in both records are equal. */

            Console.WriteLine($"Are the two objects equal: { Equals(recordObject1, recordObject2) }");
            
            // Referece Compares the address or location of both objects
            Console.WriteLine($"Are the two objects equal: { ReferenceEquals(recordObject1, recordObject2) }");
            Console.WriteLine($"Are the two objects ==: { recordObject1 == recordObject2 }");

            // Here hash code of recordObject1 and recordObject2 will be similar because they have same values
            Console.WriteLine($"\nHash code of recordObject1: { recordObject1.GetHashCode() }");
            Console.WriteLine($"Hash code of recordObject2: { recordObject2.GetHashCode() }");
            Console.WriteLine($"Hash code of recordObject3: { recordObject3.GetHashCode() }");

            Console.WriteLine();

            // We deconstructed based on the same pattern of Record1(string FirstName, string LastName)
            var (fn, ln) = recordObject1;  
            Console.WriteLine($"The value of fn is { fn } and the value of ln is { ln }");

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine();
            Console.WriteLine("************************************");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Class Type: ");
            Console.WriteLine($"To String: { classObject1 }");

            /* Two variables of a class type are equal if the objects referred to are the same 
             * class type and the variables refer to the same object. */

            // Here, classObject1 and classObject2 are two different objects. 
            Console.WriteLine($"Are the two objects equal: { Equals(classObject1, classObject2) }");
            Console.WriteLine($"Are the two objects equal: { ReferenceEquals(classObject1, classObject2) }");
            Console.WriteLine($"Are the two objects ==: { classObject1 == classObject2 }");

            Console.WriteLine($"\nHash code of classObject1: { classObject1.GetHashCode() }");
            Console.WriteLine($"Hash code of classObject2: { classObject2.GetHashCode() }");
            Console.WriteLine($"Hash code of classObject3: { classObject3.GetHashCode() }\n\n");

            Console.ResetColor();

            // Override recordObject1 in newRecordObject
            Record1 newRecordObject = recordObject1 with
            {
                FirstName = "ABC"
            };

            Console.WriteLine(newRecordObject);
        }
    }
}