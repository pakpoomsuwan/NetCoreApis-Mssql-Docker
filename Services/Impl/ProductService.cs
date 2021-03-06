using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreApis_Mssql_Docker.Models.Products;
using NetCoreApis_Mssql_Docker.Repositorys;

namespace NetCoreApis_Mssql_Docker.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repository)
        {
            _repo = repository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _repo.GetProductById(id);
        }
    }
}