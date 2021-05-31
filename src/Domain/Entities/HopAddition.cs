using System;
using System.Collections.Generic;

namespace CloudyMobile.Domain.Entities
{
    public class HopAddition
    {
        public int Id { get; set; }
        public int? IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int? Minutes { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? Temperature { get; set; }
        public ICollection<BatchHopAdditions> Batches { get; set; }
    }
}
