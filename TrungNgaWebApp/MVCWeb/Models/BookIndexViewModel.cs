using System.Collections.Generic;
using System.Web.Mvc;

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
        public string CurrentDate { get; set; }

        public List<SelectListItem> TransportDirectionItems { get; set; }
        public List<SelectListItem> TransportItems { get; set; }
    }
}