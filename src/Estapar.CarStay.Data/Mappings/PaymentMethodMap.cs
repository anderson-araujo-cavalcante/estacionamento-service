using Estapar.CarStay.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estapar.CarStay.Data.Mappings
{
    public class PaymentMethodMap : IEntityTypeConfiguration<PaymentMethod>
    {
        private const string TABLE_NAME = "PaymentMethod";

        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(_ => _.Code);

            builder.Property(_ => _.Code)
                .IsRequired();
        }
    }
}
