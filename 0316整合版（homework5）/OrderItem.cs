using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200316
{
    class OrderItem
    {
        public int OrderItemId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }
        public double Sum{get;}

        public OrderItem(int OrderItemId, string Product, double Price, int Number) 
        {
            this.OrderItemId = OrderItemId;
            this.ProductName = Product;
            this.Price = Price;
            this.Number = Number;
            Sum = Number * Price;
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                OrderItem order = (OrderItem)obj;
                return  this.OrderItemId == order.OrderItemId;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = -2127770830;
            hashCode = hashCode * -1521134295 + OrderItemId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return  " orderItemId:" + OrderItemId + "  product:" + ProductName + "  number:" + Number + "  Sum:" + Sum;
        }
    }
}
