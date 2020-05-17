using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreApis_Mssql_Docker.Services;

namespace NetCoreApis_Mssql_Docker.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("{productid}")]
        public IActionResult Product(int productId){
            var result = _productService.GetProductById(productId);
            return Ok(result);
        }

        [HttpGet("list")]
        public IActionResult Products()
        {
            var result = _productService.GetAllProducts();
            return Ok(result);
        }
    }
}