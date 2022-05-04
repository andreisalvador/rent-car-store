using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarStore.Financial.Domain;

namespace RentCarStore.Financial.Data.DataMappers
{
    public class RentRecordMapping : IEntityTypeConfiguration<RentRecord>
    {
        public void Configure(EntityTypeBuilder<RentRecord> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
