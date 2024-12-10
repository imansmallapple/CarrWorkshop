using CarWorkShop.Server.Data;
using Microsoft.AspNetCore.Mvc;
using CarWorkShop.Server.Mappers;
using Microsoft.EntityFrameworkCore;
using CarWorkShop.Server.Interfaces;

namespace CarWorkShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IPartRepository _partRepository;

        public PartController(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var parts = await _partRepository.GetAllAsync();

            var partDto = parts.Select(s => s.ToPartDto());

            return Ok(partDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var part = await _partRepository.GetByIdAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            return Ok(part.ToPartDto());
        }
    }
}
