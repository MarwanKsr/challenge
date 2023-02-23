using Enoca.Core.Base;
using Enoca.Core.Domain.Companies;
using Enoca.Core.Domain.Products;
using Enoca.Core.Resources;
using Enoca.Data.Base;
using Enoca.Data.Data;

namespace Enoca.Service.Products
{
    public class ProductCommandsService : IProductCommandsService
    {
        private readonly IRepository<Product, ApplicationDbContext> _repository;
        private readonly IRepository<Company, ApplicationDbContext> _companyRepository;

        public ProductCommandsService(
            IRepository<Product, ApplicationDbContext> repository,
            IRepository<Company, ApplicationDbContext> companyRepository)
        {
            _repository = repository;
            _companyRepository = companyRepository;
        }

        private async Task<Product> GetProduct(long id)
            => await _repository.FindDetachedAsync(id);

        private async Task<Company> GetCompany(long companyId)
            => await _companyRepository.FirstOrDefaultAsync(e => e.Id == companyId);
        public async Task<CommandResult> CreateAsync(string productName, long companyId, int stock, long price)
        {
            var company = await GetCompany(companyId);
            if (company == null)
            {
                return new(false, _Product.Product_Exception_EntityNotFound);
            }
            var product = new Product(company, productName, stock, price);

            await _repository.AddAndSaveAsync(product);

            if (product.Id <= 0)
            {
                return new(false, _Common.CreateGeneralError);
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

        public async Task<CommandResult> UpdateAsync(long id, string productName, long companyId, int stock, long price)
        {
            var product = await GetProduct(id);
            if (product == null)
            {
                return new(false, _Product.Product_Exception_EntityNotFound);
            }

            var company = await GetCompany(companyId);
            if (company == null)
            {
                return new(false, _Company.Company_Exception_EntityNotFound);
            }

            product.SetProductName(productName);
            product.SetCompany(company);
            product.SetStock(stock);
            product.SetPrice(price);

            var affRows = await _repository.ModifyAndSaveAsync(product);

            if (affRows <= 0)
            {
                return new(false, _Common.UpdateGeneralError);
            }

            return new();
        }

        public async Task<CommandResult> DecreaseStockById(long id)
        {
            var product = await GetProduct(id);
            if (product == null)
            {
                return new(false, _Product.Product_Exception_EntityNotFound);
            }
            product.DecreaseStockNumber();
            var affRows = await _repository.ModifyAndSaveAsync(product);

            if (affRows <= 0)
            {
                return new(false, _Common.UpdateGeneralError);
            }

            return new();
        }
    }
}
