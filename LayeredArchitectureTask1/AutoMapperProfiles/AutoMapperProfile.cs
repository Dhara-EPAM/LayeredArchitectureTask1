using AutoMapper;
using static System.Net.Mime.MediaTypeNames;

namespace LayeredArchitectureTask1.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LayeredArchitectureTask1.BLL.CartService.CartItemDto, LayeredArchitectureTask1.Models.CartItem>();
            CreateMap<LayeredArchitectureTask1.Models.CartItem, LayeredArchitectureTask1.BLL.CartService.CartItemDto>();
        }
    }
}
