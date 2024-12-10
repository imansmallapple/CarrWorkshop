using CarWorkShop.Data.Enum;
using CarWorkShop.Server.Dtos.Ticket;
using CarWorkShop.Server.Models;

namespace CarWorkShop.Server.Mappers
{
    public static class TicketMappers
    {
        public static TicketDto ToTicketDto(this Ticket ticketModel)
        {
            return new TicketDto
            {
                Id = ticketModel.Id,
                Brand = ticketModel.Brand,
                Model = ticketModel.Model,
                Description = ticketModel.Description,
                Parts = ticketModel.Parts.Select(c => c.ToPartDto()).ToList(),
                RegistrationId = ticketModel.RegistrationId,
                EmployeeAssigned = ticketModel.EmployeeAssigned,
                StateCategory = ticketModel.StateCategory,
                TotalPrice = ticketModel.TotalPrice,
                TimeSlots = ticketModel.TimeSlots,
                ClientPaid = ticketModel.ClientPaid,
                AcceptedOrNot = ticketModel.AcceptedOrNot,
                AppUserId = ticketModel.AppUserId,
            };
        }
        public static Ticket ToTicketFromCreateDto(this CreateTicketRequestDto ticketModel)
        {
            return new Ticket
            {
                Model = ticketModel.Model,
                Brand = ticketModel.Brand,
                Description = ticketModel.Description,
                RegistrationId = ticketModel.RegistrationId,
                EmployeeAssigned = ticketModel.EmployeeAssigned,     
            };
        }
        public static TicketProfileDto ToTicketProfileDto(this Ticket ticketModel)
        {
            return new TicketProfileDto
            {
                Id = ticketModel.Id,
                Brand = ticketModel.Brand,
                Model = ticketModel.Model,
                Description = ticketModel.Description,
                RegistrationId = ticketModel.RegistrationId,
                EmployeeAssigned = ticketModel.EmployeeAssigned,
                ClientPaid = ticketModel.ClientPaid,
                StateCategory = ticketModel.StateCategory,
                TotalPrice = ticketModel.TotalPrice,
                AcceptedOrNot = ticketModel.AcceptedOrNot,
                Parts = ticketModel.Parts.Select(c => c.ToPartDto()).ToList()
            };
        }
    }

}

