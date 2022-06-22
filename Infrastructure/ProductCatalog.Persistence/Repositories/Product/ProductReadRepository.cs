using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;
using System.Linq.Expressions;

namespace ProductCatalog.Persistence.Repositories
{
	public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
	{
        private readonly ProductCatalogDbContext _context;

        public ProductReadRepository(ProductCatalogDbContext context) : base(context)
        {
            _context = context;
        }

		public async Task<IReadOnlyList<Product>> GetAllOfferedUserProducts(Expression<Func<Product, bool>> predicate)
		{
            return await _context.Products
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .Include(x => x.Brand)
                    .Include(x => x.UsingStatus)
                    .Include(x => x.Color)
                    .Where(predicate)
                    .ToListAsync();
        }

		public async Task<IReadOnlyList<Product>> GetAllProducts()
        {
            return await _context.Products
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .Include(x => x.Brand)
                    .Include(x => x.UsingStatus)
                    .Include(x => x.Color)
                    .ToListAsync();
        }

		public async Task<IReadOnlyList<Product>> GetAllProductsByCategoryId(Expression<Func<Product, bool>> predicate)
		{
            return await _context.Products
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .Include(x => x.Brand)
                    .Include(x => x.UsingStatus)
                    .Include(x => x.Color)
                    .Where(predicate)
                    .ToListAsync();
        }

		public async  Task<IReadOnlyList<Product>> GetAllProductsOfferedByUser(Expression<Func<Product, bool>> predicate)
		{
            return await _context.Products
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .Include(x => x.Brand)
                    .Include(x => x.UsingStatus)
                    .Include(x => x.Color)
                    .Where(predicate)
                    .ToListAsync();
        }

		public async Task<IReadOnlyList<Product>> GetAllUserProducts(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .Include(x => x.Brand)
                    .Include(x => x.UsingStatus)
                    .Include(x => x.Color)
                    .Where(predicate)
                    .ToListAsync();
        }

		public async Task<Product> GetProductById(int id)
        {
            return await _context.Products
                    .Include(x => x.User)
                    .Include(x => x.Category)
                    .Include(x => x.Brand)
                    .Include(x => x.Color)
                    .Include(x => x.UsingStatus)
                    .FirstOrDefaultAsync(x => x.Id == id) ?? new Product();
        }
    }
}

