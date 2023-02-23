using Enoca.Service.Products.Model;

namespace Enoca.Service.Products
{
    public interface IProductQueriesService
    {
        /// <summary>
        /// Gets a product dto
        /// </summary>
        /// <param name="id">product identifier</param>
        /// <returns>Product dto</returns>
        Task<ProductDto> GetAsync(long id);

        /// <summary>
        /// Gets all product dtos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProductDto>> GetAllAsync();
    }
}
