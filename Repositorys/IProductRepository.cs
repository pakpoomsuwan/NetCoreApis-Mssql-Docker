using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreApis_Mssql_Docker.DbModels;
using NetCoreApis_Mssql_Docker.Models.Products;

namespace NetCoreApis_Mssql_Docker.Repositorys
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Product UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}