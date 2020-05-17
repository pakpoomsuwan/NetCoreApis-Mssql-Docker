using System.Threading.Tasks;
using NetCoreApis_Mssql_Docker.Database;
using NetCoreApis_Mssql_Docker.DbModels;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using NetCoreApis_Mssql_Docker.Models.Products;

namespace NetCoreApis_Mssql_Docker.Repositorys.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;
        public ProductRepository(DatabaseContext databaseContext, IMapper mapper)
        {
            _db = databaseContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> Product()
        {
            var _products = _db.Products.ToList();
            var result = _mapper.Map<IEnumerable<Product>>(_products);
            return result;
        }
    }
}