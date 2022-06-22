using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Configurations;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Persistence.Contexts
{
	public class ProductCatalogDbContext : IdentityDbContext<User, Role, int>
	{
		public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options) : base(options)
		{
		}

		#region Entity Collections

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Offer> Offers { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<UsingStatus> UsingStatuses { get; set; }
		public DbSet<Color> Colors { get; set; }

        #endregion


        #region Overrideing the SaveChangesAsync

        // Overrideing the SaveChangesAsync function to add time information to the entities 
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion


        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new UsingStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
