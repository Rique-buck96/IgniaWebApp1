using System;

namespace RxWebApp.Data.Entities
{
    internal class DiscussionEntity : Entity
    {
        public decimal Price { get; set; }

        public int DiscussionId { get; set; }

        public string Subject { get; set; }
        public string Location { get; set; }
        public string Employee { get; set; }
        public string Outcome { get; set; }
        public DateTime DiscussionDate { get; set; }
}
}
