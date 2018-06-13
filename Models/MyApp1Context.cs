using Microsoft.EntityFrameworkCore;

namespace MyApp1.Models
{
    public class MyApp1Context : DbContext
    {
        public MyApp1Context(DbContextOptions<MyApp1Context> options)
            : base(options)
        {
        }

        public DbSet<MyApp1.Models.Jumble> Jumble { get; set; }
       
 
    }
}