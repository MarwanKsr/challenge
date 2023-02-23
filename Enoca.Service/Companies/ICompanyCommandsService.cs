using Enoca.Core.Base;

namespace Enoca.Service.Companies
{
    public interface ICompanyCommandsService
    {
        /// <summary>
        /// Insert a company
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="approvalStatus"></param>
        /// <param name="orderStartTime"></param>
        /// <param name="orderEndTime"></param>
        /// <returns></returns>
        Task<CommandResult> CreateAsync(string companyName, bool approvalStatus, DateTime orderStartTime, DateTime orderEndTime);

        /// <summary>
        /// Updates a company
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyName"></param>
        /// <param name="approvalStatus"></param>
        /// <param name="orderStartTime"></param>
        /// <param name="orderEndTime"></param>
        /// <returns></returns>
        Task<CommandResult> UpdateAsync(long id, string companyName, bool approvalStatus, DateTime orderStartTime, DateTime orderEndTime);

        /// <summary>
        /// Remove company by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CommandResult> DeleteAsync(long id);
    }
}
