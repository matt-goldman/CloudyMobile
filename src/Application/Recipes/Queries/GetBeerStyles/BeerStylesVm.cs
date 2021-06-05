using System.Collections.Generic;

namespace CloudyMobile.Application.Recipes.Queries.GetBeerStyles
{
    public class BeerStylesVm
    {
        public List<BeerStyleDto> Styles { get; set; } = new List<BeerStyleDto>();
    }
}