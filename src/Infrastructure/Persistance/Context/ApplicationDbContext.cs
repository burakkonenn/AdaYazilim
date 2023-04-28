using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }
        public DbSet<Train> Train { get; set; }
        public DbSet<Vagon> Vagon { get; set; }

    }
}
