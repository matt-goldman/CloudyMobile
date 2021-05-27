using CloudyMobile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudyMobile.Infrastructure.Persistence.Configurations
{
    public class KegConfiguration : IEntityTypeConfiguration<Keg>
    {
        public void Configure(EntityTypeBuilder<Keg> builder)
        {
            builder.Ignore(nameof(Keg.CurrentVolume));
        }
    }
}
