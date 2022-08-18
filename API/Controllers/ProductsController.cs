using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API.Entites;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase 
    {
        private readonly StoreContext _Context;
        public ProductsController(StoreContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async  Task<ActionResult<List<product>>> GetProducts()
        {
            var products = await _Context.Products.ToListAsync();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<product>> GetProduct (int id)
        {
            return await _Context.Products.FindAsync(id);
        }
    }
}