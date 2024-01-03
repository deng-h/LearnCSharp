namespace 设计模式_策略模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context1 = new Context(new ConcreteStrategyA());
            Context context2 = new Context(new ConcreteStrategyB());

            context1.ContextInterface();
            context2.ContextInterface();
        }
    }

    public class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }

    public interface IStrategy
    {
        public void AlgorithmInterface();
    }

    public class ConcreteStrategyA : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyB.AlgorithmInterface()");
        }
    }
}
