using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brand> GetBrand(int id);
        Task<IReadOnlyList<Brand>> GetBrandList();
    }
}