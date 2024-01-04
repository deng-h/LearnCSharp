using System.Collections;

namespace 数据结构与算法_快速排序
{
    // 快速排序（Quick Sort）是一种高效的排序算法，它采用分治的思想
    // 通过将数组分成两部分并递归地对每部分进行排序，最终实现整个数组的排序
    // 选择数组中的第一个元素作为基准点（pivot）然后将数组分为两部分
    // 一部分包含所有小于等于基准点的元素，另一部分包含所有大于基准点的元素
    // 递归地对这两部分进行快速排序，最终将它们合并在一起，得到有序的数组
    // 需要注意的是，快速排序的性能取决于选择的基准点。在这个实现中，选择了数组的第一个元素作为基准点
    // 而实际应用中可能采用其他方法来选择更好的基准点，以提高算法的效率。
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = [1, 3, 5, 7, 9, 2, 4, 6, 8, 10];
            QuickSort(ints, 0, ints.Length - 1);
            Print(ints);
        }

        private static void QuickSort(int[] ints, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(ints, p, r);
                QuickSort(ints, p, q - 1);
                QuickSort(ints, q + 1, r);
            }
        }

        private static int Partition(int[] ints, int p, int r)
        {
            // 选择第一个元素作为基准点 枢值pivot
            int pivot = ints[r];
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                // 如果当前值小于等于pivot，就把当前值放到i的位置，i++
                if (ints[j] <= pivot)
                {
                    i++;
                    Swap(ints, i, j);
                }
            }
            
            Swap(ints, i + 1, r);
            return i + 1;
        }

        private static void Swap(int[] ints, int i, int j)
        {
            // 使用元组来交换ints[i]和ints[j] 好甜的语法糖
            (ints[j], ints[i]) = (ints[i], ints[j]);
            //int temp = ints[i];
            //ints[i] = ints[j];
            //ints[j] = temp;
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
