using CloudyMobile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudyMobile.Infrastructure.Persistence.Configurations
{
    public class BatchHopAdditionsConfiguration : IEntityTypeConfiguration<BatchHopAdditions>
    {
        public void Configure(EntityTypeBuilder<BatchHopAdditions> builder)
        {
            builder.HasOne(bha => bha.Batch)
                .WithMany(b => b.HopAdditions)
                .HasForeignKey(bha => bha.BatchId);

            builder.HasOne(bha => bha.HopAddition)
                .WithMany(h => h.Batches)
                .HasForeignKey(bha => bha.HopAdditionId);
        }
    }
}
