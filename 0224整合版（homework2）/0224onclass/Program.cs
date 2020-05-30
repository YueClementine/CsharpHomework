using System;

namespace _0224onclass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数据");
            int j = 2;
            int i = Convert.ToInt32(Console.ReadLine());
            while (i > 1)
            {
                for (j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        Console.WriteLine(j);
                        break;
                    }
                }
                i = i / j;
            }
            Console.WriteLine(j);

        }
    }
}
