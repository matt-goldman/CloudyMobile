using AutoMapper;
using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;

namespace CloudyMobile.Application.Recipes.Queries.GetBeerStyles
{
    public class BeerStyleDto : IMapFrom<Style>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string ImageUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Style, BeerStyleDto>()
                .ForSourceMember(s => s.Recipes, opt => opt.DoNotValidate());
        }
    }
}
