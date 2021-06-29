using System;
using System.Collections.Generic;
using System.Linq;

namespace Features_CSharp
{
    // Delegate
    public delegate void Rectangle(double width, double height);
    class Delegate
    {
        public void getArea(double width, double height)
        {
            Console.WriteLine($"Area of Rectangle: {width * height}");
        }

        public void getPerimeter(double width, double height)
        {
            Console.WriteLine($"Perimeter of Rectangle: {2 * (width * height)}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. C# anonymous type is a type (class) without any name that can contain public
             *    read-only properties only. It cannot contain other members, such as fields or events, etc.
             * 2. Properties of anonymous types are read-only and cannot be initialized with null, anonymous
             *    function, or a pointer type.
             * 3. The properties can be accessed using dot (.) notation, same as object properties.
             * 4. We cannot change the value of the properties as they are read-only.
             * 5. An anonymous type will always be local to the method where it is defined,
             *    it cannot be returned from the method.
             * 6. An anonymous type can be passed to the method as object type parameter, but not recommended.
             *    If we have to pass anonymous type to the method then we can use struct or class intead.
             * 7. Mostly, anonymous types are created using the Select clause of a LINQ quries to return 
             *    a subset of the properties from each object in the collection.
             * 8. Internally, all anonymous types are directly derived from the System.Object class
             * 9. The compiler generates a class with some auto-generated nameand applies the appropriate type 
             *    to each property based on the value expression. 
             */

            // Anonymous type
            var student = new { Id = 1, FirstName = "Tasnimul", LastName = "Alam" };
            Console.WriteLine($"Name: {student.FirstName + " " + student.LastName}");

            // Nested anonymous type
            var student_info = new
            {
                id = 1,
                firstName = "Tasnimul",
                lastName = "Alam",
                address = new
                {
                    area = "Mirpur",
                    city = "Dhaka",
                    country = "Bangladesh"
                }
            };

            Console.WriteLine($"Name: {student_info.firstName} {student_info.lastName}\n" +
                $"Address: {student_info.address.area}, {student_info.address.city}, {student_info.address.country}");

            // Array of anonymous type 
            var students = new[] {
                new { id = 1, firstName = "Tasnimul", lastName = "Alam" },
                new { id = 2, firstName = "John", lastName = "Alter" }
            };

            foreach (var i in students)
                Console.WriteLine(i.id + ", " + i.firstName + " " + i.lastName);

            // LINQ Query returns an anonymous type
            IList<Student> studentList = new List<Student>() { 
                new Student() { StudentID = 1, StudentName = "Tasnimul Alam", age = 24 },
                new Student() { StudentID = 2, StudentName = "John Alter", age = 399 }
            };

            var studentQuery = from s in studentList 
                               select new { Id = s.StudentID, Name = s.StudentName };

            foreach (var i in studentQuery)
                Console.WriteLine(i.Id + " " + i.Name);
        }

        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int age { get; set; }
        }
    }
}