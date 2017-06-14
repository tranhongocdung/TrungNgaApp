using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWeb.AppDataLayer.Entities
{
    [Table("Transport")]
    public class Transport
    {
        [Key]
        public int Id { get; set; }

        public int CoachId { get; set; }
        public int DriverId { get; set; }
        public int AssistantId { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsCompleted { get; set; }
        public int TransportDirectionId { get; set; }
        public DateTime RunDate { get; set; }

        [ForeignKey("CoachId")]
        public virtual Coach Coach { get; set; }

        [ForeignKey("DriverId")]
        public virtual Employee Driver { get; set; }

        [ForeignKey("AssistantId")]
        public virtual Employee Assistant { get; set; }

        [ForeignKey("TransportDirectionId")]
        public virtual TransportDirection TransportDirection { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}