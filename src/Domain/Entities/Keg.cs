using System;
using System.Collections.Generic;

namespace CloudyMobile.Domain.Entities
{
    public class Keg
    {
        public int Id { get; set; }
        public Batch Batch { get; set; }
        public int BatchId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public DateTime DateKegged { get; set; }
        public decimal VolumeKegged { get; set; }

        public List<KegPours> Pours { get; set; } = new List<KegPours>();
    }
}
