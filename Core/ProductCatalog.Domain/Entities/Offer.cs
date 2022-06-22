using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Entities
{
	public class Offer : EntityBase
	{
        public int OfferPrice { get; set; }
        public bool OfferApproved { get; set; }

        #region Product

        // Foreign Key
        public int ProductId { get; set; }
        // many(Offer) to one(Product)
        // Simple/Reference Navigation Property
        public Product Product { get; set; }

        #endregion

        #region User

        // Foreign Key
        public int UserId { get; set; }
        // many(Offer) to one(User) for different products
        // Simple/Reference Navigation Property
        public User User { get; set; }

        #endregion
    }
}
