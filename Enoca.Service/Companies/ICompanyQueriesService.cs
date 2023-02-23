using Enoca.Service.Companies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Service.Companies
{
    public interface ICompanyQueriesService
    {
        /// <summary>
        /// Gets a company dto
        /// </summary>
        /// <param name="id">Company identifier</param>
        /// <returns>Company dto</returns>
        Task<CompanyDto> GetAsync(long id);

        /// <summary>
        /// Gets all company dtos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CompanyDto>> GetAllAsync();
    }
}
