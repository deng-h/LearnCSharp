using System.Collections;

namespace 泛型
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 3 };
            foreach(int i in ints)
            {
                Console.WriteLine(i);
            }

            List<string> strings = new List<string> { "a", "b", "c" };
            foreach(string s in strings)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("------------泛型dictionary<K,V>-----------------");
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("1", 1);
            dic.Add("2", 2);
            dic.Add("3", 3);
            foreach(KeyValuePair<string, int> kv in dic)
            {
                Console.WriteLine(kv.Key + " " + kv.Value);
            }

            Console.WriteLine("----------自定义泛型------------");
        }
    }
}
