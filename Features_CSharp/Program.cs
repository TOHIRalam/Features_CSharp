using System;

namespace Features_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* C# provides checked and unchecked keyword to handle integral 
             * type exceptions. Checked and unchecked keywords specify checked 
             * context and unchecked context respectively. In checked context, 
             * arithmetic overflow raises an exception whereas, in an unchecked 
             * context, arithmetic overflow is ignored and result is truncated. */

            int vall = int.MaxValue;
            Console.WriteLine(vall + 2);

            checked
            {
                int val = int.MaxValue;
                Console.WriteLine(val + 2);
            }

            unchecked
            {
                int val2 = int.MaxValue;
                Console.WriteLine(val2 + 2);
            }
        }
    }
}