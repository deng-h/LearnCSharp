namespace 事件
{
    // 事件是C#中一种特殊的委托，事件是用来和委托一起使用的，事件的声明和委托的声明类似，但是事件使用event关键字来修饰
    // 事件的声明一般形式如下：
    // event <委托类型> <事件名>
    // 其中，委托类型是事件处理函数的类型，事件名是事件的名字
    // 事件的声明一般放在类的内部，事件的声明可以在类的外部，但是必须在类的内部使用event关键字进行修饰
    // 事件为委托提供了一个发布/订阅机制，一个类的事件可以被其他类订阅，当事件发生时，其他类可以得到通知并执行事件处理函数
    internal class Program
    {
        public delegate void MyDelegate();
        //public MyDelegate myDelegate;
        public event MyDelegate myDelegate;  // 事件

        static void Main(string[] args)
        {
            Program program = new Program();
            program.myDelegate += Test1;
            program.myDelegate();

        }

        static void Test1()
        {
            Console.WriteLine("Test1");
        }
    }
}
