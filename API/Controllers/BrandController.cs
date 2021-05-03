using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Business;
using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet("getallbrands")]
        public async Task<ActionResult<List<Brand>>> GetAllBrands()
        {
            var brands = await _brandService.GetBrandList();

            return Ok(_mapper.Map<IReadOnlyList<Brand>, IReadOnlyList<BrandDto>>(brands));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetBrand(int id)
        {
            var brand = await _brandService.GetBrandById(id);

            if (brand == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Brand, BrandDto>(brand);
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<BrandDto>>> GetBrandList(
            [FromQuery] BrandSpecParams brandParams)
        {
            var brands = await _brandService.GetBrandList(brandParams);

            var totalItems = await _brandService.GetTotalItems(brandParams);

            var data = _mapper.Map<IReadOnlyList<Brand>, IReadOnlyList<BrandDto>>(brands);

            return Ok(new Pagination<BrandDto>(brandParams.PageIndex, brandParams.PageSize,
                totalItems, data));
        }

    }
}