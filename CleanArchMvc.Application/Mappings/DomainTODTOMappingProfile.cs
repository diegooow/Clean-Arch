using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entity;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainTODTOMappingProfile : Profile
    {
        public DomainTODTOMappingProfile()
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Product,ProductDTO>().ReverseMap();
        }
    }
}