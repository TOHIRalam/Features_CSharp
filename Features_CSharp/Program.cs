using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Features_CSharp
{
    class Student
    {
        public int StudentID { get; internal set; }
        public string StudentName { get; internal set; }
        public int Age { get; internal set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* 0. Use System.Linq namespace to use LINQ.
             * 1. LINQ (Language Integrated Query) is uniform query syntax in C# and 
             *    VB.NET to retrieve data from different sources and formats. It is 
             *    integrated in C# or VB, thereby eliminating the mismatch between 
             *    programming languages and databases, as well as providing a single 
             *    querying interface for different types of data sources.
             *    
             *    For example, SQL is a Structured Query Language used to save and 
             *    retrieve data from a database. In the same way, LINQ is a structured
             *    query syntax built in C# and VB.NET to retrieve data from different 
             *    types of data sources such as collections, ADO.Net DataSet, XML Docs, 
             *    web service and MS SQL Server and other databases.
             *    
             * 2. LINQ queries return results as objects. It enables us to uses object-
             *    oriented approach on the result set and not to worry about transforming
             *    different formats of result into objects.
             * 3. LINQ api includes two main static class Enumerable and Queryable.
             * 
             * 
             * 4. There are two basic ways to write a LINQ query to IEnumerable and IQueryable data sources:
             *          (A) Query Syntax or Query Expression Syntax
             *          (B) Method Syntax or Method Extension Syntax or Fluent
             * 5. Standard Query Operators: https://www.tutorialsteacher.com/linq/linq-standard-query-operators */

            /*                            LINQ Query Syntax                           */

            // LINQ Query to Array
            string[] names = { "Tasnimul", "Alam", "Tohir", "Steave", "Bill", "James" };

            // LINQ Query
            var LinqQuery = from name in names 
                            where name.Contains('i') 
                            select name;

            // Query execution
            foreach(var name in LinqQuery)
                Console.Write(name + " ");
            Console.WriteLine();

            // string collection
            IList<string> stringList = new List<string>() {
                "C# Tutorials",
                "VB.NET Tutorials",
                "Learn C++",
                "MVC Tutorials" ,
                "Java"
            };

            // LINQ Query Syntax: Strings that contains the word Tutorials
            var result = from s in stringList
                         where s.Contains("Tutorials")
                         select s;

            foreach (var x in result)
                Console.Write(x + " ");
            Console.WriteLine();

            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            // LINQ Query Syntax: Find teenagers
            var teenAgerStudents = from student in studentList
                                   where student.Age > 12 && student.Age < 20
                                   select student;

            foreach(var x in teenAgerStudents)
                Console.Write(x.StudentID + ", " + x.StudentName + ", " + x.Age + "\n");
            Console.WriteLine();

            /*                            LINQ Method Syntax                           */

            // string collection
            IList<string> stringList2 = new List<string>() {
                "C# Tutorials",
                "VB.NET Tutorials",
                "Learn C++",
                "MVC Tutorials" ,
                "Java"
            };

            var result2 = stringList2.Where(s => s.Contains("Tutorials"));

            foreach(var x in result2)
                Console.Write(x + " ");
            Console.WriteLine();

            // Student collection
            IList<Student> studentList2 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            var teenStudents = studentList2.Where(data => data.Age > 12 && data.Age < 20);

            Console.WriteLine(teenStudents.ToList());

            foreach (var x in teenStudents)
                Console.Write(x.StudentID + ", " + x.StudentName + ", " + x.Age + "\n");
            Console.WriteLine();
        }
    }
}