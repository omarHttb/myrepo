using API.Entites;

namespace core.Interfaces
{
    public interface IProductRepository
    {
        Task <product> GetProductByIdAsync (int id);
        Task <IReadOnlyList<product> > GetProductsAsync ();
        Task <IReadOnlyList<ProductBrand> > GetProductBrandAsync ();
        Task <IReadOnlyList<ProductType> > GetProductsTypesAsync ();
       

    }
}