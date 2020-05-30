using Microsoft.EntityFrameworkCore;


namespace Api
{
    public class OrderContext : DbContext
    {

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
