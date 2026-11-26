using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDb>>> Get([FromQuery] string? name, [FromQuery] string? desc,[FromQuery] int?[] categoriesId, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int position = 1, [FromQuery] int skip = 1)
        {
            IEnumerable<ProductsDb> products = await _productService.GetProducts(name,desc,categoriesId,minPrice,maxPrice,position,skip);
            if(products == null)
                return NotFound();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDb>> Get([FromQuery] int id)
        {
            ProductsDb product = await _productService.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
