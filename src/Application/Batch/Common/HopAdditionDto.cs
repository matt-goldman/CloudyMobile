using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;
using System;

namespace CloudyMobile.Application.Batch.Common
{
    public class HopAdditionDto : IMapFrom<HopAddition>
    {
        public string IngredientName { get; set; }
        public int IngredientId { get; set; }
        public int? Minutes { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? Temperature { get; set; }
    }
}
