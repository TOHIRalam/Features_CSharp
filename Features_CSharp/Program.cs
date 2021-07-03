using System;
using System.Text;

namespace Features_CSharp
{
    /*
     * * * We can declare an event with two steps:
     * * * 1. Declare a delegate
     * * * 2. Declare a variable of the delegate with event keyword.
     */

    /*
     * Here we declared a delegate Notify and then declared an event ProcessCompleted of delegate type
     * Notify using 'event' keyword in ProcessBusinessLogic class. Thus, the ProcessBusinessLogic class
     * is called the publisher. 
     * 
     * The Notify delegate specifies the signatur for the ProcessCompleted event which specifies that the
     * event handler method in subscriber class must have void return type and no parameters. 
     * 
     * The StartProcess() method calls the method onProcessCompleted() at the end, which raises an event.
     * Typically, to raise an event, protected and virtual method should be defined with the name On<EventName>.
     * Protected and virual enable derived classes to override the logic for raising the event. 
     * 
     * A derived class should always call the On<EventName> method of the base class to ensure that registered
     * that registered delegates receive the event. The OnProcessCompleted() method invokes the delegate using 
     * ProcessCompleted?.Invoke();. This will call all the event handler methods registered with the 
     * ProcessCompleted event. The subscriber class must register to ProcessCompleted event and handle it with 
     * the method whose signature matches Notify delegate, as shown below.
     */

    // Declaring an event in publisher class

    public delegate void Notify();

    class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Process Started");
            onProcessCompleted();
        }

        protected virtual void onProcessCompleted() => ProcessCompleted?.Invoke();
    }

    /*
     * .NET Framework includes built-in delegate types EventHandler and 
     * EventHandler<TEventArgs> for the most common events. Typically, 
     * any event should include two parameters: the source of the event 
     * and event data. Use the EventHandler delegate for all events that 
     * do not include event data. Use EventHandler<TEventArgs> delegate 
     * for events that include data to be sent to handlers.
     */

    class ProcessBusinessLogic2
    {
        // Declaring an event using built-in EventHandler
        public event EventHandler ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Process Started");
            // No event data
            OnProcessCompleted(EventArgs.Empty); 
        }

        protected virtual void OnProcessCompleted(EventArgs e) => ProcessCompleted?.Invoke(this, e);
    }

    /*
     * Most events send some data to the subscribers. The EventArgs class is the base class for all the event data classes. 
     * .NET includes many built-in event data classes such as SerialDataReceivedEventArgs. It follows a naming pattern of 
     * ending all event data classes with EventArgs. You can create your custom class for event data by deriving EventArgs class.
     * Use EventHandler<TEventArgs> to pass data to the handler.
     */

    class ProcessBusinessLogic3
    {
        // Declaring event with built-in EventHandler
        public event EventHandler<bool> ProcessCompleted;

        public void StartProcess()
        {
            try
            {
                Console.WriteLine("Process Started!");
                onProcessCompleted(true);
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                onProcessCompleted(false);
            }
        }

        public void onProcessCompleted(bool IsSuccessful) => ProcessCompleted?.Invoke(this, IsSuccessful); 
    }

    /*
     * If we want to pass more than one value as event data, 
     * then create a class deriving from the EventArgs base class
     */

    class ProcessEventArgs : EventArgs
    {
        public bool IsSuccessful { get; set; }
        public DateTime CompletionTime { get; set; }
    }

    class ProcessBusinessLogic4
    {
        public event EventHandler<ProcessEventArgs> ProcessCompleted;

        public void StartProcess()
        {
            ProcessEventArgs data = new ProcessEventArgs();

            try
            {
                Console.WriteLine("Process Started");
                data.IsSuccessful = true;
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                data.IsSuccessful = false;
            }

            data.CompletionTime = DateTime.Now;
            OnProcessCompleted(data);
        }

        public virtual void OnProcessCompleted(ProcessEventArgs e) => ProcessCompleted?.Invoke(this, e);
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 0. An event is a wrapper around a delegate, it depends on the delegate. 
             * 1. An event is a notification sent by an object to signal the occurrence of an action.
             * 2. The class who raises events is called Publisher, and the class who receives the 
             *    notification is called Subscriber. 
             * 3. There can be multiple subscriber of a single event. A publisher raises an event when
             *    some action occured. THe subscribers, who are interested in getting a notification when 
             *    an action occured, should register with an event and handle it. 
             * 4. In C#, an event is an encapsulated delegate. It is dependent on the delegate. The delegate
             *    defines the signature for the event handler method of the subscriber class.
             * 5. The signature of the handler method must match he delegate
             * 6. Derive EventArgs base class to create custom event data class.
             */

            /*
             * Here, this program class is a subscriber of the ProcessComplted event. It registers with the event
             * using += operator. The bl_ProcessCompleted() method handles the event because it matches the 
             * signature of the Notify delegate.
             */

            ProcessBusinessLogic process = new ProcessBusinessLogic();
            process.ProcessCompleted += bl_ProcessCompleted;
            process.StartProcess();

            /*
             * The event handler bl_ProcessCompleted() method includes two parameters that match with EventHandler 
             * delegate. Also, passing this as a sender and EventArgs.Empty, when we raise an event using Invoke() 
             * in the OnProcessCompleted() method. Because we don't need any data for our event, it just notifies 
             * subscribers about the completion of the process, and so we passed EventArgs.Empty.
             */

            ProcessBusinessLogic2 process2 = new ProcessBusinessLogic2();
            process2.ProcessCompleted += bl_ProcessCompleted2;
            process2.StartProcess();

            /*
             * We are passing a single boolean value to the handlers that indicate 
             * whether the process completed successfully or not. 
             */

            ProcessBusinessLogic3 process3 = new ProcessBusinessLogic3();
            process3.ProcessCompleted += bl_ProcessCompleted3;
            process3.StartProcess();

            /*
             * Passing custom EventArgs
             */

            ProcessBusinessLogic4 process4 = new ProcessBusinessLogic4();
            process4.ProcessCompleted += bl_ProcessCompleted4;
            process4.StartProcess();
        }

        public static void bl_ProcessCompleted() => Console.WriteLine("Process Completed");
        public static void bl_ProcessCompleted2(Object sender, EventArgs e) => Console.WriteLine("Process Completed");
        public static void bl_ProcessCompleted3(Object sender, bool IsSccessful) => Console.WriteLine(IsSccessful ? "Completed Successfully" : "Failed");
        public static void bl_ProcessCompleted4(Object sender, ProcessEventArgs e)
        {
            Console.WriteLine("Process: " + (e.IsSuccessful ? "Completed" : "Not Completed"));
            Console.WriteLine("Completion Time: " + (e.CompletionTime.ToLongDateString()));
        }
    }
}