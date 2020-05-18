using System.Threading.Tasks;
using NetCoreApis_Mssql_Docker.Database;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using NetCoreApis_Mssql_Docker.Models.Products;
using Microsoft.AspNetCore.Http;
using System;
using NetCoreApis_Mssql_Docker.DbModels;

namespace NetCoreApis_Mssql_Docker.Repositorys.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;
        public ProductRepository(DatabaseContext databaseContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _db = databaseContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _db.Products.ToList();
            var result = _mapper.Map<IEnumerable<Product>>(products);
            return result;
        }

        public Product GetProductById(int id)
        {
            var product = _db.Products.SingleOrDefault(c => c.ProductId.Equals(id));
            var result = _mapper.Map<Product>(product);
            return result;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var map = _mapper.Map<Products>(product);
            var result = await _db.Products.AddAsync(map);

            return _mapper.Map<Product>(result);
        }

        public Product UpdateProduct(Product product)
        {
            var dt = GetProductById(product.ProductId);
            if(dt == null) return null;

            var map = _mapper.Map<Products>(product);
            _db.Update(map);
            _db.SaveChangesAsync();

            return _mapper.Map<Product>(map);
        }

        public bool DeleteProduct(int id)
        {
            var dt = GetProductById(id);
            if(dt == null) return false;

            _db.Remove(dt);
            _db.SaveChangesAsync();

            return true;
        }
    }
}