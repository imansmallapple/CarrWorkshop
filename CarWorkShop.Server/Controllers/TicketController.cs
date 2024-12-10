using CarWorkShop.Server.Data;
using Microsoft.AspNetCore.Mvc;
using CarWorkShop.Server.Mappers;
using CarWorkShop.Server.Dtos.Ticket;
using Microsoft.EntityFrameworkCore;
using CarWorkShop.Server.Interfaces;
using CarWorkShop.Server.Helpers;
using Microsoft.AspNetCore.Authorization;
using NLog;

namespace CarWorkShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ApplicationDBContext context, ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
            _context = context;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tickets = await _ticketRepository.GetAllAsync(query);
            var ticketDto = tickets.Select(s => s.ToTicketDto());
            return Ok(tickets);
        }
        //Creata an Api that only return 1 item
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //_logger
            var ticket = await _ticketRepository.GetByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket.ToTicketDto());
        }
        [HttpGet("brand/{brand}")]
        public async Task<IActionResult> GetByBrand([FromRoute] string brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ticket = await _ticketRepository.GetByBrandAsync(brand);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket.ToTicketProfileDto());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateTicketRequestDto ticketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ticketModel = ticketDto.ToTicketFromCreateDto();
            await _ticketRepository.CreateAsync(ticketModel);
            return CreatedAtAction(nameof(GetById), new { id = ticketModel.Id }, ticketModel.ToTicketDto());
        }
        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTicketRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ticketModel = await _ticketRepository.UpdateAsync(id, updateDto);
            if (ticketModel == null)
            {
                return NotFound();
            }
            
            return Ok(ticketModel.ToTicketDto());
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ticketModel = await _ticketRepository.DeleteAsync(id);

            if(ticketModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
