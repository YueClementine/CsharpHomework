using System;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0, num2 = 0;
            Console.WriteLine("输入第一个数字");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入第二个数字");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请选择何种运算");
            Console.WriteLine("options:");
            Console.WriteLine("+");
            Console.WriteLine("-");
            Console.WriteLine("*");
            Console.WriteLine("/");
            Console.Write("Your option? ");

            string a = Console.ReadLine();
            switch (a)
            {
                case "+":
                    Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
                    break;
                case "-":
                    Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
                    break;
                case "*":
                    Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
                    break;
                case "/":
                    Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
                    break;

            }
        }
    }
}
