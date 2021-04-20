using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Business;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Brand>>> GetBrandList()
        {
            var brands = await _brandService.GetBrandList();

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            return await _brandService.GetBrandById(id);
        }
    }
}