using System;
using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class PickUpLocation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Weight { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}