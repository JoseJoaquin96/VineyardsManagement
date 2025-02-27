using Microsoft.EntityFrameworkCore;
using VineyardsManagement.Models;

namespace VineyardsManagement.DB
{
    public class VineyardDBContext: DbContext
    {
        public VineyardDBContext(DbContextOptions<VineyardDBContext> options) : base(options) { }

        // Tablas utilizadas en el proyecto
        public DbSet<Managers> Managers { get; set; }
        public DbSet<Grapes> Grapes { get; set; }
        public DbSet<Parcels> Parcels { get; set; }
        public DbSet<Vineyards> Vineyards { get; set; }
    }
}
