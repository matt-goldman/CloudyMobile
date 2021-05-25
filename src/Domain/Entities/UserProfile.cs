namespace CloudyMobile.Domain.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Familyname { get; set; }

        public Address HomeAddress { get; set; }

        public Address WorkAddress { get; set; }
    }
}