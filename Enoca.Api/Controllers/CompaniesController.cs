using AutoMapper;
using Enoca.Api.Models.Company;
using Enoca.Core.Common;
using Enoca.Core.Resources;
using Enoca.Service.Companies;
using Enoca.Service.Orders.Model;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : Controller
    {
        private readonly ICompanyCommandsService _companyCommandsService;
        private readonly ICompanyQueriesService _companyQueriesService;
        private readonly IMapper _mapper;

        public CompaniesController(
            ICompanyCommandsService companyCommandsService,
            ICompanyQueriesService companyQueriesService,
            IMapper mapper)
        {
            _companyCommandsService = companyCommandsService;
            _companyQueriesService = companyQueriesService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResponse<IEnumerable<CompanyViewModel>>> GetAll()
        {
            var companies = await _companyQueriesService.GetAllAsync();

            var result = new List<CompanyViewModel>();

            if (companies is not null)
            {
                foreach (var company in companies)
                {
                    result.Add(_mapper.Map<CompanyViewModel>(company));
                }
            }

            return ApiResponse<IEnumerable<CompanyViewModel>>.Create(result);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<ApiResponse<CompanyViewModel>>> Get([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest(ApiResponse<CompanyViewModel>.Failure(_Common.InvalidId));
            }
            var order = await _companyQueriesService.GetAsync(id);
            if (order == null)
            {
                return NotFound(ApiResponse<CompanyViewModel>.Failure(_Company.Company_Exception_EntityNotFound));
            }
            var model = _mapper.Map<CompanyViewModel>(order);

            return Ok(ApiResponse<CompanyViewModel>.Create(model));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] CompanyCreateModel model)
        {
            var (isSuccess, errorMessage) = await _companyCommandsService.CreateAsync(model.CompanyName, model.ApprovalStatus,
                 model.OrderStartTime, model.OrderEndTime);

            if (!isSuccess)
            {
                return Ok(ApiResponse<object>.Failure(errorMessage));
            }
            return Ok(ApiResponse<object>.Create(new { Success = _Common.CreateOpreationIsSuccessfullyCompleted }));
        }

        [HttpPost("Edit/{id:int}")]
        public async Task<ActionResult<ApiResponse<object>>> Edit(long id, [FromBody] CompanyEditModel model)
        {
            var (isSuccess, errorMessage) = await _companyCommandsService.UpdateAsync(id, model.CompanyName, model.ApprovalStatus,
                 model.OrderStartTime, model.OrderEndTime);

            if (!isSuccess)
            {
                return Ok(ApiResponse<object>.Failure(errorMessage));
            }
            return Ok(ApiResponse<object>.Create(new { Success = _Common.UpdateOpreationIsSuccessfullyCompleted }));
        }

    }
}
