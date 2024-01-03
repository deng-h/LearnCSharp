namespace 设计模式_组合模式
{
    public class Program
    {
        static void Main(string[] args)
        {
            IBox singleBox = new SingleBox();
            singleBox.Process();
        }
    }

    public interface IBox
    {
        public void Process();
    }

    public class SingleBox : IBox
    {
        public void Process()
        {
            Console.WriteLine("SingleBox.Process()");
        }
    }

    public class ContainerBox : IBox
    {
        public void Process()
        {
            Console.WriteLine("ContainerBox.Process()");
        }
    }
}
