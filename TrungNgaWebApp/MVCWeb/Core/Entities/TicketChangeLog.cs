using System;

namespace MVCWeb.Core.Entities
{
    public class TicketChangeLog
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string LogContent { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
    }
}