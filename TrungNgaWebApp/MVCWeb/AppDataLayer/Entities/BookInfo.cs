using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWeb.AppDataLayer.Entities
{
    [Table("BookInfo")]
    public class BookInfo
    {
        [Key]
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public string PassengerPhoneNo { get; set; }
        public string PickUpLocation { get; set; }
        public int NbOfSeats { get; set; }
        public int PaymentStatusId { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}