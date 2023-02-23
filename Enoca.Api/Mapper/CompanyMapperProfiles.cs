using AutoMapper;
using Enoca.Api.Models.Company;
using Enoca.Service.Companies.Model;

namespace Enoca.Api.Mapper
{
    public class CompanyMapperProfiles : Profile
    {
        public CompanyMapperProfiles()
        {
            CreateMap<CompanyDto, CompanyViewModel>().ReverseMap();
        }
    }
}
