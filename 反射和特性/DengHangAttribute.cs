namespace 反射和特性
{
    // 特性类必须以Attribute结尾
    // 需要继承Attribute类
    // sealed表示该类不能被继承 一般声明为sealed
    // 一般只定义字段或者属性，不定义方法
    // 只能在方法上使用该特性
    [AttributeUsage(AttributeTargets.Class)]
    sealed class DengHangAttribute : Attribute
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public DengHangAttribute(string name, string version)
        {
            Name = name;
            Version = version;
        }
    }
}
