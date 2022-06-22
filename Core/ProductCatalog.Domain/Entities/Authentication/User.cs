using Microsoft.AspNetCore.Identity;

namespace ProductCatalog.Domain.Entities
{
	public class User : IdentityUser<int>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		#region Offer

		// One to many
		// Offers made by the user himself for different products
		// If user makes an another offer for the same product, the offer is updated. No new offer is added.
		// Collection Navigation Property
		public ICollection<Offer> UserOffers { get; set; }

		#endregion

		#region Product

		// One to many
		// Product belongs to the user 
		// Collection Navigation Property
		public ICollection<Product> Products { get; set; }

		#endregion





	}
}
