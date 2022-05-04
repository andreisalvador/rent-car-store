using Microsoft.EntityFrameworkCore;
using RentCarStore.Garage.Data.DataMappers;
using RestCarStore.Garage.Domain;

namespace RentCarStore.Garage.Data
{
    public class GarageContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public GarageContext(DbContextOptions<GarageContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}