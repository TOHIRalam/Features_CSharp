using System;
using System.Collections.Generic;

namespace Features_CSharp
{
    class STUDENTS : IComparable<STUDENTS>
    {
        public string Name { get; set; }
        public double CGPA { get; set; }
        public STUDENTS(string name) => Name = name;

        public int CompareTo(STUDENTS other) => Name.CompareTo(other.Name);
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<STUDENTS> studentsList = new List<STUDENTS> {
                new STUDENTS("Tohir"), new STUDENTS("Alam"),
                new STUDENTS("Bca"), new STUDENTS("Uvw")
            };
            studentsList.Sort();
            studentsList.ForEach(s => Console.WriteLine(s.Name));
        }
    }
}