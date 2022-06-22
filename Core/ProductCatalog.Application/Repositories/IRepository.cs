using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Repositories
{
	public interface IRepository<T> where T : EntityBase
	{
		IQueryable<T> Table { get; }
		// Table for only view operations.
		IQueryable<T> TableNoTracking { get; }
	}
}
