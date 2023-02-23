using Enoca.Core.Domain.Companies;
using Enoca.Data.Base;
using Enoca.Data.Data;
using Enoca.Service.Companies.Model;
using Microsoft.EntityFrameworkCore;

namespace Enoca.Service.Companies
{
    public class CompanyQueriesService : ICompanyQueriesService
    {
        private readonly IRepository<Company, ApplicationDbContext> _repository;

        public CompanyQueriesService(IRepository<Company, ApplicationDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            var entities = await _repository.QueryAll().AsNoTracking().ToListAsync();
            if (!entities.Any())
            {
                return default;
            }

            return entities.Select(CompanyDto.FromEntity).ToList();
        }

        public async Task<CompanyDto> GetAsync(long id)
        {
            var entity = await _repository.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                return default;
            }
            return CompanyDto.FromEntity(entity);
        }
    }
}
