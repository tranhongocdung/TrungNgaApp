﻿using System;

namespace MVCWeb.Core.Entities
{
    public class BookLog
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string LogContent { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}