using System.Linq;

namespace CloudyMobile.Application.Helpers
{
    public static class BatchExtensions
    {
        public static double GetAverageRating(this CloudyMobile.Domain.Entities.Batch batch)
        {
            if(batch.BatchRatings.Any())
            {
                return batch.BatchRatings.Average(r => r.Rating);
            }
            else
            {
                return 0;
            }
        }
    }
}
