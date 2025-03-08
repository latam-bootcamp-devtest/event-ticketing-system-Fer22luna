

using EventTicketSystem.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace EventTicketSystem.Server.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Event> Events { get; set; }


    }
}
