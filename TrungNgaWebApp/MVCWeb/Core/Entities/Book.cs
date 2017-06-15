using System;
using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int TransportId { get; set; }
        public int SeatId { get; set; }
        public int? BookInfoId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCancelled { get; set; }

        public virtual Transport Transport { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual BookInfo BookInfo { get; set; }
        public virtual User CreatedBy { get; set; }
    }
}