using System;

namespace onclass2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("数组数据为：");
            int[] a = new int[] { 2, 4, 6, 7, 9, 17, 23, 25, 26 };
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(" " + a[i]);
            }
            Console.WriteLine();
            int max = a[0];
            for(int i = 1; i < a.Length; i++)
            {
                if (max < a[i])
                    max = a[i];
            }
            int min = a[0];
            for(int i = 1; i < a.Length; i++)
            {
                if (min > a[i])
                    min = a[i];
            }
            int sum=0,average=0;
            for(int i=1;i<a.Length;i++)
            {
                sum += a[i];
                average = sum / a.Length;
            }
            Console.WriteLine("max="+max);
            Console.WriteLine("min=" + min);
            Console.WriteLine("sum=" +sum);
            Console.WriteLine("average" + average);
        }
    }
}
