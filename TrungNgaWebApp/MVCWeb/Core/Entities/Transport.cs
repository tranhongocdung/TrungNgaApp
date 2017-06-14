using System;
using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class Transport
    {
        public int Id { get; set; }
        public int CoachId { get; set; }
        public int DriverId { get; set; }
        public int? AssistantId { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsCompleted { get; set; }
        public int TransportDirectionId { get; set; }
        public DateTime RunDate { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual Employee Driver { get; set; }
        public virtual Employee Assistant { get; set; }
        public virtual TransportDirection TransportDirection { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}