using Enoca.Core.Base;

namespace Enoca.Service.Orders
{
    public interface IOrderCommandService
    {
        /// <summary>
        /// Insert an order
        /// </summary>
        /// <param name="nameOfPerson"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<CommandResult> CreateAsync(string nameOfPerson, long productId);

        /// <summary>
        /// Remove order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CommandResult> DeleteAsync(long id);
    }
}
