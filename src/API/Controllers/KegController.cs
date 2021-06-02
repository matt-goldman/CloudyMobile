using CloudyMobile.Application.Kegs.Commands.AddKeg;
using CloudyMobile.Application.Kegs.Commands.AddKegPour;
using CloudyMobile.Application.Kegs.Commands.CloseKeg;
using CloudyMobile.Application.Kegs.Queries.Common;
using CloudyMobile.Application.Kegs.Queries.GetAllKegs;
using CloudyMobile.Application.Kegs.Queries.GetKeg;
using CloudyMobile.Application.Kegs.Queries.GetLocationKegs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CloudyMobile.API.Controllers
{
    public class KegController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> AddKeg(AddKegCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<KegListVm>> Get()
        {
            return await Mediator.Send(new GetAllKegsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KegDto>> GetKeg(int id)
        {
            return await Mediator.Send(new GetKegQuery { Id = id });
        }

        [HttpGet("{action}")]
        public async Task<ActionResult<KegListVm>> GetLocationKeg([FromQuery]int id)
        {
            return await Mediator.Send(new GetLocationKegsQuery { LocationId = id });
        }

        [HttpPost("{action}")]
        public async Task<ActionResult<float>> AddKegPour(AddKegPourCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("Close")]
        public async Task<ActionResult> Close(CloseKegCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
