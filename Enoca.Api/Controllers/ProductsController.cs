using AutoMapper;
using Enoca.Api.Models.Product;
using Enoca.Core.Common;
using Enoca.Core.Resources;
using Enoca.Service.Products;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductCommandsService _productCommandsService;
        private readonly IProductQueriesService _productQueriesService;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductCommandsService productCommandsService,
            IProductQueriesService productQueriesService,
            IMapper mapper)
        {
            _productCommandsService = productCommandsService;
            _productQueriesService = productQueriesService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResponse<IEnumerable<ProductViewModel>>> GetAll()
        {
            var products = await _productQueriesService.GetAllAsync();

            var result = new List<ProductViewModel>();

            if (products is not null)
            {
                foreach (var product in products)
                {
                    result.Add(_mapper.Map<ProductViewModel>(product));
                }
            }

            return ApiResponse<IEnumerable<ProductViewModel>>.Create(result);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<ApiResponse<ProductViewModel>>> Get([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(ApiResponse<ProductViewModel>.Failure(_Common.InvalidId));
            }
            var product = await _productQueriesService.GetAsync(id);
            if (product == null)
            {
                return NotFound(ApiResponse<ProductViewModel>.Failure(_Product.Product_Exception_EntityNotFound));
            }
            var model = _mapper.Map<ProductViewModel>(product);

            return Ok(ApiResponse<ProductViewModel>.Create(model));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] ProductCreateModel model)
        {
            var (isSuccess, errorMessage) = await _productCommandsService.CreateAsync(model.ProductName, model.ComapnyId,
                 model.Stock, model.Price);

            if (!isSuccess)
            {
                return Ok(ApiResponse<object>.Failure(errorMessage));
            }
            return Ok(ApiResponse<object>.Create(new { Success = _Common.CreateOpreationIsSuccessfullyCompleted }));
        }

        [HttpPost("Edit/{id:int}")]
        public async Task<ActionResult<ApiResponse<object>>> Edit(long id, [FromBody] ProductEditModel model)
        {
            var (isSuccess, errorMessage) = await _productCommandsService.UpdateAsync(id, model.ProductName, model.CompanyId,
                 model.Stock, model.Price);

            if (!isSuccess)
            {
                return Ok(ApiResponse<object>.Failure(errorMessage));
            }
            return Ok(ApiResponse<object>.Create(new { Success = _Common.UpdateOpreationIsSuccessfullyCompleted }));
        }
    }
}
