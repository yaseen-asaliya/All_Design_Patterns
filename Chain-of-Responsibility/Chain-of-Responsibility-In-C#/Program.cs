/*
The Chain of Responsibility pattern is a behavioral design pattern that allows multiple handlers to process a request sequentially. 
Each handler in the chain either processes the request or passes it to the next handler.
*/

namespace ChainOfResponsibilityDemo {

    public abstract class SupportHandler
    {
        protected SupportHandler _nextHandler;

        public void SetNextHandler(SupportHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void HandleRequest(string issue);
    }

    public class BasicSupport : SupportHandler
    {
        public override void HandleRequest(string issue)
        {
            if (issue == "password reset")
            {
                Console.WriteLine("Basic Support: Handling password reset.");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(issue);
            }
            else
            {
                Console.WriteLine("Basic Support: Issue cannot be handled.");
            }
        }
    }

    public class TechnicalSupport : SupportHandler
    {
        public override void HandleRequest(string issue)
        {
            if (issue == "server down")
            {
                Console.WriteLine("Technical Support: Handling server down issue.");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(issue);
            }
            else
            {
                Console.WriteLine("Technical Support: Issue cannot be handled.");
            }
        }
    }

    public class ManagerSupport : SupportHandler
    {
        public override void HandleRequest(string issue)
        {
            Console.WriteLine("Manager Support: Handling complex issue - " + issue);
        }
    }

    class Program
    {
        static void Main()
        {
            var basicSupport = new BasicSupport();
            var techSupport = new TechnicalSupport();
            var managerSupport = new ManagerSupport();

            // Set up the chain
            basicSupport.SetNextHandler(techSupport);
            techSupport.SetNextHandler(managerSupport);

            // Send requests
            Console.WriteLine("Client: Requesting password reset...");
            basicSupport.HandleRequest("password reset");

            Console.WriteLine("\nClient: Reporting server down...");
            basicSupport.HandleRequest("server down");

            Console.WriteLine("\nClient: Requesting a refund...");
            basicSupport.HandleRequest("refund");
        }
    }


}