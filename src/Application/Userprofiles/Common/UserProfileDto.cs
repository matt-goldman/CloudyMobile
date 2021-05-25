using CloudyMobile.Application.Addresses.Common;
using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;

namespace CloudyMobile.Application.Userprofiles.Common
{
    public class UserProfileDto : IMapFrom<UserProfile>
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Familyname { get; set; }

        public AddressDto HomeAddress { get; set; }

        public AddressDto WorkAddress { get; set; }
    }
}