using Enoca.Service.Orders.Model;

namespace Enoca.Service.Orders
{
    public interface IOrderQueriesService
    {
        /// <summary>
        /// Gets an order dto
        /// </summary>
        /// <param name="id">product identifier</param>
        /// <returns>Product dto</returns>
        Task<OrderDto> GetAsync(long id);

        /// <summary>
        /// Gets all order dtos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<OrderDto>> GetAllAsync();
    }
}
