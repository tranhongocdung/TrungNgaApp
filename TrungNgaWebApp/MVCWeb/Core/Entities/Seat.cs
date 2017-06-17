using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CoachTypeId { get; set; }
        public bool IsOnLeftSide { get; set; }

        public virtual CoachType CoachType { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}