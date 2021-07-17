using System;

namespace Features_CSharp
{
    class Program
    {
        // Tuple as a method parameter
        static void DisplayTuple(Tuple<int, string, string> person)
        {
            Console.WriteLine($"Id = { person.Item1}");
            Console.WriteLine($"First Name = { person.Item2}");
            Console.WriteLine($"Last Name = { person.Item3}");
        }

        static Tuple<int, string, string> GetPerson() => Tuple.Create(1, "Bill", "Gates");

        static Object PersonData(int id, string str1, string str2) => new { pid = id, FName = str1, LName = str2 };

        // Cast object to anonymous type
        static T Cast<T>(object obj, T type) => (T)obj;

        static void Main(string[] args)
        {
            /* 1. A tuple is a data structure that contains a sequence of elements of different data types.
             * 2. Before tuples, we have three ways to return more than one value from the method in C# 
             *    which are Using Class or Struct types, Out parameters and Anonymous types which returned
             *    through a Dynamic Return Type. But after Tuples, it becomes easy to represent a single set of data.
             * 3. It allows us to represent multiple data into a single data set.
             * 4. It allows us to create, manipulate, and access data set.
             * 5. It return multiple values from a method without using out parameter.
             * 6. It can also store duplicate elements.
             * 7. It allows us to pass multiple values to a method with the help of single parameters. 
             * 8. We can use tuple when we want to hold database record or some values temporarily without creating a separate class.
             * 
             *                                          Limitations
             *                                         -------------
             * 1. The Tuple is a reference type and not a value type. It allocates on heap and could result in CPU intensive operations.
             * 2. The Tuple is limited to include eight elements. We need to use nested tuples if we need to store more elements. 
             * 3. The Tuple elements can be accessed using properties with a name pattern Item<elementNumber>, which does not make sense. */

            // Create a tuple with three elements
            Tuple<int, string, string> person1 = new Tuple<int, string, string>(1, "Tasnimul", "Alam");

            // C# includes a static helper class Tuple, which returns an instance of the Tuple<T> without specifying each element's type, as shown below.
            var person2 = Tuple.Create(1, "Steve", "Jobs");

            // A tuple can only include a maximum of eight elements.
            var numbers = Tuple.Create(1, 2, 3, 4, 5, 6, 7, 8);

            Console.WriteLine($"Name: {person1.Item2} {person1.Item3}");

            // numbers.Rest returns (8) and numbers.Rest.Item1 returns 8
            Console.WriteLine($"ID: {person1.Item1}{numbers.Rest.Item1}");

            // Nested tuples
            var nums = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8, 9, 10, 11, 12, 13));
            Console.WriteLine(nums.Item1); // returns 1
            Console.WriteLine(nums.Item7); // returns 7
            Console.WriteLine(nums.Rest.Item1); //returns (8, 9, 10, 11, 12, 13)
            Console.WriteLine(nums.Rest.Item1.Item1); //returns 8
            Console.WriteLine(nums.Rest.Item1.Item2); //returns 9

            // Accessing the method
            var person = Tuple.Create(1, "Steve", "Jobs");
            DisplayTuple(person);

            // Returned tuple 
            var personData = GetPerson();
            Console.WriteLine(personData.Item3);

            var personData2 = Cast(PersonData(1, "Steve", "Jobs"), new { pid = 0, FName = "", LName = "" });
            Console.WriteLine(personData2.FName);
        }
    }
}