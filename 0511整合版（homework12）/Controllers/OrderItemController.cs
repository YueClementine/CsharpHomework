using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController: ControllerBase
    {
        private readonly OrderContext orderDB;

        public OrderItemController(OrderContext context)
        {
            this.orderDB = context;
            IQueryable<Order> query = orderDB.Orders;
        }
    }


}
