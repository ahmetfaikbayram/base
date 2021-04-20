using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Business
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetProductList(ProductSpecParams productParams);
        Task<Product> GetProductById(int id);
        Task<int> GetTotalItems(ProductSpecParams productParams);
    }
}
