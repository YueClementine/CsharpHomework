using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200316
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            List<OrderItem> list1 = new List<OrderItem>();
            List<OrderItem> list2 = new List<OrderItem>();
            list1.Add(new OrderItem(1,"c#software",235,5));
            list1.Add(new OrderItem(2,"Macbook",10000,1));
            list1.Add(new OrderItem(3, "Surface", 3000, 1));
            list2.Add(new OrderItem(1, "JavaBooks", 25, 6));
            orderService.AddOrder(1, "Customer1", list1);
            orderService.AddOrder(1, "Customer2", list2);

            foreach (Order i in orderService.QueryOrderInCustomer("Customer1")) 
            {
                Console.WriteLine(i);
            }

            orderService.ChangeOrder(1, 2, "Customer1",list2 );

            foreach (Order i in orderService.QueryOrderInCustomer("Customer1"))
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
