using System;
using System.Collections.Generic;
using MVCWeb.Core.DtoForEntities;
using MVCWeb.Core.Entities;

namespace MVCWeb.Core.IServices
{
    public interface IBookService : IWebAppService
    {
        List<Seat> GetSeats(IEnumerable<int> seatIds);
        Ticket GetTicket(int seatId, int transportId);
        ICollection<SeatWithBookInfoDto> GetSeatWithBookInfos(int transportId);
        int BookSeats(List<Ticket> tickets, int userId);
    }
}