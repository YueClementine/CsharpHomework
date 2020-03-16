using System;

namespace _20200308
{
    class Program
    {
        public void sayhello()
        {
            Console.WriteLine("hello");
        }
        public void sayhello(int another)
        {
            Console.WriteLine("hello another man");
        }

        static void Main(string[] args)
        {
            Program a = new Program();
            Console.WriteLine("Hello World!");
            a.sayhello();
            a.sayhello(2);
                 }
    }
}
