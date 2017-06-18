using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWeb.Core.DtoForEntities
{
    public class SeatWithBookInfoDto
    {
        public int? BookId { get; set; }
        public int? BookInfoId { get; set; }
        public int SeatId { get; set; }
        public string SeatLabel { get; set; }
        public bool IsOnLeftSide { get; set; }
        public string PassengerName { get; set; }
        public string PassengerPhoneNo { get; set; }
        public string PickUpLocation { get; set; }
        public int NbOfSeats { get; set; }
        public bool IsBooked { get; set; }
        public bool HasBookInfo { get; set; }
        public string BookedByDisplayName { get; set; }
        public string Note { get; set; }
        public bool IsSticked { get; set; }
        public int PaymentStatusId { get; set; }
    }
}