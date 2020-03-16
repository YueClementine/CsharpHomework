using OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderSystem
{
    public class Order
    {
    
        public string Name { get; set; }
        public string Id { get; set; }
        public string Client { get; set; }
        
        public int Bill { get; set; }

        public Order(int bi,string a, string b,string c)
        {
            Bill = bi;
            Id = a;
            Name = b;
            Client = c;
        }
        public override string ToString()
        {
            return "Order bill :"+Bill+"OrderId : " + Id + "\n" + "Order : " + Name + "Client: " + Client;
        }
        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            return m != null && m.Bill==Bill && m.Name == Name
              && m.Id == Id && m.Client == Client;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(Id);
        }

    }
    class DuplicateException : ApplicationException
    {
 
    }
    class OrderItem : Order
    {
        public int ItemId { get; set; }

        public string item { get; set; }
    
        public OrderItem(int bill,string a, string b, string c,string i) : base(bill,a,b,c)
        {
            item = i;
        }

   

        public override string ToString()
        {
            return "item: "+item;
        }
        public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m != null && m.item==item;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(Id);
        }
    }




    class Program
    {
        private static int bi;
        private static string a;
        private static string b;
        private static string c;
        private static string i;

        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            Order order=new Order(bi,a,b,c);
            OrderItem orderItem = new OrderItem(bi, a, b, c, i);
            OrderItem o1= new OrderItem(103, "001", "order No.1", "john", "milk");
            OrderItem o2 = new OrderItem(16500, "002", "order No.2", "mike", "PC");
            OrderItem o3 = new OrderItem(87, "003", "order No.3", "jojo", "pencil");
            OrderItem o4 = new OrderItem(22, "004", "order No.4", "tom", "cup");

            OrderItem order1 = new OrderItem(103, "001", "order No.1", "john", "milk");
           
                orderService.Add(o1);
                orderService.Add(order1);
                orderService.Add(o2);
                orderService.Add(o3);
                orderService.Add(o4);

     
            var query = from o in orderService.OrderItemList
                        where o.Id == "001"
                        orderby o.Bill
                        select o;

            foreach (var o in query)
            {
                Console.WriteLine($"{o.Bill}\t{o.Id}\t {o.Name}\t{o.Client}");

            }

        }
    }
}
