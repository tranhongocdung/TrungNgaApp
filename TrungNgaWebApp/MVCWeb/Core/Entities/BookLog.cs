using System;

namespace MVCWeb.Core.Entities
{
    public class BookLog
    {
        public int Id { get; set; }
        public int BookInfoId { get; set; }
        public int UserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string LogContent { get; set; }

        public virtual BookInfo BookInfo { get; set; }
        public virtual User User { get; set; }
    }
}