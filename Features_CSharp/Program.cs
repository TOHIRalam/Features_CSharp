using System;

namespace Features_CSharp
{

    /*                    What's wrong in this code
                         ---------------------------
      1. CustomerBusinessLogic and DataAccess classes are tightly coupled classes. So, 
      changes in the DataAccess class will lead to changes in the CustomerBusinessLogic class. 
      For example, if we add, remove or rename any method in the DataAccess class 
      then we need to change the CustomerBusinessLogic class accordingly.

      2. Suppose the customer data comes from different databases or web services and, in the future, 
      we may need to create different classes, so this will lead to changes in the CustomerBusinessLogic class.

      3. The CustomerBusinessLogic class creates an object of the DataAccess class using the new keyword. 
      There may be multiple classes which use the DataAccess class and create its objects. So, if you change 
      the name of the class, then you need to find all the places in your source code where you created objects 
      of DataAccess and make the changes throughout the code. This is repetitive code for creating 
      objects of the same class and maintaining their dependencies.

      4. Because the CustomerBusinessLogic class creates an object of the concrete DataAccess class, 
      it cannot be tested independently (TDD). The DataAccess class cannot be replaced with a mock class
    */

    public class DataAccess {
      public DataAccess() { }

      public string GetCustomerName(int id) {
        return "Dummy Customer Name";
      }
    }

    public class CustomerBusinessLogic {
      DataAccess _dataAccess;

      public CustomerBusinessLogic() {
        _dataAccess = new DataAccess();
      }

      public string GetCustomerName(int id) {
        return _dataAccess.GetCustomerName(id);
      }
    }

    // The Factory pattern to implement IoC of the above example. This is a simple implementation of IoC and the first step towards achieving fully loose coupled design.

    public class DataAccess2 {
      public DataAccess2() { }

      public string GetCustomerName(int id) {
        return "Dummy Customer Name";
      }
    }
    
    public class DataAccessFactory {
      public static DataAccess2 GetDataAccessObj() => new DataAccess2();
    }

    public class CustomerBusinessLogic2 {

      public CustomerBusinessLogic2() {  }

      public string GetCustomerName(int id) {
        DataAccess2 _dataAccess2 = DataAccessFactory.GetDataAccessObj();
        return _dataAccess2.GetCustomerName(id);
      }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* Inversion of Control
               --------------------
                IoC is a design principle which recommends the
                inversion of different kinds of controls in OOP.
                If we want to do TDD (Test Driven Development), 
                then we must use the IoC principle, without which TDD is not possible.

              Dependency Inversion Principle
              -------------------------------
                The DIP principle also helps in achieving loose coupling between classes. 
                It is highly recommended to use DIP and IoC together in order to achieve loose coupling. It suggest that: 

                "High-level modules should not depend on low level modules. Both shoud depend on abstraction."

              IoC Container
              --------------
                The IoC container is a framework used to manage automatic dependency throughout the applicaiton, 
                so that we as programmers do not need to put more time and effort into it. 

                There are various IoC framework for .NET such as Unity, Ninject, StructureMap, Autofac.

                * * * How we can achive loose coupling * * *
                --------------------------------------------
                We cannot achive loosely coupled classes by using IoC alone. Along with IoC, 
                we also need to use DIP, DI, and IoC container. 

                Tightly Coupled classes -> Implement IoC using factory pattern ->
                Implement DIP by creating abstraction -> 
                Implement DI -> Use IoC Container -> 
                Loosely coupled classes


                ## CHECK OUT THE DIP BRANCH TO SEE THE NEXT STEP (-->) ##
            */
        }
    }
}