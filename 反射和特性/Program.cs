#define DEBUG

using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace 反射和特性
{
    // 程序本身也是数据
    // 有关程序及其类型的数据称为元数据（metadata），他们保存在程序集中
    // 程序在运行时可以查看其他程序集或本身的元数据，这个过程称为反射
    // 通过指定属性的名字来传递参数
    [DengHang("DengHang", version: "V1.0")]
    internal class Program
    {
        static void Main(string[] args)
        {
            // 每一个类对应一个Type对象，这个对象保存了类的元数据
            Car car = new Car("BMW", "red");  // 一个类中的数据存储在对象中，一个类的元数据存储在Type对象中
            Type type = car.GetType();
            Console.WriteLine(type.Name);  // 获取类名
            Console.WriteLine(type.Namespace);  // 获取命名空间
            Console.WriteLine(type.Assembly);

            Console.WriteLine("获取类的属性"); // 有get set方法的是属性
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine(propertyInfo.Name);
            }
            Console.WriteLine("获取类的方法");
            MethodInfo[] methodInfos = type.GetMethods();
            foreach (MethodInfo methodInfo in methodInfos)
            {
                Console.WriteLine(methodInfo.Name);
            }
            Console.WriteLine("获取类的字段");  // 没有get set方法的是字段
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Console.WriteLine(fieldInfo.Name);
            }
            Console.WriteLine("获取类的构造函数");
            ConstructorInfo[] constructorInfos = type.GetConstructors();
            foreach (ConstructorInfo constructorInfo in constructorInfos)
            {
                Console.WriteLine(constructorInfo.Name);
            }
            Console.WriteLine("获取类的特性");
            object[] attributes = type.GetCustomAttributes(false);
            foreach (object attribute in attributes)
            {
                Console.WriteLine(attribute);
            }
            Console.WriteLine("获取类的接口");
            Type[] interfaces = type.GetInterfaces();
            foreach (Type @interface in interfaces)
            {
                Console.WriteLine(@interface.Name);
            }
            Console.WriteLine("获取类的父类");
            Type baseType = type.BaseType;
            Console.WriteLine(baseType.Name);

            Console.WriteLine("程序集");
            Car car1= new Car("BMW", "red");
            Assembly assembly = Assembly.GetAssembly(car1.GetType());  // 获取程序集
            Console.WriteLine($"assembly.FullName{assembly.FullName}");
            Console.WriteLine(assembly.Location);
            Type[] types = assembly.GetTypes();
            Console.WriteLine("程序集中的类");
            foreach (Type type1 in types)
            {
                Console.WriteLine(type1.Name);
            }

            OldMethod();

            Test1();
            Test2();
            Test1();

            PrintOut("PrintOut");

            Type type2 = typeof(Program);
            object[] o = type2.GetCustomAttributes(inherit: false);  // 获取特性
            foreach (object o1 in o)
            {
                Console.WriteLine(o1.ToString());
            }
        }

        [Obsolete("用NewMethod()")]
        static void OldMethod()
        {
            Console.WriteLine("OldMethod");
        }

        static void NewMethod()
        {
            Console.WriteLine("NewMethod");
        }

        //[Conditional("NODEBUG")]
        [Conditional("DEBUG")]
        static void Test1()
        {
            Console.WriteLine("Test1");
        }

        static void Test2()
        {
            Console.WriteLine("Test2");
        }

        // DebuggerStepThrough 调试时跳过此方法 当我们确定这个方法没有问题时，可以加上这个特性
        [DebuggerStepThrough]
        static void PrintOut(string str, 
            [CallerFilePath]string fileName = "",
            [CallerLineNumber]int lineNumber=1,
            [CallerMemberName]string methodName="")
        {
            Console.WriteLine(str);
            Console.WriteLine(fileName);
            Console.WriteLine(lineNumber);
            Console.WriteLine(methodName);
        }

    }
}
