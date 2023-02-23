using Enoca.Core.Domain.Orders;
using Enoca.Data.Base;
using Enoca.Data.Data;
using Enoca.Service.Orders.Model;
using Microsoft.EntityFrameworkCore;

namespace Enoca.Service.Orders
{
    public class OrderQueriesService : IOrderQueriesService
    {
        private readonly IRepository<Order, ApplicationDbContext> _repository;

        public OrderQueriesService(IRepository<Order, ApplicationDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var entites = await _repository.QueryAll().AsNoTracking().ToListAsync();

            return entites.Select(OrderDto.FromEntity).ToList();
        }

        public async Task<OrderDto> GetAsync(long id)
        {
            var entity = await _repository.FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
            {
                return default;
            }
            return OrderDto.FromEntity(entity);
        }
    }
}
