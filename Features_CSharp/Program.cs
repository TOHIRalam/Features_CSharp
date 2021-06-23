using System;

namespace Features_CSharp
{
    public struct car
    {
        public string color;
        public string name;
        public decimal price;
        public string data() => color + ", " + name + ", " + price;
    }
    class Program
    {
        static void Main(string[] args)
        {
            car car1 = new car();
            car1.color = "Red";
            car1.name = "XYZ";
            car1.price = 10.56M;
            Console.WriteLine(car1.data());
        }
    }
}