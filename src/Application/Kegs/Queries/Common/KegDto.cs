using AutoMapper;
using CloudyMobile.Application.Batch.Common;
using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;
using System;
using System.Linq;

namespace CloudyMobile.Application.Kegs.Queries.Common
{
    public class KegDto : IMapFrom<Keg>
    {
        public int Id { get; set; }
        public BatchDto Batch { get; set; }
        public int BatchId { get; set; }
        public string LocationName { get; set; }
        public string LocationId { get; set; }
        public DateTime DateKegged { get; set; }
        public decimal VolumeKegged { get; set; }
        public decimal VolumeRemaining { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<CloudyMobile.Domain.Entities.Batch, BatchDto>()
            //    .ForMember(dst => dst.AverageRating, opt => opt.MapFrom(src => src.BatchRatings.Average(r => r.Rating)));

            profile.CreateMap<Keg, KegDto>()
                .ForMember(dst => dst.VolumeRemaining, opt =>
                    opt.MapFrom(src =>
                        VolumeKegged - src.Pours.Sum(p => p.VolumePoured)));
        }
    }
}
