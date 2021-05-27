using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;
using CloudyMobile.Domain.Enums;
using System.Collections.Generic;

namespace CloudyMobile.Application.Recipes.Common
{
    public class RecipeDto : IMapFrom<Recipe>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public List<RecipeIngredientDto> Ingredients { get; set; }
        public MassUnit MassUnits { get; set; }
        public TemperatureUnit TemperatureUnits { get; set; }
        public LiquidVolumeUnit LiquidUnits { get; set; }
        public string Notes { get; set; }
    }
}
