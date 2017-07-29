using System;
using System.Collections.Generic;
using MVCWeb.Core.DtoForEntities;
using MVCWeb.Core.Entities;

namespace MVCWeb.Core.IServices
{
    public interface IBookService : IWebAppService
    {
        ICollection<SeatWithBookInfoDto> GetSeatWithBookInfos(int transportId);
        int BookSeats(List<Ticket> tickets, int userId);
    }
}