using System.Collections.Generic;
using System.Web.Mvc;
using MVCWeb.Core.DtoForEntities;

namespace MVCWeb.Models
{
    public class BookIndexViewModel
    {
        public BookIndexViewModel()
        {
            TransportDirectionId = 0;
            TransportId = 0;
        }
        public int TransportDirectionId { get; set; }
        public int TransportId { get; set; }
        public string LatestDateHavingTransport { get; set; }

        public ICollection<SelectListItem> TransportDirectionItems { get; set; }
        public ICollection<SelectListItem> TransportItems { get; set; }
        public ICollection<SeatWithBookInfoDto> LeftSeatWithBookInfos { get; set; }
        public ICollection<SeatWithBookInfoDto> RightSeatWithBookInfos { get; set; }
    }
}