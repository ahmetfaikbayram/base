using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Business
{
    public interface IBrandService
    {
        Task<IReadOnlyList<Brand>> GetBrandList();
        Task<Brand> GetBrandById(int id);
        Task<IReadOnlyList<Brand>> GetBrandList(BrandSpecParams brandParams);
        Task<int> GetTotalItems(BrandSpecParams brandParams);
    }
}
