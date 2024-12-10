using CarWorkShop.Server.Data;
using Microsoft.AspNetCore.Mvc;
using CarWorkShop.Server.Mappers;
using CarWorkShop.Server.Dtos.Ticket;
using Microsoft.EntityFrameworkCore;
using CarWorkShop.Server.Interfaces;

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
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            var ticketDto = tickets.Select(s => s.ToTicketDto());
            return Ok(tickets);
        }
        //Creata an Api that only return 1 item
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket.ToTicketDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketRequestDto ticketDto)
        {
            var ticketModel = ticketDto.ToTicketFromCreateDto();
            await _ticketRepository.CreateAsync(ticketModel);
            return CreatedAtAction(nameof(GetById), new { id = ticketModel.Id }, ticketModel.ToTicketDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTicketRequestDto updateDto)
        {
            var ticketModel = await _ticketRepository.UpdateAsync(id, updateDto);
            if (ticketModel == null)
            {
                return NotFound();
            }
            
            return Ok(ticketModel.ToTicketDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ticketModel = await _ticketRepository.DeleteAsync(id);

            if(ticketModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
