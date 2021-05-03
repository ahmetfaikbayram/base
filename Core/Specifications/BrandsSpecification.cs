using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class BrandsSpecification : BaseSpecification<Brand>
    {
        // ThenInclude sample => AddInclude(“Country.Region”);
        public BrandsSpecification(BrandSpecParams brandParams)
            : base(x =>
                (string.IsNullOrEmpty(brandParams.Search) || x.Name.ToLower()
                .Contains(brandParams.Search))
            )
        {
            AddOrderBy(x => x.Name);
            ApplyPaging(brandParams.PageSize * (brandParams.PageIndex),
                brandParams.PageSize);


            if (!string.IsNullOrEmpty(brandParams.Sort))
            {
                switch (brandParams.Sort)
                {
                    case "asc":
                        AddOrderBy(p => p.Id);
                        break;
                    case "desc":
                        AddOrderByDescending(p => p.Id);
                        break;
                    default:
                        AddOrderBy(n => n.Id);
                        break;
                }
            }
        }

        public BrandsSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}