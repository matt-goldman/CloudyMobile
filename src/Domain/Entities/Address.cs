namespace CloudyMobile.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public string BuildingName { get; set; }
        public string Buidlingnumber { get; set; }
        public string StreetName { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}