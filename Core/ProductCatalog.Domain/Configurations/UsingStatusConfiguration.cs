using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Configurations
{
	public class UsingStatusConfiguration : IEntityTypeConfiguration<UsingStatus>
	{
		public void Configure(EntityTypeBuilder<UsingStatus> builder)
		{
			builder.HasMany(x => x.Products)
				.WithOne(x => x.UsingStatus)
				.HasForeignKey(x => x.UsingStatusId)
				// if there is any product with this UsinStatus, restrict UsinStatus deleting operation
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.UsingStatusDetail).HasMaxLength(30);

			#region Data Samples

			builder.HasData
			(
				new UsingStatus { Id = 1, UsingStatusDetail = "Az kullanılmış defalu" },
				new UsingStatus { Id = 2, UsingStatusDetail = "Çok kullanılmış defalu" },
				new UsingStatus { Id = 3, UsingStatusDetail = "Yeni & Etiketli" },
				new UsingStatus { Id = 4, UsingStatusDetail = "Çok fazla kullanılmış defalu" },
				new UsingStatus { Id = 5, UsingStatusDetail = "Çok Az kullanılmış defalu" }
			);

			#endregion
		}
	}
}
