using System;
using System.Collections;
using System.Collections.Generic;

namespace Features_CSharp
{
    class Capital
    {
        private string _name;
        private int _country_id;
        public string Name { get => _name; set => _name = value; }
        public int Country_id { get => _country_id; set => _country_id = value; }
    }

    class Customer
    {
        private String _Name, _City;
        private long _Mobile;
        private double _Amount;
        public double Amount { get => _Amount; set => _Amount = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string City { get => _City; set => _City = value; }
        public long Mobile { get => _Mobile; set => _Mobile = value; }
    }

    class Program
    {
        // Passing IEnumerator
        static void Iterate_Till_2000(IEnumerator<int> iterator)
        {
            Console.WriteLine("Current years: ");
            while(iterator.MoveNext())
            {
                Console.Write(iterator.Current.ToString() + " ");
                if (Convert.ToInt16(iterator.Current) > 2000)
                    Iterate_Above_2000(iterator);
            }
        }

        static void Iterate_Above_2000(IEnumerator<int> iterator)
        {
            Console.WriteLine();
            while(iterator.MoveNext())
                Console.Write(iterator.Current.ToString() + " ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            /* # IEnumerable in C# is an interface that defines one method, GetEnumerator which returns an 
             *   IEnumerator interface. This allows readonly access to a collection then a collection that 
             *   implements IEnumerable can be used with a for-each statement. 
             *   
             *   Key Points
             *   -----------------
             *   1. IEnumerable interface contains the System.Collection.Generic namespace.
             *   2. IEnumerable interface is a generic interface which allows looping over generic or non-generic lists.
             *   3. IEnumerable interface also works with linq query expression. 
             *   4. IEnumerable interface returns and enumerator that iterates through collection.
             * 
             *                          IEnumerable vs IEnumerator
             *                         ----------------------------
             * 1. IEnumerable and IEnumerator are both interfaces.
             * 2. IEnumerable has just one method called GetEnumerator. This method returns another type
             *    which is an interface that interface is IEnumerator. 
             * 3. If we want to implement enumerator logic in any collection class, it needs to implement 
             *    IEnumerable interface (either generic or non-generic).
             * 4. IEnumerable has just one method whereas IEnumerator has two methods (MoveNext and Reset)
             *    and a property Current. 
             * 6. For our understanding we can say that IEnumrable is a box that contains IEnumerator inside it. 
             * 7. IEnumerator remember states while passing in one function to other function but IEnumerable does not. 
             */

            int[] arr = new int[] { 1, 2, 3 };

            var x = arr.GetEnumerator();
            x.MoveNext();

            Console.WriteLine("Point to first element: " + x.Current);
            x.MoveNext();

            Console.WriteLine("After moving to next element: " + x.Current);
            x.Reset();
            x.MoveNext();

            Console.WriteLine("Reset to first element: " + x.Current);

            Console.Write("Array: ");
            foreach (var i in arr)
                Console.Write(i + " ");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Customer[] customers = new Customer[]
            {
                new Customer { Name = "Tasnimul Alam", City = "Dhaka", Mobile = 01712345678, Amount = 95.98 },
                new Customer { Name = "Vaas Montenegro", City = "Sylhet", Mobile = 01412345678, Amount = 25.98 }
            };

            List<string> countries = new List<string>() { "Bangladesh", "India", "Russia", "China", "America" };
            List<int> Years = new List<int>() { 1996, 1997, 1998, 1999, 2000, 2001, 2002, 2003, 2004, 2005, 2006 };

            Capital[] capital = new Capital[]
            {
                new Capital { Name = "Dhaka", Country_id = 1 },
                new Capital { Name = "Delhi", Country_id = 2 },
                new Capital { Name = "Moscow", Country_id = 3 },
                new Capital { Name = "Beijing", Country_id = 4 }
            };

            IEnumerable<Customer> GetAllCustomer() => customers;
            IEnumerable<string> Ienum = (IEnumerable<string>)countries;
            IEnumerable<Capital> IcapitalEnum() => capital;

            IEnumerator<int> ienumrator = Years.GetEnumerator();
            Iterate_Till_2000(ienumrator);

            foreach(var iterator in GetAllCustomer())
                Console.WriteLine($"Name: {iterator.Name}\nCity: {iterator.City}\n" +
                    $"Contact: {iterator.Mobile}\nAmount: {iterator.Amount}\n");
            Console.WriteLine();
            
            foreach(var i in Ienum)
                Console.WriteLine(i + " ");
            Console.WriteLine();

            foreach(var i in IcapitalEnum())
                Console.WriteLine(i.Name + "[" + i.Country_id + "]");
            Console.WriteLine();

            Console.ResetColor();
        }
    }
}