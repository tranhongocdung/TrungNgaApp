using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<TicketChangeLog> TicketChangeLogs { get; set; }
    }
}