using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudyMobile.Domain.Entities
{
    public class Batch
    {
        public int Id { get; set; }
        public Recipe? Recipe { get; set; }
        public int RecipeId { get; set; }
        public DateTime BrewDay { get; set; }
        public DateTime? BottleOrKegDate { get; set; }
        public long PitchTemp { get; set; }
        public float OG { get; set; }
        public float? FG { get; set; }
        public decimal? BrewQuantity { get; set; }
        public ICollection<BatchHopAdditions>? HopAdditions { get; set; }
        public string Notes { get; set; }
        public DateTime? ServingDate { get; set; }
        public List<BatchSample>? Samples { get; set; }
        public List<BatchRating> BatchRatings { get; set; } = new List<BatchRating>();
    }
}
