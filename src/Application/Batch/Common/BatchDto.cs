using AutoMapper;
using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CloudyMobile.Application.Batch.Common
{
    public class BatchDto : IMapFrom<CloudyMobile.Domain.Entities.Batch>
    {
        public int? Id { get; set; }
        public int RecipeId { get; set; }
        public DateTime BrewDay { get; set; }
        public DateTime? BottleOrKegDate { get; set; }
        public long PitchTemp { get; set; }
        public float OG { get; set; }
        public float? FG { get; set; }
        public decimal? BrewQuantity { get; set; }
        public List<HopAdditionDto> HopAdditions { get; set; }
        public string Notes { get; set; }
        public DateTime? ServingDate { get; set; }
        public List<SampleDto> Samples { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CloudyMobile.Domain.Entities.Batch, BatchDto>()
                .ForMember(dst => dst.HopAdditions, opt => opt.MapFrom(src => src.HopAdditions));

            profile.CreateMap<BatchHopAdditions, HopAdditionDto>()
                .ForMember(dst => dst.IngredientId, opt => opt.MapFrom(src => src.HopAddition.IngredientId))
                .ForMember(dst => dst.IngredientName, opt => opt.MapFrom(src => src.HopAddition.Ingredient.Name))
                .ForMember(dst => dst.Minutes, opt => opt.MapFrom(src => src.HopAddition.Minutes))
                .ForMember(dst => dst.Temperature, opt => opt.MapFrom(src => src.HopAddition.Temperature))
                .ForMember(dst => dst.DateAdded, opt => opt.MapFrom(src => src.HopAddition.DateAdded));

        }
    }
}
