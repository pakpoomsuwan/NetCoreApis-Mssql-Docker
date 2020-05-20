using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Get product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <responsecode code="200"> Return product </responsecode>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id){
            var result = _productService.GetProductById(id);
            return Ok(result);
        }

        /// <summary>
        /// Get products
        /// </summary>
        /// <returns></returns>
        /// <responsecode code="200"> Return products </responsecode>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("list")]
        public IActionResult GetProducts()
        {
            var result = _productService.GetAllProducts();
            return Ok(result);
        }
    }
}