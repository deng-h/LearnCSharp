namespace 设计模式_观察者模式
{
    internal class Mouse
    {
        public string Name { get; set; }
        public Mouse(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 逃跑
        /// </summary>
        public void Run(string catName)
        {
            Console.WriteLine($"{catName}来了，{Name} mouse is running");
        }
    }
}
