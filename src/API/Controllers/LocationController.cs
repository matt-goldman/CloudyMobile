using CloudyMobile.Application.Locations.Commands.AddLocation;
using CloudyMobile.Application.Locations.Queries.Common;
using CloudyMobile.Application.Locations.Queries.GetLocation;
using CloudyMobile.Application.Locations.Queries.GetLocations;
using CloudyMobile.Application.Locations.Queries.SearchLocation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CloudyMobile.API.Controllers
{
    public class LocationController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<LocationsVm>> Get()
        {
            return await Mediator.Send(new GetLocationsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> Get(int id)
        {
            return await Mediator.Send(new GetLocationQuery { Id = id });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<LocationsVm>> Search(string searchTerm)
        {
            return await Mediator.Send(new SearchLocationQuery { SearchTerm = searchTerm });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(AddLocationCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
