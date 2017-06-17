using System;
using System.Collections.Generic;
using MVCWeb.Core.DtoForEntities;

namespace MVCWeb.Core.IServices
{
    public interface IBookService : IWebAppService
    {
        ICollection<SeatWithBookInfoDto> GetSeatWithBookInfos(int transportId);
    }
}