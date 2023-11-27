using Estapar.CarStay.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estapar.CarStay.Data.Mappings
{
    public class GarageMap : IEntityTypeConfiguration<Garage>
    {
        private const string TABLE_NAME = "Garage";

        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(_ => _.Code);

            builder.Property(_ => _.Code)
                .IsRequired();
        }
    }
}
