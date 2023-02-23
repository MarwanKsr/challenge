using AutoMapper;
using Enoca.Api.Models.Order;
using Enoca.Core.Common;
using Enoca.Core.Resources;
using Enoca.Service.Orders;
using Microsoft.AspNetCore.Mvc;


namespace Enoca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderCommandService _orderCommandService;
        private readonly IOrderQueriesService _orderQueriesService;
        private readonly IMapper _mapper;
        public OrdersController(
            IOrderCommandService orderCommandService,
            IOrderQueriesService orderQueriesService,
            IMapper mapper)
        {
            _orderCommandService = orderCommandService;
            _orderQueriesService = orderQueriesService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResponse<IEnumerable<OrderViewModel>>> GetAll()
        {
            var orders = await _orderQueriesService.GetAllAsync();

            var result = new List<OrderViewModel>();

            if (orders is not null)
            {
                foreach (var order in orders)
                {
                    result.Add(_mapper.Map<OrderViewModel>(order));
                }
            }

            return ApiResponse<IEnumerable<OrderViewModel>>.Create(result);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<ApiResponse<OrderViewModel>>> Get([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(ApiResponse<OrderViewModel>.Failure(_Common.InvalidId));
            }

            var order = await _orderQueriesService.GetAsync(id);

            if (order == null)
            {
                return NotFound(ApiResponse<OrderViewModel>.Failure(_Order.Order_Exception_EntityNotFound));
            }

            var model = _mapper.Map<OrderViewModel>(order);

            return Ok(ApiResponse<OrderViewModel>.Create(model));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] OrderCreateModel model)
        {
            var (isSuccess, errorMessage) = await _orderCommandService.CreateAsync(model.NameOfPerson, model.ProductId);
            if (!isSuccess)
            {
                return Ok(ApiResponse<object>.Failure(errorMessage));
            }
            return Ok(ApiResponse<object>.Create(new { Success = _Common.CreateOpreationIsSuccessfullyCompleted }));
        }
    }
}
