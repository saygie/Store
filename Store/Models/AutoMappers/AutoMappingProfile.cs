﻿
using AutoMapper;
using Store.Models.DTOs;
using Store.Models.Entities;

namespace Store.Models.AutoMappers;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<ParentCategory, ParentCategoryDTO>().ReverseMap();
        CreateMap<ProductPhoto, ProductPhotoDTO>().ReverseMap();
        CreateMap<Slider, SliderDTO>().ReverseMap();
    }
}
