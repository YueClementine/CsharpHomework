using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200316
{
    class OrderService
    {
        List<Order> orderList = new List<Order>();

        public void AddOrder(int OrderId, string Customer, List<OrderItem> list) 
        {
            orderList.Add(new Order(OrderId, Customer, list));
        }

        public void DeleteOrder(int orderId) 
        {
            try
            {
                Order orderDelete = QueryOrderInOrderId(orderId);
                orderList.Remove(orderDelete);
            }
            catch (NullReferenceException) 
            {
                Console.WriteLine("Error no order");
            }
        }

        public void ChangeOrder(int oldOrderId, int newOrderId, string newCustomer, List<OrderItem> list) 
        {
            try
            {
                DeleteOrder(oldOrderId);
                AddOrder(newOrderId, newCustomer, list);
            }
            catch (NullReferenceException) 
            {
                Console.WriteLine("Error no order");
            }
        }

        public Order QueryOrderInOrderId(int orderId) 
        {
            var q = from order in orderList
                    where order.OrderId == orderId
                    orderby order.OrderSum
                    select order;
            try
            {
                return q.ToList()[0];
            }
            catch (ArgumentOutOfRangeException) 
            {
                Console.WriteLine("Error Result");
                return null;
            }
           
           
        }

        
        public List<Order> QueryOrderInCustomer(string Customer)
        {
            var q = from order in orderList
                    where order.Customer == Customer
                    orderby order.OrderSum
                    select order;
            return q.ToList();
        }
    }
}
