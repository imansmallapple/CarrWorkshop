using CarWorkShop.Models;
using CarWorkShop.Server.Dtos.Part;
using System.Runtime.CompilerServices;

namespace CarWorkShop.Server.Mappers
{
    public static class PartMapper
    {
        public static PartDto ToPartDto(this Part partModel)
        {
            return new PartDto
            {
                Id = partModel.Id,
                Name = partModel.Name,
                Amount = partModel.Amount,
                UnitPrice = partModel.UnitPrice,
                TicketId = partModel.TicketId,
            };
        }
        public static Part ToPartFromCreate(this CreatePartDto partDto, int ticketId)
        {
            return new Part
            {
                Name = partDto.Name,
                Amount = partDto.Amount,
                UnitPrice = partDto.UnitPrice,
                TicketId = ticketId,
            };
        }
        public static Part ToPartFromUpdate(this UpdatePartRequestDto partDto)
        {
            return new Part
            {
                Name = partDto.Name,
                Amount = partDto.Amount,
                UnitPrice = partDto.UnitPrice,
            };
        }
    }
}
