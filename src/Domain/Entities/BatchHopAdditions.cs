namespace CloudyMobile.Domain.Entities
{
    public class BatchHopAdditions
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public Batch Batch { get; set; }
        public int HopAdditionId { get; set; }
        public HopAddition HopAddition { get; set; }
    }
}
