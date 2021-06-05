using System.Collections.Generic;

namespace CloudyMobile.Domain.Entities
{
    public class Style
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string ImageUrl { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
