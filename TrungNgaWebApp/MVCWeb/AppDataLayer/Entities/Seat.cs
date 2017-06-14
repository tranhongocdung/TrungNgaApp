using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWeb.AppDataLayer.Entities
{
    [Table("Seat")]
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}