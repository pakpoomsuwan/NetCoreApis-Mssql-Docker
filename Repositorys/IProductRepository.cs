using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreApis_Mssql_Docker.DbModels;
using NetCoreApis_Mssql_Docker.Models.Products;

namespace NetCoreApis_Mssql_Docker.Repositorys
{
    public interface IProductRepository
    {
         Task<IEnumerable<Product>> Product();
    }
}