using ProductCatalog.Domain.Entities;
using System.Linq.Expressions;

namespace ProductCatalog.Application.Repositories
{
	public interface IProductReadRepository : IReadRepository<Product>
	{
		public Task<IReadOnlyList<Product>> GetAllProducts();
		public Task<Product> GetProductById(int id);
		public Task<IReadOnlyList<Product>> GetAllUserProducts(Expression<Func<Product, bool>> predicate);
		public Task<IReadOnlyList<Product>> GetAllProductsByCategoryId(Expression<Func<Product, bool>> predicate);
		public Task<IReadOnlyList<Product>> GetAllOfferedUserProducts(Expression<Func<Product, bool>> predicate);
		public Task<IReadOnlyList<Product>> GetAllProductsOfferedByUser(Expression<Func<Product, bool>> predicate);
	}
}
