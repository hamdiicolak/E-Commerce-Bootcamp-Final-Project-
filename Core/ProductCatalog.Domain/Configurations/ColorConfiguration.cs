using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Configurations
{
	public class ColorConfiguration : IEntityTypeConfiguration<Color>
	{
		public void Configure(EntityTypeBuilder<Color> builder)
		{
			builder.HasMany(x => x.Products)
				.WithOne(x => x.Color)
				.HasForeignKey(x => x.ColorId)
				.IsRequired(false)
				// if there is any product with this Color, restrict color deleting operation
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.ColorName).HasMaxLength(25).IsRequired();

			#region Data Samples

			builder.HasData
			(
				new Color { Id = 1, ColorName = "Mavi",  CreatedDate = DateTime.Now },
				new Color { Id = 2, ColorName = "Yeşil",  CreatedDate = DateTime.Now },
				new Color { Id = 3, ColorName = "Kırmızı",  CreatedDate = DateTime.Now },
				new Color { Id = 4, ColorName = "Sarı",  CreatedDate = DateTime.Now },
				new Color { Id = 5, ColorName = "Kahverengi",  CreatedDate = DateTime.Now },
				new Color { Id = 6, ColorName = "Mor",  CreatedDate = DateTime.Now },
				new Color { Id = 7, ColorName = "Gri",  CreatedDate = DateTime.Now },
				new Color { Id = 8, ColorName = "Siyah",  CreatedDate = DateTime.Now },
				new Color { Id = 9, ColorName = "Beyaz",  CreatedDate = DateTime.Now }
			);

			#endregion
		}
	}
}
