using System;

namespace CloudyMobile.Domain.Entities
{
    public class KegPours
    {
        public int Id { get; set; }
        public Keg Keg { get; set; }
        public int KegId { get; set; }
        public DateTime PouredAt { get; set; }
        public decimal VolumePoured { get; set; }
    }
}
