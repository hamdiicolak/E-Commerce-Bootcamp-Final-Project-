using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasMany(x => x.Products)
				.WithOne(x => x.Category)
				.HasForeignKey(x => x.CategoryId)
				// if there is any product with this category, restrict category deleting operation
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
			builder.Property(x => x.Description).HasMaxLength(300).IsRequired();

			#region Data Samples

			builder.HasData
			(
				new Category {Id = 1, Name = "Ayakkabı", Description = "Kategorii Tanımı", CreatedDate = DateTime.Now },
				new Category {Id = 2, Name = "Tişört", Description = "Kategorii Tanımı", CreatedDate = DateTime.Now },
				new Category {Id = 3, Name = "Kot", Description = "Kategorii Tanımı", CreatedDate = DateTime.Now },
				new Category {Id = 4, Name = "Gömlek", Description = "Kategorii Tanımı", CreatedDate = DateTime.Now },
				new Category {Id = 5, Name = "Kazak", Description = "Kategorii Tanımı", CreatedDate = DateTime.Now },
				new Category {Id = 6, Name = "Pantolon", Description = "Kategorii Tanımı", CreatedDate = DateTime.Now },
				new Category {Id = 7, Name = "Ceket", Description = "Kategorii Tanımı", CreatedDate = DateTime.Now },
				new Category {Id = 8, Name = "Şort", Description = "Kategorii Tanımı", CreatedDate = DateTime.Now }
			);

			#endregion

		}
	}
}
