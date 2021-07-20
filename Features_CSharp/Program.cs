using System;
using System.Collections.Generic;

namespace Features_CSharp
{
    public delegate Small covarDel(Big mc);

    public class Small
    {

    }

    public class Big : Small
    {

    }

    public class Bigger : Big
    {

    }

    class Program
    {
        public static Big Method1(Big bg)
        {
            Console.WriteLine("Method1");

            return new Big();
        }
        public static Small Method2(Big bg)
        {
            Console.WriteLine("Method2");

            return new Small();
        }

        static Big Method11(Big bg)
        {
            Console.WriteLine("Method11");
            return new Big();
        }
        static Small Method22(Big bg)
        {
            Console.WriteLine("Method22");
            return new Small();
        }

        static Small Method33(Small sml)
        {
            Console.WriteLine("Method33");

            return new Small();
        }

        static void Main(string[] args)
        {
            /*                                   Covariance
             *                                  ------------
             * 1. Covariance enables you to pass a derived type where a base type is expected. 
             *    Co-variance is like variance of the same kind. The base class and other derived 
             *    classes are considered to be the same kind of class that adds extra 
             *    functionalities to the base type. So covariance allows you to use a derived 
             *    class where a base class is expected (rule: can accept big if small is expected).
             *    
             * 2. Covariance can be applied on delegate, generic, array, interface, etc. Covariance
             *    with delegates allows flexibility in the return type of delegate methods. */

                            /* As we can see in the above example, delegate expects 
                             * a return type of small (base class) but we can still 
                             * assign Method1 that returns Big (derived class) and also 
                             * Method2 that has same signature as delegate expects.
                             * 
                             * Thus, covariance allows us to assign a method to the 
                             * delegate that has a less derived return type. */

            covarDel del = Method1;

            Small sm1 = del(new Big());

            del = Method2;
            Small sm2 = del(new Big());


            /*                                   Contravariance
             *                                  ----------------
             * 1. Contravariane is applied to parameters. Cotravariance allows a method with the 
             *    parameter of a base class to be assigned to a delegate that expects the 
             *    parameter of a derived class. */

                            /* As we can see, Method3 has a parameter of Small 
                             * class whereas delegate expects a parameter of Big class. 
                             * Still, we can use Method3 with the delegate. */

            del = Method11;
            del += Method22;
            del += Method33;

            Small sm = del(new Big());
        }
    }
}