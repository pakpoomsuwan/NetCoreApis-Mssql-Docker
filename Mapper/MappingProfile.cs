using AutoMapper;
using NetCoreApis_Mssql_Docker.DbModels;
using _models = NetCoreApis_Mssql_Docker.Models;

namespace NetCoreApis_Mssql_Docker.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Products
            CreateMap<Products, _models.Products.Product>();
            CreateMap<_models.Products.Product, Products>();
        }
    }
}