using System;

namespace Features_CSharp
{
    // Indexer
    class TODO
    {
        private string[] todo_index = new string[5];

        public string this[int index]
        {
            get => todo_index[index];
            set => todo_index[index] = value;
        }
    }

    // Generic Indexer
    class DATASTORE <T>
    {
        private T[] store;

        public DATASTORE() => store = new T[10];
        public DATASTORE(int size) => store = new T[size];

        public T this[int index]
        {
            get => store[index];
            set => store[index] = value;
        }

        public int Length => store.Length;
    }

    // Overload indexer with different datatype
    class STUDENTS
    {
        private string[] indexer;

        public STUDENTS() => indexer = new string[5];
        public STUDENTS(int l) => indexer = new string[l];

        public string this[int index]
        {
            get => indexer[index];
            set => indexer[index] = value;
        }

        public string this[string index]
        {
            get
            {
                foreach (var data in indexer)
                    if (data.ToLower() == index.ToLower())
                        return data;
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. An indexer is a special type of property that allows a class or a structure to be accessed
             *    like an array for its internal collection. 
             * 2. An indexer can be defined the same way as property with 'this' keyword and square brackets [].
             * 3. Indexer does not allow ref and out parameters.
             */

            TODO todo = new TODO();
            
            todo[0] = "Workout";
            todo[1] = "Study";
            todo[2] = "Sleep";
            todo[3] = "Travel";
            todo[4] = "Buy laptop";

            Console.WriteLine("My todo list: ");
            for(var i = 0; i < 5; i++)
                Console.WriteLine(todo[i]);

            DATASTORE<string> dt1 = new DATASTORE<string>(2);
            dt1[0] = "Hello World!";
            dt1[1] = "Not Hello World!";

            for (var i = 0; i < dt1.Length; i++)
                Console.WriteLine(dt1[i]);

            DATASTORE<int> dt2 = new DATASTORE<int>(2);
            dt2[0] = 45;
            dt2[1] = 90;

            for (var i = 0; i < dt2.Length; i++)
                Console.WriteLine(dt2[i]);

            // Overloaded indexer 
            STUDENTS info = new STUDENTS(3);
            
            info[0] = "Tasnimul Alam";
            info[1] = "Mr. Bean";
            info[2] = "Micheal Scott";

            Console.WriteLine(info["tasnimul alam"]);
            Console.WriteLine(info["micheal scott"]);
        }
    }
}