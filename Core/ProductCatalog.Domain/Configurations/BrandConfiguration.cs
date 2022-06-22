using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Configurations
{
	public class BrandConfiguration : IEntityTypeConfiguration<Brand>
	{
		public void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder.HasMany(x => x.Products)
				.WithOne(x => x.Brand)
				.HasForeignKey(x => x.BrandId)
				.IsRequired(false)
				// if there is any product with this brand, restrict brand deleting operation
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.BrandName).HasMaxLength(25).IsRequired();

			#region Data Samples

			builder.HasData
			(
				new Brand { Id = 1, BrandName = "LCWaikiki", CreatedDate = DateTime.Now },
				new Brand { Id = 2, BrandName = "Defacto", CreatedDate = DateTime.Now },
				new Brand { Id = 3, BrandName = "Vakko", CreatedDate = DateTime.Now },
				new Brand { Id = 4, BrandName = "Koton", CreatedDate = DateTime.Now },
				new Brand { Id = 5, BrandName = "Mavi", CreatedDate = DateTime.Now },
				new Brand { Id = 6, BrandName = "Kiğili", CreatedDate = DateTime.Now }
			);

			#endregion

		}
	}
}
