using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Business;
using Core.Entities;
using Core.DAL;
using Core.Specifications;

namespace Infrastructure.Business
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<Brand>> GetBrandList()
        {
            var brands = await _unitOfWork.Repository<Brand>().GetList();

            return brands;
        }

        public async Task<Brand> GetBrandById(int id)
        {
            var brand = await _unitOfWork.Repository<Brand>().GetById(id);

            return brand;
        }

        public async Task<IReadOnlyList<Brand>> GetBrandList(BrandSpecParams brandParams)
        {
            var spec = new BrandsSpecification(brandParams);

            var brands = await _unitOfWork.Repository<Brand>().GetListWithSpec(spec);

            return brands;
        }

        public async Task<int> GetTotalItems(BrandSpecParams brandParams)
        {
            var countSpec = new BrandsForCountSpecification(brandParams);

            var totalItems = await _unitOfWork.Repository<Brand>().Count(countSpec);

            return totalItems;
        }

    }
}
