using System;

namespace Features_CSharp
{

    // The Factory pattern to implement IoC of the above example. 
    // But it is still tightly coupled, even though we inverted the dependent object creation to the factory class.

    public class DataAccess2 
    {
      public DataAccess2() { }

      public string GetCustomerName(int id) 
      {
        return "Dummy Customer Name";
      }
    }
    
    public class DataAccessFactory 
    {
      public static DataAccess2 GetDataAccessObj() => new DataAccess2();
    }

    public class CustomerBusinessLogic2 
    {
      public CustomerBusinessLogic2() {  }

      public string GetCustomerName(int id) 
      {
        DataAccess2 _dataAccess2 = DataAccessFactory.GetDataAccessObj();
        return _dataAccess2.GetCustomerName(id);
      }
    }

    /* DIP on the CustomerBusinessLogic and DataAccess classes and make them more loosely coupled. */

    /*
       The advantages of implementing DIP in the above example is that the CustomerBusinessLogic and CustomerDataAccess classes are loosely coupled classes because CustomerBusinessLogic does not depend on the concrete DataAccess class, instead it includes a reference of the ICustomerDataAccess interface. So now, we can easily use another class which implements ICustomerDataAccess with a different implementation.
    */
    public class IDataAcess 
    { 
      string GetCustomerName(int id);
    }

    public class DataAccess : IDataAcess 
    {
      public DataAccess() { }

      public string GetCustomerName(int id) 
      {
        return "Dummy Customer Name";
      }
    }

    public class DataAccessFactory
    {
      public static IDataAcess GetDataAccessObj() => new DataAccess();
    }

    public class CustomerBusinessLogic 
    {
      IDataAcess _dataAccess;

      public CustomerBusinessLogic() 
      {
        _dataAccess = DataAccessFactory.GetDataAccessObj();
      }

      public string GetCustomerName(int id) => _dataAccess.GetCustomerName(id);
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* DIP is one of the SOLID object-oriented principle invented by Robert Martin (a.k.a. Uncle Bob)
            
               DIP Definition
               --------------
                1. High-level modules should not depend on low-level modules, both should depend on the abstraction. 
                2. Abstractions should not depend on details, details should be depend on abstractions.

              Still, we have not achieved fully loosely coupled classes because the CustomerBusinessLogic class includes a factory class to get the reference of ICustomerDataAccess. This is where the Dependency Injection pattern helps us.

                ## CHECK OUT THE DI BRANCH TO SEE THE NEXT STEP (-->) ##
            */
        }
    }
}