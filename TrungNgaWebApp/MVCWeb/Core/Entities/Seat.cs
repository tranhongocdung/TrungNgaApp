using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}