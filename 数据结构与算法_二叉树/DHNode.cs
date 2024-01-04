namespace 数据结构与算法_二叉树
{
    internal class DHNode<T>
    {
        public T Data { get; set; }
        public DHNode<T>? Left { get; set; }
        public DHNode<T>? Right { get; set; }

        public DHNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
