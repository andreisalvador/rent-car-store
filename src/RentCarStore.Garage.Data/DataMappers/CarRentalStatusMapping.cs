using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestCarStore.Garage.Domain;

namespace RentCarStore.Garage.Data.DataMappers
{
    public class CarRentalStatusMapping : IEntityTypeConfiguration<CarRentalStatus>
    {
        public void Configure(EntityTypeBuilder<CarRentalStatus> builder)
        {
            builder.HasKey(c => new { c.Id, c.CarId });
        }
    }
}
