using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Business;
using Core.Entities;
using Core.DAL;
using Core.Specifications;

namespace Infrastructure.Business
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<Product>> GetProductList(ProductSpecParams productParams)
        {
            var spec = new ProductsWithBrandSpecification(productParams);

            var products = await _unitOfWork.Repository<Product>().GetListWithSpec(spec);

            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var spec = new ProductsWithBrandSpecification(id);

            var product = await _unitOfWork.Repository<Product>().GetByIdWithSpec(spec);

            return product;
        }

        public async Task<int> GetTotalItems(ProductSpecParams productParams)
        {
            var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

            var totalItems = await _unitOfWork.Repository<Product>().Count(countSpec);

            return totalItems;
        }
    }
}
