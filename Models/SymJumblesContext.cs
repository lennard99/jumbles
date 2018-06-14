using Microsoft.EntityFrameworkCore;

namespace SymJumbles.Models
{
    public class SymJumblesContext : DbContext
    {
        public SymJumblesContext(DbContextOptions<SymJumblesContext> options)
            : base(options)
        {
        }

        public DbSet<SymJumbles.Models.Jumble> Jumble { get; set; }               
        public DbSet<SymJumbles.Models.IncomingMessage> IncomingMessage { get; set; }               
       
 
    }
}