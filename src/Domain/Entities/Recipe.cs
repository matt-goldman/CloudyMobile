using CloudyMobile.Domain.Enums;
using System.Collections.Generic;

namespace CloudyMobile.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Style Style { get; set; }
        public LiquidVolumeUnit LiquidUnits { get; set; }
        public MassUnit MassUnits { get; set; }
        public TemperatureUnit TemperatureUnit { get; set; }
        public ICollection<RecipeIngredients> Ingredients { get; set; }
        public string Notes { get; set; }
    }
}
