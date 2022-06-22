namespace ProductCatalog.Domain.Entities
{
	public class UsingStatus : EntityBase
	{
		public string UsingStatusDetail { get; set; }

        #region Product
        // one to many
        // Navigation Property
        // Collection Navigation Property
        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
