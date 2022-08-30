using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entites;

namespace core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
                 : base(x =>
                 (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains
            (productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
         )
        {
        }
    }
}