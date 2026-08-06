using Microsoft.EntityFrameworkCore;

namespace HelpDeskAPI.Models
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Ticket> Ticket { get; set; }
    }
}
