namespace 设计模式_解释器模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            context.Interpret();
        }
    }

    public class Context
    {
        private IExpression _expression;

        public Context()
        {
        }

        public void Interpret()
        {
            _expression.Interpret();
        }
    }

    public interface IExpression
    {
        public void Interpret();
    }

    public class TerminalExpression : IExpression
    {
        public void Interpret()
        {
            Console.WriteLine("TerminalExpression.Interpret()");
        }
    }

    public class NonterminalExpression : IExpression
    {
        public void Interpret()
        {
            Console.WriteLine("NonterminalExpression.Interpret()");
        }
    }
}
