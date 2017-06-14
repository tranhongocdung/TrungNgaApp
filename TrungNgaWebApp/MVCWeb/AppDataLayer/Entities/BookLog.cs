using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWeb.AppDataLayer.Entities
{
    [Table("BookLog")]
    public class BookLog
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string LogContent { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}