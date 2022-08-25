using System.Linq.Expressions;
using API.Entites;

namespace core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
             AddInclude(x => x.ProductType);
             AddInclude(x => x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id ) 
        : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}