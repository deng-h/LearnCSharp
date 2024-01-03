namespace 反射和特性
{
    internal class Car
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int field;
        public Car(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public void Run()
        {
            Console.WriteLine("{0} is running", Name);
        }
    }
}
