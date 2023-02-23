using AutoMapper;
using Enoca.Api.Models.Product;
using Enoca.Service.Products.Model;

namespace Enoca.Api.Mapper
{
    public class ProductMapperProfiles : Profile
    {
        public ProductMapperProfiles()
        {
            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
        }

    }
}
