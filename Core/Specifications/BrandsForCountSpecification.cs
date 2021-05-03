using Core.Entities;

namespace Core.Specifications
{
    public class BrandsForCountSpecification : BaseSpecification<Brand>
    {
        public BrandsForCountSpecification(BrandSpecParams brandParams)
        : base(x =>
                (string.IsNullOrEmpty(brandParams.Search) || x.Name.ToLower()
                .Contains(brandParams.Search))
            )
        {
        }
    }
}