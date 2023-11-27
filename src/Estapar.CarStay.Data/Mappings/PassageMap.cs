using Estapar.CarStay.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estapar.CarStay.Data.Mappings
{
    public class PassageMap : IEntityTypeConfiguration<Passage>
    {
        private const string TABLE_NAME = "Passage";

        public void Configure(EntityTypeBuilder<Passage> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(_ => _.Code);

            builder.Property(_ => _.Code)
                .IsRequired();

            builder.HasOne(u => u.PaymentMethod)
                .WithMany()
                .HasForeignKey(u => u.PaymentMethodCode)
                .IsRequired(true);

            builder.HasOne(u => u.Garage)
                .WithMany()
                .HasForeignKey(u => u.GarageCode)
                .IsRequired(true);
        }
    }
}
