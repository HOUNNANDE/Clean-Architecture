using Microsoft.EntityFrameworkCore;
using Sofidy.Unicia.Domain.Entities;
using Unicia.Model.Models;


namespace Sofidy.Unicia.Infrastructure.Persistence.DAL.Context
{
    public class UniciaImportContext : DbContext
    {
        public UniciaImportContext(DbContextOptions<UniciaImportContext> options) : base(options) { }

        public DbSet<AckCache> AckCaches { get; set; } 

        public DbSet<IConvert>  IConverts { get; set; }

        public DbSet<PImport> PImports { get; set; }

        public DbSet<ImportErrorLog> ImportErrorLogs { get; set; }
         
        public DbSet<ImportAgent> ImportAgents { get; set; }

        public DbSet<ImportClient> ImportClients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<PImport>().HasKey(t => new { t.IClient, t.ITyparam });
        }
    }
}
