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

            public void Add(OrderItem orderItem)
            {
               
                try
                {
                var query = from o in OrderItemList
                                orderby o.Bill
                                select o;
                foreach (var o in query)
                {
                        if (o.Bill==orderItem.Bill)
                            throw new DuplicateException();
                    }
                this.OrderItemList.Add(orderItem);
            }
                catch (DuplicateException)
                {
                    Console.WriteLine("订单重复");
                }

             



            }
            public void Remove(OrderItem orderItem)
            {
                this.OrderItemList.Remove(orderItem);
            }


        
        }
}
