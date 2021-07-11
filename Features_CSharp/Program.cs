using System;

namespace Features_CSharp
{
    public class Address
    {
        public string addressLine, city, state;
        public Address(string addressLine, string city, string state)
        {
            this.addressLine = addressLine;
            this.city = city;
            this.state = state;
        }
    }
    public class Employee
    {
        public int id;
        public string name;
        public Address address;//Employee HAS-A Address  
        public Employee(int id, string name, Address address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
        public void display()
        {
            Console.WriteLine(id + " " + name + " " +
              address.addressLine + " " + address.city + " " + address.state);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* Aggregation is a process in which one class defines another class as any entity reference.
             * It is another way to reuse the class. It's a from of association that represents HAS-A-relationship. */

            Address a1 = new Address("G-13, Sec-3", "Noida", "UP");
            Employee e1 = new Employee(1, "Sonoo", a1);
            e1.display();

        }
    }
}