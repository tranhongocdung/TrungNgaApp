using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class BookInfo
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public string PassengerPhoneNo { get; set; }
        public string PickUpLocation { get; set; }
        public int NbOfSeats { get; set; }
        public int PaymentStatusId { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<BookLog> BookLogs { get; set; }
    }
}