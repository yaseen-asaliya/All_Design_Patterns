namespace ProxyDemo {

    public interface ISubject
    {
        void Request();
    }

    // Expensive Object
    public class RealSubject : ISubject 
    {
        public RealSubject()
        {
            Console.WriteLine("RealSubject: Initialized.");
        }

        public void Request()
        {
            Console.WriteLine("RealSubject: Handling request.");
        }
    }

    // Lazy Loading & Access Control
    public class Proxy : ISubject
    {
        private RealSubject _realSubject;
        private bool _hasAccess;

        public Proxy(bool hasAccess)
        {
            _hasAccess = hasAccess;
        }

        public void Request()
        {
            if (!_hasAccess)
            {
                Console.WriteLine("Proxy: Access denied.");
                return;
            }

            if (_realSubject == null)
            {
                _realSubject = new RealSubject(); // Lazy initialization
            }

            Console.WriteLine("Proxy: Forwarding request to RealSubject.");
            _realSubject.Request();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Client: Using Proxy with access.");
            ISubject proxyWithAccess = new Proxy(true);
            proxyWithAccess.Request();

            Console.WriteLine("\nClient: Using Proxy without access.");
            ISubject proxyWithoutAccess = new Proxy(false);
            proxyWithoutAccess.Request();
        }
    }



}