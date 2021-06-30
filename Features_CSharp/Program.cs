using System;

namespace Features_CSharp
{
    // Generic class
    class INFO <TData1, TData2>
    {
        public TData1 Data1 { get; set; }
        public TData2 Data2 { get; set; }

        public TReturn Data3<TReturn>(TReturn val) => val;
        public void Data4 <TValue, TKey> (TValue val1, TValue val2, TKey val3)
        {
            Console.WriteLine($"{val1} {val2} {val3}");
        }

        public void print() => Console.WriteLine(Data1 + " " + Data2);
    }

    // Generic Indexer
    class DATA <TData>
    {
        private TData[] store;

        public DATA(int l) => store = new TData[l];

        public TData this[int index]
        {
            get => store[index];
            set => store[index] = value;
        }

        public string this[string index]
        {
            get
            {
                foreach (var i in store)
                    if (i.ToString().ToLower() == index.ToLower())
                        return i + "";
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Generic means general form, not specific to a perticular data type.
             * 2. We define generics with type parameter which is a placeholder for a 
             *    perticular data type specified when creating an instance of the generic type.
             * 3. Generic fields in generic class cannot be initialized.
             */

            Console.ForegroundColor = ConsoleColor.Cyan;
            // Instantiating Generic Class
            INFO <string, int> info = new INFO <string, int>();

            info.Data1 = "Hello World!";
            info.Data2 = info.Data1.Length;
            Console.WriteLine(info.Data3("Hello"));
            info.Data4(5, 6, "Hello");
            info.print();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            // Instantiating Generic class for generic indexer
            DATA<int> data1 = new DATA<int>(2);
            
            data1[0] = 23;
            data1[1] = 42;

            Console.Write(data1["42"] + " ");
            Console.WriteLine(data1[data1[0].ToString()]);

            Console.ResetColor();
        }
    }
}