using System.Collections;

namespace 数据结构与算法_二叉树
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DHNode<int> root = new DHNode<int>(1);
            root.Left = new DHNode<int>(2);
            root.Right = new DHNode<int>(3);
            root.Left.Left = new DHNode<int>(4);
            root.Left.Right = new DHNode<int>(5);
            root.Right.Left = new DHNode<int>(6);
            root.Right.Right = new DHNode<int>(7);
            root.Left.Left.Left = new DHNode<int>(8);
            root.Left.Left.Right = new DHNode<int>(9);
            root.Left.Right.Left = new DHNode<int>(10);
            root.Left.Right.Right = new DHNode<int>(11);
            root.Right.Left.Left = new DHNode<int>(12);
            root.Right.Left.Right = new DHNode<int>(13);
            root.Right.Right.Left = new DHNode<int>(14);
            root.Right.Right.Right = new DHNode<int>(15);
            // 生成一棵二叉树
            //          1
            //      2       3
            //   4    5   6   7
            // 8  9 10 11 12 13 14 15
            // ------------------------------------------------------------
            Console.WriteLine("PreOrder");
            PreOrder(root);
            Console.WriteLine();
            Console.WriteLine("InOrder");
            InOrder(root);
            Console.WriteLine();
            Console.WriteLine("PostOrder");
            PostOrder(root);
            // ------------------------------------------------------------

            Console.WriteLine();
            Console.WriteLine("PreOrderUnRecur");
            PreOrderUnRecur(root);
            Console.WriteLine("PostOrderUnRecur");
            PostOrderUnRecur(root);
            Console.WriteLine("InOrderUnRecur");
            InOrderUnRecur(root);
            Console.WriteLine("BFS");
            BFS(root);

            Console.ReadKey();
        }

        // 先序遍历，对于每一个子树，都是先打印根节点，再打印左子树，最后打印右子树
        private static void PreOrder(DHNode<int> head)
        {
            if (head == null) return;
            Console.Write(head.Data + " ");
            PreOrder(head.Left);
            PreOrder(head.Right);
        }

        // 中序遍历，对于每一个子树，都是先打印左子树，再打印根节点，最后打印右子树
        private static void InOrder(DHNode<int> head)
        {
            if (head == null) return;
            InOrder(head.Left);
            Console.Write(head.Data + " ");
            InOrder(head.Right);
        }

        // 后序遍历，对于每一个子树，都是先打印左子树，再打印右子树，最后打印根节点
        private static void PostOrder(DHNode<int> head)
        {
            if (head == null) return;
            PostOrder(head.Left);
            PostOrder(head.Right);
            Console.Write(head.Data + " ");
        }

        // 非递归先序遍历
        private static void PreOrderUnRecur(DHNode<int> head)
        {
            if (head != null)
            {
                Stack<DHNode<int>> stack = new Stack<DHNode<int>>();
                stack.Push(head);
                while (stack.Count != 0)
                {
                    head = stack.Pop();
                    Console.Write(head.Data + " ");
                    // 先压右子树，再压左子树，这样出栈的时候就是先左后右
                    if (head.Right != null)
                    {
                        stack.Push(head.Right);
                    }
                    if (head.Left != null)
                    {
                        stack.Push(head.Left);
                    }
                }
            }
            Console.WriteLine();
        }

        // 非递归后序遍历
        private static void PostOrderUnRecur(DHNode<int> head)
        {
            if (head != null)
            {
                Stack<DHNode<int>> stack1 = new Stack<DHNode<int>>();
                Stack<DHNode<int>> stack2 = new Stack<DHNode<int>>();
                stack1.Push(head);
                while (stack1.Count != 0)
                {
                    head = stack1.Pop();
                    stack2.Push(head);
                    // 先压左子树，再压右子树，这样出栈的时候就是先右后左
                    if (head.Left != null)
                    {
                        stack1.Push(head.Left);
                    }
                    if (head.Right != null)
                    {
                        stack1.Push(head.Right);
                    }
                }
                while (stack2.Count != 0)
                {
                    Console.Write(stack2.Pop().Data + " ");
                }
            }
            Console.WriteLine();
        }

        // 非递归中序遍历
        private static void InOrderUnRecur(DHNode<int> head)
        {
            if (head != null)
            {
                Stack<DHNode<int>> stack1 = new();
                while(stack1.Count != 0 || head != null)
                {
                    if (head != null)
                    {
                        stack1.Push(head);  // 一直压左子树
                        head = head.Left;
                    }
                    else
                    {
                        head = stack1.Pop();  // 左子树压完了，出栈，打印，然后压右子树
                        Console.Write(head.Data + " ");
                        head = head.Right;  // 移动到右子树，继续一直压左子树
                    }
                }
            }
            Console.WriteLine();
        }

        // BFS
        private static void BFS(DHNode<int> head)
        {
            if (head == null) return;
            Queue<DHNode<int>> queue = new();
            queue.Enqueue(head);
            while (queue.Count != 0)
            {
                head = queue.Dequeue();
                Console.Write(head.Data + " ");
                if (head.Left != null)
                {
                    queue.Enqueue(head.Left);
                }
                if (head.Right != null)
                {
                    queue.Enqueue(head.Right);
                }
            }
            Console.WriteLine();
        }

        // 得到二叉树的宽度 还未理解
        private static void GetWidthOfTree(DHNode<int> head)
        {
            if (head == null) return;
            Queue<DHNode<int>> queue = new();
            queue.Enqueue(head);
            Hashtable levelTable = new();
            levelTable.Add(head, 1);
            int curLevel = 1;
            int curLevelNodes = 0;
            int max = 0;
            while (queue.Count != 0)
            {
                head = queue.Dequeue();

                int curNodeLevel = (int)levelTable[head];
                if (curNodeLevel == curLevel)
                {
                    curLevelNodes++;
                }
                else
                {
                    max = Math.Max(max, curLevelNodes);
                    curLevel++;
                    curLevelNodes = 1;
                }
                if (head.Left != null)
                {
                    levelTable.Add(head.Left, curLevel + 1);
                    queue.Enqueue(head.Left);
                }
                if (head.Right != null)
                {
                    levelTable.Add(head.Right, curLevel + 1);
                    queue.Enqueue(head.Right);
                }
            }
            Console.WriteLine($"树的最大宽度为{levelTable.Values}");
        }

    }
}
