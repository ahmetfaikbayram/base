using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithBrandSpecification : BaseSpecification<Product>
    {
        // ThenInclude sample => AddInclude(“Brand.Country”);
        public ProductsWithBrandSpecification()
        {
            AddInclude(x => x.Brand);
        }

        public ProductsWithBrandSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Brand);
        }
    }
}