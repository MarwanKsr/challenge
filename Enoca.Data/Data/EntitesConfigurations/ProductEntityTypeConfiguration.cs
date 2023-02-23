using Enoca.Core.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enoca.Data.Data.EntitesConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(e => e.Company).AutoInclude();

        }
    }
}
