using CarWorkShop.Server.Data;
using Microsoft.AspNetCore.Mvc;
using CarWorkShop.Server.Mappers;
using Microsoft.EntityFrameworkCore;
using CarWorkShop.Server.Interfaces;
using CarWorkShop.Server.Dtos.Part;

namespace CarWorkShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IPartRepository _partRepository;
        private readonly ITicketRepository _ticketRepository;

        public PartController(IPartRepository partRepository, ITicketRepository ticketRepository)
        {
            _partRepository = partRepository;
            _ticketRepository = ticketRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var parts = await _partRepository.GetAllAsync();

            var partDto = parts.Select(s => s.ToPartDto());

            return Ok(partDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var part = await _partRepository.GetByIdAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            return Ok(part.ToPartDto());
        }
        [HttpPost("{ticketId:int}")]
        public async Task<IActionResult> Create([FromRoute] int ticketId, CreatePartDto partDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _ticketRepository.TicketExists(ticketId))
            {
                return BadRequest("Tick does not exist!");
            }

            var partModel = partDto.ToPartFromCreate(ticketId);
            await _partRepository.CreateAsync(partModel);
            return CreatedAtAction(nameof(GetById), new { id = partModel.Id }, partModel.ToPartDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var partModel = await _partRepository.DeleteAsync(id);
            if (partModel == null)
            {
                return NotFound("Part does not exist!");
            }
            return Ok(partModel);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePartRequestDto updateDto)
        {
            var part = await _partRepository.UpdateAsync(id, updateDto.ToPartFromUpdate());

            if(part == null)
            {
                NotFound("Part not found!");
            }
            return Ok(part.ToPartDto());
        }
    }
}
