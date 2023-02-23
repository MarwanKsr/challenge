using Enoca.Core.Base;
using Enoca.Core.Domain.Orders;
using Enoca.Core.Domain.Products;
using Enoca.Core.Resources;
using Enoca.Data.Base;
using Enoca.Data.Data;
using Enoca.Service.Products;

namespace Enoca.Service.Orders
{
    public class OrderCommandService : IOrderCommandService
    {
        private readonly IRepository<Order, ApplicationDbContext> _repository;
        private readonly IRepository<Product, ApplicationDbContext> _productRepository;
        private readonly IProductCommandsService _productCommandsService;

        public OrderCommandService(
            IRepository<Order, ApplicationDbContext> repository,
            IRepository<Product, ApplicationDbContext> productRepository,
            IProductCommandsService productCommandsService)
        {
            _repository = repository;
            _productRepository = productRepository;
            _productCommandsService = productCommandsService;
        }

        private async Task<Product> GetProduct(long productId)
            => await _productRepository.FirstOrDefaultAsync(e => e.Id == productId);

        public async Task<CommandResult> CreateAsync(string nameOfPerson, long productId)
        {
            var product = await GetProduct(productId);
            if (product == null)
            {
                return new(false, _Product.Product_Exception_EntityNotFound);
            }
            if (!product.Company.ApprovalStatus)
            {
                return new(false, _Company.Company_Exception_ApprovalStatusFlase);
            }
            var currentUtcTime = DateTime.UtcNow.TimeOfDay;
            if (currentUtcTime < product.Company.OrderStartTime.TimeOfDay || currentUtcTime > product.Company.OrderEndTime.TimeOfDay)
            {
                return new(false, _Company.Company_Exception_OutOfOrderTime);
            }
            if (product.Stock < 0)
            {
                return new(false, _Product.Product_Exception_OutOfStock);
            }
            var order = new Order(product, nameOfPerson);

            await _repository.AddAndSaveAsync(order);

            if (order.Id <= 0)
            {
                return new(false, _Common.CreateGeneralError);
            }

            order.Product.DecreaseStockNumber();
            var affRows = await _productRepository.ModifyAndSaveAsync(order.Product);
            //var (isSuccess, errorMessage) = await _productCommandsService.DecreaseStockById(product.Id);
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
