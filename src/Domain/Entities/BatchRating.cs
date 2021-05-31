using System;

namespace CloudyMobile.Domain.Entities
{
    public class BatchRating
    {
        public int Id { get; set; }
        public Batch Batch { get; set; }
        public int BatchId { get; set; }
        public DateTime RatedAt { get; set; }
        public int Rating { get; set; }
    }
}
