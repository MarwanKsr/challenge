using AutoMapper;
using Enoca.Api.Models.Order;
using Enoca.Service.Orders.Model;

namespace Enoca.Api.Mapper
{
    public class OrderMapperProfiles : Profile
    {
        public OrderMapperProfiles()
        {
            CreateMap<OrderDto, OrderViewModel>().ReverseMap();
        }

    }
}
