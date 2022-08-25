using core.Entites;
using core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static   IQueryable <TEntity> GetQuery(IQueryable<TEntity> inputQuery,
         ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null) 
            {
                query = query.Where(spec.Criteria); 
            }

            query = spec.includes.Aggregate(query, (current, inlcude) => current.Include(inlcude));

            return query;


        }
    }
}