namespace 设计模式_观察者模式
{
    internal class Cat
    {
        public event Action<string> CatComingEvent;
        public string Name { get; set; }
        public Cat(string name)
        {
            Name = name;
        }

        public void CatComing()
        {
            Console.WriteLine("{0} cat is coming", Name);
            CatComingEvent?.Invoke(Name);
        }
    }
}
 