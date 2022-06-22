using Microsoft.AspNetCore.Http;
using ProductCatalog.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatalog.Domain.Entities
{
	public class Product : EntityBase
	{
        public string Name { get; set; }
        public decimal Price { get; set; }
		public bool IsOfferable { get; set; }
        public bool IsSold { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }

        #region Category

        // many to one
        // Simple/Reference Navigation Property
        public Category Category { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        #endregion

        #region User

        // Foreign Key
        public int UserId { get; set; }

        // many(product) to one(user) since 
        // Simple/Reference Navigation Property
        public User User { get; set; }

        #endregion

        #region Offer

        // one to many
        // Collection Navigation Property
        public ICollection<Offer> Offers { get; set; }

        #endregion

        #region Brand

        // many to one
        // Simple/Reference Navigation Property

        public Brand Brand { get; set; }

        // Foreign Key
        public int? BrandId { get; set; }

        #endregion

        #region UsingStatus

        // many to one
        // Simple/Reference Navigation Property
        public UsingStatus UsingStatus { get; set; }
        // Foreign Key
        public int UsingStatusId { get; set; }
        #endregion

        #region Color

        // many to one
        // Simple/Reference Navigation Property
        public Color Color { get; set; }

        // Foreign Key
        public int? ColorId { get; set; }

        #endregion

    }
}
