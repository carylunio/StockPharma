using Microsoft.EntityFrameworkCore;

using StockPharma.Core.Entities;

namespace StockPharma.Infrastructure
{
    public class StockPharmaContext : DbContext
    {
        public StockPharmaContext(DbContextOptions<StockPharmaContext> options) : base(options)
        {

        }

        public DbSet<Medicament> medicaments { get; set; }
    }
}
