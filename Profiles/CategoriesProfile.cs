using AutoMapper;
using Category.Dtos;
using Category.Models;

namespace Category.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Categories, CategoryReadDto>();
            CreateMap<CategoryReadDto, Categories>();
            CreateMap<CategoryCreateDto, Categories>();
            CreateMap<CategoryUpdateDto, Categories>();
            CreateMap<Categories, CategoryUpdateDto>();
            CreateMap<CategoryReadDto, Categories>();
            CreateMap<CategoryReadDto, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, CategoryReadDto>();
        }
    }
}