using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCWeb.Models
{
    public class BookEditViewModel
    {
        public int TransportId { get; set; }
        public List<string> SeatLabels { get; set; }
        public string SeatIds { get; set; }
        public string TicketIds { get; set; }
        public string RunDate { get; set; }
        public string RunTime { get; set; }
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerPhoneNo { get; set; }
        public int? PickUpLocationId { get; set; }
        public string PickUpLocation { get; set; }
        public int IsPickUpAndGo { get; set; }
        public int PaymentStatus { get; set; }
        public string Note { get; set; }

        //Select options
        public List<SelectListItem> PaymentStatusOptions { get; set; }
        public List<SelectListItem> PickUpAndGoOptions { get; set; }

        public BookEditViewModel()
        {
            PassengerId = 0;
        }
    }
}