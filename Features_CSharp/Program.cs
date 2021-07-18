using System;
using System.Collections;
using System.Collections.Generic;

namespace Features_CSharp
{
    class DescendingCompare<TKey> : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* 1. There are two types of collection in C# which are non-generic and generic collection 
             * 2. The System.Collections namespace contains the non-generic collection types and 
             *    System.Collections.Generic namespace includes generic collection types.
             * 3. In most cases, it is recommended to use the generic collections because they perform 
             *    faster than non-generic collections and also minimize exceptions by giving compile-time errors.
             *                              
             *                                       Generic Collections
             *                                      ---------------------
             * 1. List <T> : It contains elements of specified type. It grows automatically as you add elements in it.
             * 2. Dictionary<TKey,TValue> : It contains key-value pairs.
             * 3. SortedList<TKey,TValue> : It stores key and value pairs. It automatically adds the elements in 
             *                              ascending order of key by default.
             * 4. Stack<T> : It stores the values as LIFO (Last In First Out). It provides a Push() method to add a value 
             *               and Pop() & Peek() methods to retrieve values.
             * 5. Queue<T> : It stores the values in FIFO style (First In First Out). It keeps the order in which the 
             *               values were added. It provides an Enqueue() method to add values and a Dequeue() method to 
             *               retrieve values from the collection.
             * 6. Hashset<T> : It contains non-duplicate elements. It eliminates duplicate elements.
             * 
             *                                      Non-Generic Collections
             *                                     -------------------------
             * 1. ArrayList : It stores objects of any type like an array. However, there is no need to specify the size of the 
             *                ArrayList like with an array as it grows automatically.
             * 2. SortedList : It stores key and value pairs. It automatically arranges elements in ascending order of key by 
             *                 default. C# includes both, generic and non-generic SortedList collection.
             * 3. Stack : It stores the values in LIFO style (Last In First Out). It provides a Push() method to add a value and 
             *            Pop() & Peek() methods to retrieve values. C# includes both, generic and non-generic Stack.
             * 4. Queue : It stores the values in FIFO style (First In First Out). It keeps the order in which the values were added. 
             *            It provides an Enqueue() method to add values and a Dequeue() method to retrieve values from the collection. 
             *            C# includes generic and non-generic Queue.
             * 5. Hashtable : It stores key and value pairs. It retrieves the values by comparing the hash value of the keys.
             *                In Hashtable key must be unique and can not be null. values can be null or duplicate.
             * 6. BitArray : It manages a compact array of bit values, which are represented as Booleans, where true indicates that 
             *               the bit is on (1) and false indicates the bit is off (0).
             */
            
            // SortedList demonstration 
            Console.ForegroundColor = ConsoleColor.Cyan;
            SortedList<char, string> sList = new SortedList<char, string>();

            sList['d'] = "Hello World!4";
            sList['b'] = "Hello World!2";
            sList['a'] = "Hello World!1";
            sList['c'] = "Hello World!3";

            Console.WriteLine($"Number of items: {sList.Count}");

            foreach (KeyValuePair<char, string> i in sList)
                Console.WriteLine($"key: {i.Key}, value: {i.Value}");

            SortedList<int, string> numberNames = new SortedList<int, string>()
                                    {
                                        {3, "Three"},
                                        {5, "Five"},
                                        {1, "One"}
                                    };

            Console.WriteLine("---Initial key-values--");

            foreach (KeyValuePair<int, string> kvp in numberNames)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

            numberNames.Add(6, "Six");
            numberNames.Add(2, "Two");
            numberNames.Add(4, "Four");

            Console.WriteLine("---After adding new key-values--");

            foreach (var kvp in numberNames)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

            Console.WriteLine("Sort the list in descending order and iterate using for loop:-");

            for (int i = 0; i < numberNames.Count; i++)
                Console.WriteLine("key: {0}, value: {1}", numberNames.Keys[i], numberNames.Values[i]);



            // HashSet demonstration
            Console.ForegroundColor = ConsoleColor.Yellow;
            HashSet<int> hashset = new HashSet<int>();

            hashset.Add(5);
            hashset.Add(6);
            hashset.Add(5);
            hashset.Add(6);

            Console.WriteLine("\nNumber of elements: " + hashset.Count); // Number of elements: 2

            foreach(var i in hashset)                   
                Console.Write(i + " ");                                // 5 6

            hashset.Remove(5);
            Console.WriteLine("\nNumber of elements now in HashSet: " + hashset.Count);

            foreach (var i in hashset)
                Console.Write(i + " ");

            Console.ResetColor();
        }
    }
}