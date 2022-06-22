using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Configurations
{
	public class OfferConfiguration : IEntityTypeConfiguration<Offer>
	{
		public void Configure(EntityTypeBuilder<Offer> builder)
		{
			#region Data Samples

			builder.HasData
			(
				new Offer { Id = 1, OfferPrice = 150, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 1, UserId = 2 },
				new Offer { Id = 2, OfferPrice = 155, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 2, UserId = 1 },
				new Offer { Id = 3, OfferPrice = 160, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 3, UserId = 4 },
				new Offer { Id = 4, OfferPrice = 165, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 4, UserId = 3 },
				new Offer { Id = 5, OfferPrice = 170, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 5, UserId = 7 },
				new Offer { Id = 6, OfferPrice = 175, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 6, UserId = 5 },
				new Offer { Id = 7, OfferPrice = 180, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 7, UserId = 6 },
				new Offer { Id = 8, OfferPrice = 185, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 8, UserId = 2 },
				new Offer { Id = 9, OfferPrice = 190, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 9, UserId = 1 },
				new Offer { Id = 10, OfferPrice = 150, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 10, UserId = 4 },
				new Offer { Id = 11, OfferPrice = 155, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 11, UserId = 3 },
				new Offer { Id = 12, OfferPrice = 160, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 12, UserId = 7 },
				new Offer { Id = 13, OfferPrice = 165, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 13, UserId = 5 },
				new Offer { Id = 14, OfferPrice = 170, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 14, UserId = 6 },
				new Offer { Id = 15, OfferPrice = 175, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 15, UserId = 2 },
				new Offer { Id = 16, OfferPrice = 180, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 16, UserId = 1 },
				new Offer { Id = 17, OfferPrice = 185, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 17, UserId = 4 },
				new Offer { Id = 18, OfferPrice = 190, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 18, UserId = 3 },
				new Offer { Id = 19, OfferPrice = 130, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 19, UserId = 7 },
				new Offer { Id = 20, OfferPrice = 120, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 20, UserId = 5 },
				new Offer { Id = 21, OfferPrice = 150, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 21, UserId = 6 },
				new Offer { Id = 22, OfferPrice = 155, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 22, UserId = 2 },
				new Offer { Id = 23, OfferPrice = 160, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 23, UserId = 1 },
				new Offer { Id = 24, OfferPrice = 165, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 24, UserId = 4 },
				new Offer { Id = 25, OfferPrice = 170, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 26, UserId = 3 },
				new Offer { Id = 26, OfferPrice = 175, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 26, UserId = 7 },
				new Offer { Id = 27, OfferPrice = 180, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 27, UserId = 5 },
				new Offer { Id = 28, OfferPrice = 185, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 28, UserId = 6 },
				new Offer { Id = 29, OfferPrice = 190, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 3, UserId = 2 },
				new Offer { Id = 30, OfferPrice = 170, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 4, UserId = 1 },
				new Offer { Id = 31, OfferPrice = 150, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 1, UserId = 4 },
				new Offer { Id = 32, OfferPrice = 155, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 2, UserId = 3 },
				new Offer { Id = 33, OfferPrice = 160, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 6, UserId = 7 },
				new Offer { Id = 34, OfferPrice = 165, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 7, UserId = 5 },
				new Offer { Id = 35, OfferPrice = 170, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 5, UserId = 6 },
				new Offer { Id = 36, OfferPrice = 175, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 10, UserId = 2 },
				new Offer { Id = 37, OfferPrice = 180, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 11, UserId = 1 },
				new Offer { Id = 38, OfferPrice = 185, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 8, UserId = 4 },
				new Offer { Id = 39, OfferPrice = 190, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 9, UserId = 3 },
				new Offer { Id = 40, OfferPrice = 150, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 13, UserId = 7 },
				new Offer { Id = 41, OfferPrice = 155, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 14, UserId = 5 },
				new Offer { Id = 42, OfferPrice = 160, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 12, UserId = 6 },
				new Offer { Id = 43, OfferPrice = 165, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 17, UserId = 2 },
				new Offer { Id = 44, OfferPrice = 170, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 18, UserId = 1 },
				new Offer { Id = 45, OfferPrice = 175, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 15, UserId = 4 },
				new Offer { Id = 46, OfferPrice = 180, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 16, UserId = 3 },
				new Offer { Id = 47, OfferPrice = 185, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 20, UserId = 7 },
				new Offer { Id = 48, OfferPrice = 190, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 21, UserId = 5 },
				new Offer { Id = 49, OfferPrice = 150, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 19, UserId = 6 },
				new Offer { Id = 50, OfferPrice = 155, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 24, UserId = 1 },
				new Offer { Id = 51, OfferPrice = 160, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 26, UserId = 2 },
				new Offer { Id = 52, OfferPrice = 165, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 22, UserId = 4 },
				new Offer { Id = 53, OfferPrice = 170, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 23, UserId = 3 },
				new Offer { Id = 54, OfferPrice = 175, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 27, UserId = 7 },
				new Offer { Id = 55, OfferPrice = 180, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 28, UserId = 5 },
				new Offer { Id = 56, OfferPrice = 185, OfferApproved = false, CreatedDate = DateTime.Now, ProductId = 26, UserId = 6 }
			);									  

			#endregion
		}
	}
}
