using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasMany(x => x.UserOffers)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				// if user has offers, restrict user deleting operation
				.OnDelete(DeleteBehavior.Restrict);


			builder.HasMany(x => x.Products)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				// if user has products, restrict user deleting operation
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.FirstName).IsRequired().HasMaxLength(20);
			builder.Property(x => x.LastName).IsRequired().HasMaxLength(20);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(40);
			


			#region Data Samples

			var hasher = new PasswordHasher<User>();

			builder.HasData
			(
				new User() { Id = 1, FirstName = "Alidia", LastName = "Alvares", Email = "aalvares0@npr.org", EmailConfirmed = true, NormalizedEmail = "AALVARES0@DRUPAL.ORG", UserName = "aalvares0", NormalizedUserName = "AALVARES0", PasswordHash = hasher.HashPassword(null, "Password_123"), SecurityStamp = Guid.NewGuid().ToString("D") }, 
				new User() { Id = 2, FirstName = "Korry", LastName = "Frankowski", Email = "kfrankowski1@typepad.com", EmailConfirmed = true, NormalizedEmail = "KFRANKOWSKI1@PINTEREST.COM", UserName = "kfrankowski1", NormalizedUserName = "KFRANKOWSKI1", PasswordHash = hasher.HashPassword(null, "Password_123"), SecurityStamp = Guid.NewGuid().ToString("D") }, 
				new User() { Id = 3, FirstName = "Wayne", LastName = "Mathen", Email = "wmathen2@shop-pro.jp", EmailConfirmed = true, NormalizedEmail = "WMATHEN2@MIIBEIAN.GOV.CN", UserName = "wmathen2", NormalizedUserName = "WMATHEN2", PasswordHash = hasher.HashPassword(null, "Password_123"), SecurityStamp = Guid.NewGuid().ToString("D") }, 
				new User() { Id = 4, FirstName = "Ginelle", LastName = "Aloshechkin", Email = "galoshechkin3@harvard.edu", EmailConfirmed = true, NormalizedEmail = "GALOSHECHKIN3@SQUIDOO.COM", UserName = "galoshechkin3", NormalizedUserName = "GALOSHECHKIN3", PasswordHash = hasher.HashPassword(null, "Password_123"), SecurityStamp = Guid.NewGuid().ToString("D") }, 
				new User() { Id = 5, FirstName = "Andrei", LastName = "McNutt", Email = "amcnutt4@lulu.com", EmailConfirmed = true, NormalizedEmail = "AMCNUTT4@INDEPENDENT.CO.UK", UserName = "amcnutt4", NormalizedUserName = "AMCNUTT4", PasswordHash = hasher.HashPassword(null, "Password_123"), SecurityStamp = Guid.NewGuid().ToString("D") }, 
				new User() { Id = 6, FirstName = "Harman", LastName = "Ollis", Email = "hollis5@instagram.com", EmailConfirmed = true, NormalizedEmail = "HOLLIS5@TIMESONLINE.CO.UK", UserName = "hollis5", NormalizedUserName = "HOLLIS5", PasswordHash = hasher.HashPassword(null, "Password_123"), SecurityStamp = Guid.NewGuid().ToString("D") }, 
				new User() { Id = 7, FirstName = "Ivar", LastName = "Sate", Email = "isate6@nifty.com", EmailConfirmed = true, NormalizedEmail = "ISATE6@GOOGLE.COM.HK", UserName = "isate6", NormalizedUserName = "ISATE6", PasswordHash = hasher.HashPassword(null, "Password_123"), SecurityStamp = Guid.NewGuid().ToString("D") }
			);

			#endregion

		}
	}
}
