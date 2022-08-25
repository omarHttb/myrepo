using API.Entites;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.data
{
    public class ProductRepository : IProductRepository
    {
        public StoreContext _Context;
        public ProductRepository(StoreContext context)
        {
            _Context = context;
        }

        public async Task<product> GetProductByIdAsync(int id)
        {
            return await _Context.Products
            .Include (p => p.ProductType)
            .Include (p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id ==id);
        }

        public async Task<IReadOnlyList<product>> GetProductsAsync()
        { 

            return await _Context.Products
            .Include (p => p.ProductType)
            .Include (p => p.ProductBrand)
            .ToListAsync();
        }

        public Task<product> GetProductByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            return await _Context.ProductBrands.ToListAsync ();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductsTypesAsync()
        {
            return await _Context.ProductTypes.ToListAsync();
        }
    }
}
