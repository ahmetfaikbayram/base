using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Business
{
    public interface IBrandService
    {
        Task<IReadOnlyList<Brand>> GetBrandList();
        Task<Brand> GetBrandById(int id);
    }
}
