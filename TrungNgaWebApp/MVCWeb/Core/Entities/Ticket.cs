using System;
using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int TransportId { get; set; }
        public int SeatId { get; set; }
        public int? PassengerId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCancelled { get; set; }
        public int? PickUpLocationId { get; set; }
        public bool IsPickUpAndGo { get; set; }
        public int PaymentStatusId { get; set; }
        public string Note { get; set; }
        public bool IsSticked { get; set; }
        public decimal TicketPrice { get; set; }
        public string QuickGoInfo { get; set; }
        public string HouseNumber { get; set; }

        public virtual Transport Transport { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual Passenger Passenger { get; set; }
        public virtual PickUpLocation PickUpLocation { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual ICollection<TicketChangeLog> TicketChangeLogs { get; set; }

        public Ticket()
        {
            PaymentStatusId = (int) Enums.PaymentStatusEnum.NotPaidYet;
        }

    }
}