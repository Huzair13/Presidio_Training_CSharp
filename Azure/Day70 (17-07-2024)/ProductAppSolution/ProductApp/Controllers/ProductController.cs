using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Exceptions;
using ProductApp.Interfaces;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(IList<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IList<Product>>> GetAllProducts()
        {
            try
            {
                var products = await _productServices.GetAllProducts();
                return Ok(products.ToList());
            }
            catch (NoProductFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Route("GetProductsByName")]
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> Get([FromBody] string name)
        {
            try
            {
                var products = await _productServices.GetProductByName(name);
                return Ok(products);
            }
            catch (NoProductFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }


        [Route("GetProductsByID")]
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductsByID([FromBody] int id)
        {
            try
            {
                var products = await _productServices.GetProductByID(id);
                return Ok(products);
            }
            catch (NoProductFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

    }
}
