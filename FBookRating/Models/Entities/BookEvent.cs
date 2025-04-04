﻿namespace FBookRating.Models.Entities
{
    public class BookEvent
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }

}
