namespace 数据结构与算法_归并排序
{
    // 归并排序
    // 1. 分解：将待排序的n个元素分成各含n/2个元素的子序列
    // 2. 解决：使用归并排序递归地排序两个子序列
    // 3. 合并：合并两个已排序的子序列以产生已排序的答案
    // 时间复杂度：O(nlogn)
    // 空间复杂度：O(n)
    // 采用分治法（Divide and Conquer）思想
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = [1, 3, 5, 7, 9, 2, 4, 6, 8, 10];
            MergeSort(ints, 0, ints.Length - 1);
            Print(ints);
        }

        private static void MergeSort(int[] ints, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                MergeSort(ints, p, q);
                MergeSort(ints, q + 1, r);
                // 把ints[r, q]和ints[q+1, r]这两个数组合并，结果复制到ints
                Merge(ints, p, q, r);
            }
        }

        private static void Merge(int[] ints, int p, int q, int r)
        {
            int[] left = new int[q - p + 2];
            int[] right = new int[r - q + 1];
            for (int i = 0; i < left.Length - 1; i++)
            {
                left[i] = ints[p + i];
            }
            left[left.Length - 1] = int.MaxValue;

            for (int i = 0; i < right.Length - 1; i++)
            {
                right[i] = ints[q + 1 + i];
            }
            right[right.Length - 1] = int.MaxValue;

            int m = 0, n = 0;
            for (int i = p; i <= r; i++)
            {
                if (left[m] < right[n])
                {
                    ints[i] = left[m];
                    m++;
                }
                else
                {
                    ints[i] = right[n];
                    n++;
                }
            }
        }

        private static void Print(int[] ints)
        {
            foreach (var i in ints)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
