namespace 设计模式_观察者模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat("Tom");
            Mouse mouse1 = new Mouse("Jerry");
            Mouse mouse2 = new Mouse("denghang");
            // 事件不能在类的外部触发，只能在类的内部触发
            cat1.CatComingEvent += mouse1.Run;
            cat1.CatComingEvent += mouse2.Run;
            cat1.CatComing();  // 猫来了，Tom cat is coming
        }
    }
}
