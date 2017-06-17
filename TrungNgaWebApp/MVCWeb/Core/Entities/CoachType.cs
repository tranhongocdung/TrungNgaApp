using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class CoachType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }

    }
}