using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasMany(o => o.Offers)
				.WithOne(p => p.Product)
				.HasForeignKey(f => f.ProductId)
				// Delete offers if product is deleted.
				.OnDelete(DeleteBehavior.Cascade);


			builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
			builder.Property(x => x.UserId).IsRequired();
			builder.Property(x => x.CategoryId).IsRequired();
			builder.Property(x => x.UsingStatusId).IsRequired();
			builder.Property(x => x.ImageUrl).IsRequired();
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.IsOfferable).IsRequired();
			builder.Property(x => x.IsSold).IsRequired();
			builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");


			#region Data Samples

			builder.HasData
			(
				new Product { Id = 1, CategoryId = 1, BrandId = 1, UserId = 1, ColorId = 1, UsingStatusId = 1, Name = "Yazlık Ayakkabı", Description = "Kullanıcının ürün e ait tanımı 1", ImageUrl = "ayakkabi1.jpg", Size = "S", Price = 199m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 2, CategoryId = 2, BrandId = 1, UserId = 2, ColorId = 2, UsingStatusId = 2, Name = "Kısa Tişört", Description = "Kullanıcının ürün e ait tanımı 2", ImageUrl = "Tisort1.jpg", Size = "M", Price = 199m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 3, CategoryId = 3, BrandId = 1, UserId = 3, ColorId = 3, UsingStatusId = 3, Name = "Dar Paça Kot", Description = "Kullanıcının ürün e ait tanımı 3", ImageUrl = "Kot1.jpg", Size = "L", Price = 199m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 4, CategoryId = 4, BrandId = 1, UserId = 4, ColorId = 4, UsingStatusId = 4, Name = "Ferah Gömlek", Description = "Kullanıcının ürün e ait tanımı 4", ImageUrl = "Gomlek1.jpg", Size = "XL", Price = 99m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 5, CategoryId = 5, BrandId = 1, UserId = 5, ColorId = 5, UsingStatusId = 5, Name = "Yazlık Kazak ", Description = "Kullanıcının ürün e ait tanımı 5", ImageUrl = "Kazak1.jpg", Size = "XXL", Price = 99m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 6, CategoryId = 6, BrandId = 1, UserId = 6, ColorId = 6, UsingStatusId = 1, Name = "Kışlık Pantolon", Description = "Kullanıcının ürün e ait tanımı 6", ImageUrl = "Pantolon1.jpg", Size = "XS", Price = 99m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 7, CategoryId = 7, BrandId = 1, UserId = 7, ColorId = 7, UsingStatusId = 2, Name = "Kışlık Ceket ", Description = "Kullanıcının ürün e ait tanım ı 7", ImageUrl = "Ceket1.jpg", Size = "S", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 8, CategoryId = 8, BrandId = 1, UserId = 1, ColorId = 8, UsingStatusId = 3, Name = "Deniz Şortu", Description = "Kullanıcının ürün e ait tanım ı 8", ImageUrl = "Sort1.jpg", Size = "M", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 9, CategoryId = 1, BrandId = 1, UserId = 2, ColorId = 9, UsingStatusId = 4, Name = "Kışlık Ayakkabı", Description = "Kullanıcının ürün e ait tanım ı 9", ImageUrl = "ayakkabi2.jpg", Size = "L", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 10, CategoryId = 2, BrandId = 1, UserId = 3, ColorId = 1, UsingStatusId = 5, Name = "Ferah Tişört", Description = "Kullanıcının ürün e ait tanımı 10", ImageUrl = "Tisort2.jpg", Size = "XL", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 11, CategoryId = 3, BrandId = 1, UserId = 4, ColorId = 2, UsingStatusId = 1, Name = "Kışlık Kot", Description = "Kullanıcının ürün e ait tanımı 11", ImageUrl = "Kot2.jpg", Size = "XXL", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 12, CategoryId = 4, BrandId = 1, UserId = 5, ColorId = 3, UsingStatusId = 2, Name = "Uzun Kollu Gömlek", Description = "Kullanıcının ürün e ait tanımı 12", ImageUrl = "Gomlek2.jpg", Size = "XS", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 13, CategoryId = 5, BrandId = 1, UserId = 6, ColorId = 4, UsingStatusId = 3, Name = "Kışlık Kazak Boğazlı", Description = "Kullanıcının ürün e ait tanımı 13", ImageUrl = "Kazak2.jpg", Size = "S", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 14, CategoryId = 6, BrandId = 1, UserId = 7, ColorId = 5, UsingStatusId = 4, Name = "Yazlık Pantolon ", Description = "Kullanıcının ürün e ait tanımı 14", ImageUrl = "Pantolon2.jpg", Size = "M", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 15, CategoryId = 7, BrandId = 1, UserId = 1, ColorId = 6, UsingStatusId = 5, Name = "Basic Ceket", Description = "Kullanıcının ürün e ait tanımı 15", ImageUrl = "Ceket2.jpg", Size = "L", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 16, CategoryId = 8, BrandId = 1, UserId = 2, ColorId = 7, UsingStatusId = 1, Name = "Spor Şortu", Description = "Kullanıcının ürün e ait tanımı 16", ImageUrl = "Sort2.jpg", Size = "XL", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 17, CategoryId = 1, BrandId = 1, UserId = 3, ColorId = 8, UsingStatusId = 2, Name = "Koşu Ayakkabısı", Description = "Kullanıcının ürün e ait tanımı 17", ImageUrl = "ayakkabi3.jpg", Size = "XXL", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 18, CategoryId = 2, BrandId = 1, UserId = 4, ColorId = 9, UsingStatusId = 3, Name = "Termal Tişört", Description = "Kullanıcının ürün e ait tanımı 18", ImageUrl = "Tisort3.jpg", Size = "XS", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 19, CategoryId = 3, BrandId = 1, UserId = 5, ColorId = 1, UsingStatusId = 4, Name = "Likralı Kot", Description = "Kullanıcının ürün e ait tanımı 19", ImageUrl = "Kot3.jpg", Size = "S", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 20, CategoryId = 4, BrandId = 1, UserId = 6, ColorId = 2, UsingStatusId = 5, Name = "Takım Gömleği", Description = "Kullanıcının ürün e ait tanımı 20", ImageUrl = "Gomlek3.jpg", Size = "M", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 21, CategoryId = 5, BrandId = 1, UserId = 7, ColorId = 3, UsingStatusId = 1, Name = "V Yaka Kazak", Description = "Kullanıcının ürün e ait tanımı 21", ImageUrl = "Kazak3.jpg", Size = "L", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 22, CategoryId = 6, BrandId = 1, UserId = 1, ColorId = 4, UsingStatusId = 2, Name = "Kumaş Pantolon", Description = "Kullanıcının ürün e ait tanımı 22", ImageUrl = "Pantolon3.jpg", Size = "XL", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 23, CategoryId = 7, BrandId = 1, UserId = 2, ColorId = 5, UsingStatusId = 3, Name = "Blazer Ceket", Description = "Kullanıcının ürün e ait tanımı 23", ImageUrl = "Ceket3.jpg", Size = "XXL", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 24, CategoryId = 8, BrandId = 1, UserId = 3, ColorId = 6, UsingStatusId = 4, Name = "Koşu Şortu", Description = "Kullanıcının ürün e ait tanımı 24", ImageUrl = "Sort3.jpg", Size = "XS", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 25, CategoryId = 1, BrandId = 1, UserId = 4, ColorId = 7, UsingStatusId = 5, Name = "Sert Kış Botu", Description = "Kullanıcının ürün e ait tanımı 25", ImageUrl = "ayakkabi4.jpg", Size = "S", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 26, CategoryId = 2, BrandId = 1, UserId = 5, ColorId = 8, UsingStatusId = 1, Name = "Polo Yaka Tişört", Description = "Kullanıcının ürün e ait tanımı 26", ImageUrl = "Tisort4.jpg", Size = "M", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 27, CategoryId = 3, BrandId = 1, UserId = 6, ColorId = 9, UsingStatusId = 2, Name = "İspanyol Paça Kot", Description = "Kullanıcının ürün e ait tanımı 27", ImageUrl = "Kot4.jpg", Size = "L", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now },
				new Product { Id = 28, CategoryId = 4, BrandId = 1, UserId = 7, ColorId = 1, UsingStatusId = 3, Name = "Kısa Kollu Gömlek", Description = "Kullanıcının ürün e ait tanımı 28", ImageUrl = "Gomlek4.jpg", Size = "XL", Price = 150m, IsOfferable = true, IsSold = false, CreatedDate = DateTime.Now }
																																												  
			);

			#endregion
		}
	}
}