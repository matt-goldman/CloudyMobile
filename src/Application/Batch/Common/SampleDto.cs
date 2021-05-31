using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;
using System;

namespace CloudyMobile.Application.Batch.Common
{
    public class SampleDto : IMapFrom<BatchSample>
    {
        public int BatchId { get; set; }
        public DateTime SampleDate { get; set; }
        public float? Gravity { get; set; }
        public long? Temperature { get; set; }
    }
}
