using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace OrderSystem
{
   
        class OrderService
        {
            public List<OrderItem> OrderItemList = new List<OrderItem>()
            {

            };
            public List<Order> OrderList = new List<Order>()
            {

            };


        public void Add(OrderItem orderItem)
        {

            try
            {
                var query = from o in OrderItemList
                            orderby o.Bill
                            select o;
                foreach (var o in query)
                {
                    if (o.item == orderItem.item)
                        throw new DuplicateException();
                }
                this.OrderItemList.Add(orderItem);
            }
            catch (DuplicateException)
            {
                Console.WriteLine("订单物品重复");
            }
        }

            public void Add_order(Order order)
            {

                try
                {
                    var query = from o in OrderList
                                orderby o.Bill
                                select o;
                    foreach (var o in query)
                    {
                        if (o.Bill == order.Bill)
                            throw new DuplicateException();
                    }
                    this.OrderList.Add(order);
                }
                catch (DuplicateException)
                {
                    Console.WriteLine("订单重复");
                }


            }
            public void RemoveOrder(Order order)
            {
            this.OrderList.Remove(order);
            }
            public void Remove(OrderItem orderItem)
            {
                this.OrderItemList.Remove(orderItem);
            }


        
        }
}
