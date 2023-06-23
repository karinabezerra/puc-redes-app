using Microsoft.EntityFrameworkCore;
using Puc.Web.Entities;

namespace Puc.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ativo> Ativos => Set<Ativo>();
    }
}