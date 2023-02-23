using Enoca.Core.Base;
using Enoca.Core.Domain.Companies;
using Enoca.Core.Resources;
using Enoca.Data.Base;
using Enoca.Data.Data;

namespace Enoca.Service.Companies
{
    public class CompanyCommandsService : ICompanyCommandsService
    {
        private readonly IRepository<Company, ApplicationDbContext> _repository;

        public CompanyCommandsService(IRepository<Company, ApplicationDbContext> repository)
        {
            _repository = repository;
        }

        private async Task<Company> GetAsync(long id)
           => await _repository.FindDetachedAsync(id);
        public async Task<CommandResult> CreateAsync(string companyName, bool approvalStatus, DateTime orderStartTime, DateTime orderEndTime)
        {
            var company = new Company(companyName, approvalStatus, orderStartTime.ToUniversalTime(), orderEndTime.ToUniversalTime());

            await _repository.AddAndSaveAsync(company);

            if (company.Id <= 0)
            {
                return new(false, _Common.CreateGeneralError);
            }
            return new();
        }

        public async Task<CommandResult> UpdateAsync(long id, string companyName, bool approvalStatus, DateTime orderStartTime, DateTime orderEndTime)
        {
            var company = await GetAsync(id);
            if (company is null)
            {
                return new(false, _Company.Company_Exception_EntityNotFound);
            }

            company.SetCompanyName(companyName);
            company.SetApprovalStatus(approvalStatus);
            company.SetOrderStartTime(orderStartTime);
            company.SetOrderEndTime(orderEndTime);

            var affRows = await _repository.ModifyAndSaveAsync(company);

            if (affRows <= 0)
            {
                return new(false, _Common.UpdateGeneralError);
            }

            return new();
        }

        public async Task<CommandResult> DeleteAsync(long id)
        {
            var affRows = await _repository.RemoveAndSaveAsync(id);

            if (affRows <= 0)
            {
                return new(false, _Common.RemoveGeneralError);
            }

            return new();
        }
    }
}
