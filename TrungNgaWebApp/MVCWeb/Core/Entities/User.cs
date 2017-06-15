using System.Collections.Generic;

namespace MVCWeb.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<BookLog> BookLogs { get; set; }
    }
}