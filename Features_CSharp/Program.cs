using System;

namespace Features_CSharp
{
    // Constructor Injection

    public class CustomerBusinessLogic
    {
      ICustomerDataAccess _dataAccess;

      public CustomerBusinessLogic(ICustomerDataAccess custDataAccess)
      {
          _dataAccess = custDataAccess;
      }

      public CustomerBusinessLogic()
      {
          _dataAccess = new CustomerDataAccess();
      }

      public string ProcessCustomerData(int id)
      {
          return _dataAccess.GetCustomerName(id);
      }
    }

    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }

    public class CustomerDataAccess: ICustomerDataAccess
    {
        public CustomerDataAccess()
        {
        }

        public string GetCustomerName(int id) 
        {
            //get the customer name from the db in real application        
            return "Dummy Customer Name"; 
        }
    }

    public class CustomerService
    {
        CustomerBusinessLogic _customerBL;

        public CustomerService()
        {
            _customerBL = new CustomerBusinessLogic(new CustomerDataAccess());
        }

        public string GetCustomerName(int id) {
            return _customerBL.ProcessCustomerData(id);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* Dependency Injection (DI)
               -------------------------
                Dependency Injection (DI) is a design pattern used to implement IoC. It allows the creation of dependent objects outside of a class and provides those objects to a class through different ways. Using DI, we move the creation and binding of the dependent objects outside of the class that depends on them.

              The Dependency Injection pattern involves 3 types of classes
              ------------------------------------------------------------
                1. Client Class: The client class (dependent class) is a class which depends on the service class
                2. Service Class: The service class (dependency) is a class that provides service to the client class.
                3. Injector Class: The injector class injects the service class object into the client class.

              Types of dependency injection
              ------------------------------

                1. Constructor Injection: In the constructor injection, the injector supplies the service (dependency) through the client class constructor.

                2. Property Injection: In the property injection (aka the Setter Injection), the injector supplies the dependency through a public property of the client class.

                3. Method Injection: In this type of injection, the client class implements an interface which declares the method(s) to supply the dependency and the injector uses this interface to supply the dependency to the client class.
            */
        }
    }
}