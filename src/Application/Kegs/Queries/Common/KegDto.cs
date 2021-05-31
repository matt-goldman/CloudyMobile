using AutoMapper;
using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;
using System;
using System.Linq;

namespace CloudyMobile.Application.Kegs.Queries.Common
{
    public class KegDto : IMapFrom<Keg>
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public string LocationName { get; set; }
        public string LocationId { get; set; }
        public DateTime DateKegged { get; set; }
        public decimal VolumeKegged { get; set; }
        public decimal VolumeRemaining { get; set; }
        public float ABV { get; set; }
        public decimal? Rating { get; set; }
        public string BatchRecipeName { get; set; }
        public string BatchRecipeStyle { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Keg, KegDto>()
                .ForMember(dst => dst.VolumeRemaining, opt =>
                    opt.MapFrom(src =>
                        VolumeKegged - src.Pours.Sum(p => p.VolumePoured)))
                .ForMember(dst => dst.Rating, opt =>
                    opt.MapFrom(src => src.Batch.BatchRatings.Average(r => r.Rating)))
                .ForMember(dst => dst.ABV, opt => opt.MapFrom(src => (src.Batch.OG - src.Batch.FG) * 131.25f));
        }
    }
}
