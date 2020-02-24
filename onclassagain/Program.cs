using System;

namespace onclassagain
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[105];
            for (int i = 2; i < a.Length; i++)
            {
                a[i] = 1;
            }
            for (int i = 2; i <= 100; i++)
            {
                if (a[i] == 1)
                {
                    int j = i + 1;
                    while (j <= 100)
                    {
                        if (a[j] == 1 && j % i == 0)
                        {
                            a[j] = 0;
                        }
                        j++;
                    }
                }
            }
            for (int i = 2; i < 101; i++) if (a[i] == 1)
                    Console.WriteLine(i);

        }
    }
}
