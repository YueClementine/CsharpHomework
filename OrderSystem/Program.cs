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
        public Order()
        {

        }
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
    public class OrderItem : Order 
    {
        public int ItemId { get; set; }

        public string item { get; set; }
    
        public OrderItem(int bill,string a, string b, string c,string i) : base(bill,a,b,c)
        {
            item = i;
        }

        public OrderItem()
        {

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
            Order Order1 = new Order(103, "001", "order No.1", "john");
            Order Order2 = new Order(16500, "002", "order No.2", "mike");
            Order Order3 = new Order(87, "003", "order No.3", "jojo");
            Order Order4 = new Order(22, "004", "order No.4", "tom");
           OrderItem I1= new OrderItem(103, "001", "order No.1", "john", "milk");
            OrderItem I2 = new OrderItem(16500, "002", "order No.2", "mike", "PC");
            OrderItem I3 = new OrderItem(87, "003", "order No.3", "jojo", "pencil");
            OrderItem I4 = new OrderItem(22, "004", "order No.4", "tom", "cup");

            OrderItem Item1 = new OrderItem(103, "001", "order No.1", "john", "milk");

            orderService.Add_order(Order1);
            orderService.Add_order(Order2);
            orderService.Add_order(Order3);
            orderService.Add_order(Order4);

            orderService.Add(I1);
                orderService.Add(Item1);
                orderService.Add(I2);
                orderService.Add(I3);
                orderService.Add(I4);

     
            var query = from o in orderService.OrderItemList
                        where o.Id == "001"
                        orderby o.Bill
                        select o;

            foreach (var o in query)
            {
                Console.WriteLine($"{o.Bill}\t{o.Id}\t {o.Name}\t{o.Client}");

            }
            XmlSerializer.Export("text.xml", I1, I1.GetType());
            XmlSerializer.Export("test.xml", Order1, Order1.GetType());
        }
    }
}
