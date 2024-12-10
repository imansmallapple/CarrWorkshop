using CarWorkShop.Server.Data;
using CarWorkShop.Server.Extensions;
using CarWorkShop.Server.Interfaces;
using CarWorkShop.Server.Mappers;
using CarWorkShop.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITicketRepository _ticketRepository;
        private readonly IDashboardRepository _dashboardRepository;
        //private readonly IFMPService _fmpService;
        public DashboardController(UserManager<AppUser> userManager,IDashboardRepository dashboardRepository, ITicketRepository ticketRepository)
        {
            _userManager = userManager;
            _ticketRepository = ticketRepository;
            _dashboardRepository = dashboardRepository;
            //_fmpService = fmpService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserTickets() 
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userTickets = await _dashboardRepository.GetUserTickets(appUser);
            var ticketsDto = userTickets.Select(s => s.ToTicketDto());
            return Ok(ticketsDto);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserTicket(string brand)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var ticket = await _ticketRepository.GetByBrandAsync(brand);
            if (ticket == null) return BadRequest("Ticket not found");

            await _ticketRepository.AddTicketToUserByBrand(appUser, brand);
            
            var userTickets = await _dashboardRepository.GetUserTickets(appUser);
            var ticketsDto = userTickets.Select(s => s.ToTicketDto());
            return Ok(ticketsDto);
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemoveUserTicket(string brand)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var ticket = await _ticketRepository.GetByBrandAsync(brand);
            if (ticket == null) return BadRequest("Ticket not found");

            var userTickets = await _dashboardRepository.GetUserTickets(appUser);

            await _ticketRepository.RemoveTicketForUserByBrand(userTickets, brand);

            var userTicketsAfterRemove = await _dashboardRepository.GetUserTickets(appUser);

            var ticketsDto = userTicketsAfterRemove.Select(s => s.ToTicketDto());
            return Ok(ticketsDto);
        }
    }
}
