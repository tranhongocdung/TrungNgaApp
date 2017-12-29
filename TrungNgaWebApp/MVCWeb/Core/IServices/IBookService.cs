using System.Collections.Generic;
using MVCWeb.Core.DtoForEntities;
using MVCWeb.Core.Entities;
using MVCWeb.Models;

namespace MVCWeb.Core.IServices
{
    public interface IBookService : IWebAppService
    {
        void UpdateBookInfo(BookEditViewModel model, int userId);
        List<Seat> GetSeats(IEnumerable<int> seatIds);
        Ticket GetTicket(int seatId, int transportId);
        ICollection<SeatWithBookInfoDto> GetSeatWithBookInfos(int transportId);
        int BookSeats(List<Ticket> tickets, int userId);
    }
}