using CloudyMobile.Application.Addresses.Common;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Userprofiles.Common;
using CloudyMobile.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Userprofiles.Commands.RegisterUserprofile
{
    public class RegisterUserprofileCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Familyname { get; set; }

        public AddressDto HomeAddress { get; set; }

        public AddressDto WorkAddress { get; set; }
    }

    public class RegisterUserprofileCommandHandler : IRequestHandler<RegisterUserprofileCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public RegisterUserprofileCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RegisterUserprofileCommand request, CancellationToken cancellationToken)
        {
            var entity = new UserProfile
            {
                Firstname = request.Firstname,
                Familyname = request.Familyname,
                HomeAddress = new Address
                {
                    Buidlingnumber = request.HomeAddress.Buidlingnumber,
                    BuildingName = request.HomeAddress.BuildingName,
                    StreetName = request.HomeAddress.StreetName,
                    AddressLine2 = request.HomeAddress.AddressLine2,
                    Suburb = request.HomeAddress.Suburb,
                    City = request.HomeAddress.City,
                    State = request.HomeAddress.State,
                    Postcode = request.HomeAddress.Postcode,
                    CountryCode = request.HomeAddress.CountryCode,
                    CountryName = request.HomeAddress.CountryName,
                },
                WorkAddress = new Address
                {
                    Buidlingnumber = request.WorkAddress.Buidlingnumber,
                    BuildingName = request.WorkAddress.BuildingName,
                    StreetName = request.WorkAddress.StreetName,
                    AddressLine2 = request.WorkAddress.AddressLine2,
                    Suburb = request.WorkAddress.Suburb,
                    City = request.WorkAddress.City,
                    State = request.WorkAddress.State,
                    Postcode = request.WorkAddress.Postcode,
                    CountryCode = request.WorkAddress.CountryCode,
                    CountryName = request.WorkAddress.CountryName,
                }
            };

            _context.UserProfiles.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}