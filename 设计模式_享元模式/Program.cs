namespace 设计模式_享元模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            _flyweights.Add("X", new ConcreteFlyweight());
            _flyweights.Add("Y", new ConcreteFlyweight());
            _flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return _flyweights[key];
        }
    }

    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    public class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("ConcreteFlyweight.Operation()");
        }
    }

    public class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("UnsharedConcreteFlyweight.Operation()");
        }
    }

    public class Client
    {
        private FlyweightFactory _factory;

        public Client(FlyweightFactory factory)
        {
            _factory = factory;
        }

        public void Run()
        {
            Flyweight fx = _factory.GetFlyweight("X");
            fx.Operation(1);

            Flyweight fy = _factory.GetFlyweight("Y");
            fy.Operation(2);

            Flyweight fz = _factory.GetFlyweight("Z");
            fz.Operation(3);

            Flyweight fu = new UnsharedConcreteFlyweight();
            fu.Operation(4);
        }
    }
}
