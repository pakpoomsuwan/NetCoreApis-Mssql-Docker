using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreApis_Mssql_Docker.Models.Products;

namespace NetCoreApis_Mssql_Docker.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}