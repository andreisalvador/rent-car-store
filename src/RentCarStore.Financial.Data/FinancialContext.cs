using Microsoft.EntityFrameworkCore;
using RentCarStore.Financial.Data.DataMappers;
using RentCarStore.Financial.Domain;

namespace RentCarStore.Financial.Data
{
    public class FinancialContext : DbContext
    {
        public DbSet<RentRecord> RentRecords { get; set; }

        public FinancialContext(DbContextOptions<FinancialContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentRecordMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}