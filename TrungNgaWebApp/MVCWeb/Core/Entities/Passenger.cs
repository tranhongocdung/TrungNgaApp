using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class Passenger
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public string PassengerPhoneNo { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}