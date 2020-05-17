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

        [HttpGet("list")]
        public IActionResult Product()
        {
            var _r = _productService.Product();
            return Ok(_r);
        }
    }
}