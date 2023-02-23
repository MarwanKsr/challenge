using Enoca.Core.Base;

namespace Enoca.Service.Products
{
    public interface IProductCommandsService
    {
        /// <summary>
        /// Insert a product
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="companyId"></param>
        /// <param name="stock"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        Task<CommandResult> CreateAsync(string productName, long companyId, int stock, long price);

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productName"></param>
        /// <param name="companyId"></param>
        /// <param name="stock"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        Task<CommandResult> UpdateAsync(long id, string productName, long companyId, int stock, long price);

        /// <summary>
        /// Remove product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CommandResult> DeleteAsync(long id);
    }
}
