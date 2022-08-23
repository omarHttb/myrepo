using Microsoft.AspNetCore.Mvc;
using API.Entites;
using core.Interfaces;

namespace API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase 
    {
        private readonly IProductRepository _repo;
       
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
            
        }

        [HttpGet]
        public async  Task<ActionResult<List<product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<product>> GetProduct (int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandAsync());
        }

                [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductsTypesAsync());
        }
    }
}