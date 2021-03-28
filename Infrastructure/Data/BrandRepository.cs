using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BrandRepository : IBrandRepository
    {
        private readonly BaseContext _context;
        public BrandRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<Brand> GetBrand(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<IReadOnlyList<Brand>> GetBrandList()
        {
            return await _context.Brands.ToListAsync();
        }
    }
}