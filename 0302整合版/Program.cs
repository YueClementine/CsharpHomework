using FakeItEasy;
using System;

namespace _20200302_1
{
    class Program
    {
        public interface shapeFactory
        {

            void ability();
        }
        interface area
        {
            void Cal_area();
        }
        interface check{
            bool check_shape();
        }
        public class Rectangle : area, check, shapeFactory
        {          
            public int width { set; get; }
            public int height { set; get; }

            public void ability()
            {
                Console.WriteLine("已经实现长方形");
            }

            public void Cal_area()
            {
                Console.WriteLine(width * height);
            }

            public bool check_shape()
            {
                if ((width == height) && (width >= 0) && (height >= 0))
                    return false;
                else return true;
            }
            
        }
        public class Triangle: area ,check,shapeFactory
        {
           
            public int a { set; get; }
            public int b { set; get; }
            public int c{ set; get; }

            public void ability()
            {
                Console.WriteLine("已经实现三角形");
            }

            public void Cal_area()
            {
                double s = (a + b + c) / 2.0;
                double v = s * (s - a) * (s - b) * (s - c);
                Console.WriteLine(v);
            }

            public bool check_shape()
            {
                if ((a >= 0 &&b >= 0&&c>=0) &&((a + b) > c && (a + c > b) && (b + c) > a))
                    return true;
                else return false;
              
            }
        }
        public class Square : area, check,shapeFactory
        {           
            public int side { set; get; }

            public void ability()
            {
                Console.WriteLine("已经实现正方形");
            }

            public void Cal_area()
            {
                Console.WriteLine(side * side);
            }

            public bool check_shape()
            {
                if ((side == side)&&(side>=0))
                    return true;
                else return false;             
            }
        }
    


        static void Main(string[] args)
        {
            Console.WriteLine("1.Rectangle");
            Console.WriteLine("2.Triangle");
            Console.WriteLine("3.Square");
            int i = Convert.ToInt32(Console.ReadLine());
            switch(i)
            {
                case 1:
                    Rectangle R = new Rectangle();
                    Console.WriteLine("请输入长方形的宽"); 
                    R.width = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("请输入长方形的长");
                    R.height = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("该长方形是否合法");
                    Console.WriteLine(R.check_shape());
                    if (R.check_shape())
                        Console.WriteLine("该长方形面积是");
                        R.Cal_area();
                    break;
                case 2:
                    Triangle T = new Triangle();
                    Console.WriteLine("请输入三角形的A边");
                    T.a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("请输入三角形的B边");
                    T.b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("请输入三角形的C边");
                    T.c = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("该三角形是否合法");
                    Console.WriteLine(T.check_shape());
                    if (T.check_shape())
                        Console.WriteLine("该三角形面积是");
                        T.Cal_area();
                    break;
                case 3:
                    Square S = new Square();
                    Console.WriteLine("请输入正方形的边长");
                    S.side= Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("该正方形是否合法");
                    Console.WriteLine(S.check_shape());
                    if (S.check_shape())
                        Console.WriteLine("该正方形面积是");
                    S.Cal_area();
                    break;        
                  

            }
        }
    }
}
