using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class Context : DbContext{
        public Context(DbContextOptions<Context> options)
            : base(options){
            this.Database.EnsureCreated(); 
        }

        public DbSet<Item> TodoItems { get; set; }
    }
}