namespace 设计模式_组合模式
{
    // 组合模式
    // 1 组合模式是一种结构型设计模式，你可以使用它将对象组合成树状结构，并且能像使用独立对象一样使用它们
    // 2 组合模式对单个对象(叶子)和组合对象(容器)的使用具有一致性
    // 3 组合模式中的容器对象可以是叶子对象，也可以是容器对象，从而使得用户代码可以一致地处理对象和对象容器，无需关心处理的是单个的对象，还是组合的对象容器
    // 4 组合模式将对象组合成树形结构，以表示“部分-整体”的层次结构。组合模式使得用户对单个对象和组合对象的使用具有一致性
    // 5 组合模式使用树形结构来实现普遍存在的对象容器，从而将“一对多”的关系转化为“一对一”的关系，使得客户代码可以一致地处理对象和对象容器，无需关心处理的是单个的对象，还是组合的对象容器
    // 6 在组合模式中，简单对象可以构成复杂对象，而复杂对象又可以构成更复杂的对象，这样不断递归下去，客户代码中，任何用到简单对象的地方都可以使用复杂对象了
    // 7 组合模式让客户可以一致地使用组合结构和单个对象
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
