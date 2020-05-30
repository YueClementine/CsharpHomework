using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200316
{
    class Order
    {
        public List<OrderItem> orderItemList;
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public double OrderSum { get; set; }
        public DateTime CreateTime { get; set; }

        public Order() { orderItemList = new List<OrderItem>(); CreateTime = DateTime.Now; }
        public Order(int OrderId, string Customer, List<OrderItem> list) 
        {
            this.OrderId = OrderId;
          
            this.Customer = Customer;
            this.orderItemList = list;
            foreach (OrderItem i in orderItemList)
            {
                OrderSum += i.Sum;
            }

        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) 
            {
                Order order = (Order)obj;
                return this.OrderId == order.OrderId;
            }

            return false;
        }
        public override int GetHashCode()
        {
            var hashCode = -531220479;
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Customer);
            hashCode = hashCode * -1521134295 + CreateTime.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return "OrderId: " + OrderId + "  Customer: " + Customer + "  OrderSum:" + OrderSum + " Createtime:"+CreateTime;
        }
    }
}
