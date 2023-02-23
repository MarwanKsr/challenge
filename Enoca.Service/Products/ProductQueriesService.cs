using Enoca.Core.Domain.Products;
using Enoca.Data.Base;
using Enoca.Data.Data;
using Enoca.Service.Products.Model;
using Microsoft.EntityFrameworkCore;

namespace Enoca.Service.Products
{
    public class ProductQueriesService : IProductQueriesService
    {
        private readonly IRepository<Product, ApplicationDbContext> _repository;

        public ProductQueriesService(IRepository<Product, ApplicationDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var entities = await _repository.QueryAll().AsNoTracking().ToListAsync();

            return entities.Select(ProductDto.FromEntity).ToList();
        }

        public async Task<ProductDto> GetAsync(long id)
        {
            var entity = await _repository.FirstOrDefaultAsync(e => e.Id == id);

            if (entity is null)
            {
                return default;
            }
            return ProductDto.FromEntity(entity);
        }
    }
}
