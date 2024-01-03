namespace 委托
{
    // 委托 委托可用来实现策略模式
    // 委托是一个类，它定义了方法的类型，使得可以将方法当作另一个方法的参数来进行传递，这种将方法动态地赋给参数的做法，
    // 可以避免在程序中大量使用if-else或者switch-case语句，同时使得程序具有更好的可扩展性。
    // 委托的声明和类的声明相似，使用delegate关键字，其一般形式如下：
    // delegate <返回类型> <委托名> <参数表>
    // 其中，返回类型可以是void，表示委托没有返回值，参数表中包含了一个或者多个方法参数，这些参数的类型和顺序必须与委托所封装的方法的参数类型和顺序相同
    internal class Program
    {
        // 定义一个委托类型，该委托可以指向任何返回string类型，不接受参数的方法
        // 这个委托类型的名字叫GetAString
        private delegate string GetAString();

        static void Main(string[] args)
        {
            int x = 40;
            //GetAString a = new GetAString(x.ToString);  // a指向x.ToString方法
            GetAString a = x.ToString;

            string s1 = a();  // s1 = "40" 通过委托实例调用方法
            string s2 = a.Invoke();  // s2 = "40" 通过委托实例调用方法
            Console.WriteLine(s1);
            Console.WriteLine(s2);

            Console.WriteLine("-----使用委托类型作为方法的参数-----");
            PrintStrDelegate del = new PrintStrDelegate(PrintWorld);
            PrintStr(del);

            Console.WriteLine("-----Action委托-----");
            // Action委托是.Net定义的一个委托类型，它可以用来封装一个方法，这个方法可以有零个或者多个参数，但是这个方法必须没有返回值
            Action action = PrintHello;
            action();

            Action<string> action1 = PrintSth;
            action1("Hello World");

            // Func委托是.Net定义的一个委托类型，它可以用来封装一个方法，这个方法可以有零个或者多个参数，但是这个方法必须有返回值
            Func<string> func = GetString;
            string s = func();
            Console.WriteLine(s);

            Console.WriteLine("-----使用匿名方法-----");
            // 匿名方法是一种没有方法名的方法，它允许在使用方法的地方使用方法，但是不需要为方法定义一个名字
            // 匿名方法的声明使用关键字delegate，其一般形式如下：
            // delegate(<参数表>)
            // {
            //     <方法体>
            // }
            // 匿名方法的参数表和方法体与普通方法一样，只是没有方法名
            // 匿名方法的参数表中的参数类型可以省略，编译器会根据委托类型自动推断参数类型
            // 匿名方法的参数表中的参数名可以省略，但是参数类型的声明不能省略
            // 匿名方法的参数表中的参数类型和参数名都可以省略，但是参数的声明顺序不能变
            //Func<int, int, int> plus = Test1;
            Func<int, int, int> plus1 = delegate (int arg1, int arg2)
            {
                return arg1 + arg2;
            };

            Console.WriteLine("-----lambda表达式-----");
            // lambda表达式是一种特殊的匿名方法，它可以用来创建委托或者表达式树
            Func<int, int, int> plus2 = (int arg1, int arg2) => arg1 + arg2;
            // 当只有一个参数时，参数的小括号可以省略，当方法体只有一条语句时，大括号可以省略
            Func<int, int> plus3 = arg1 => arg1 + 1;
            Console.WriteLine(plus2(90,10));

            // 多播委托
            // 多播委托是一个包含了多个方法的委托，当调用这个委托时，会依次调用多个方法
            // 多播委托的声明和普通委托一样，只是在声明委托类型时使用了+=和-=运算符

        }

        private static string GetString()
        {
            return "Hello World";
        }

        private static int Test1(int arg1, int arg2)
        {
            return arg1 + arg2;
        }

        private delegate void PrintStrDelegate();
        private static void PrintStr(PrintStrDelegate del)
        {
            del();
        }

        private static void PrintHello()
        {
            Console.WriteLine("Hello");
        }

        private static void PrintWorld()
        {
            Console.WriteLine("World");
        }

        private static void PrintSth(string str)
        {
            Console.WriteLine(str);
        }
    }
}
