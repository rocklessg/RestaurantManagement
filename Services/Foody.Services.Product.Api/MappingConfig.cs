using AutoMapper;
using Foody.Services.ProductApi.Models;
using Foody.Services.ProductApi.Models.Dto;

namespace Foody.Services.ProductApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                /*You can also user .ReverseMap() method i.e
                config.CreateMap<ProductDto, Product>().ReverseMap();
                */

                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
