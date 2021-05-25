using CloudyMobile.Application.Userprofiles.Commands.RegisterUserprofile;
using CloudyMobile.Application.Userprofiles.Common;
using CloudyMobile.Application.Userprofiles.Queries.GetUserProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CloudyMobile.API.Controllers
{
    [Authorize]
    public class UserprofilesController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileDto>> GetTodoItemsWithPagination([FromQuery] GetUserProfileQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(RegisterUserprofileCommand command)
        {
            return await Mediator.Send(command);
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
        // {
        //     if (id != command.Id)
        //     {
        //         return BadRequest();
        //     }

        //     await Mediator.Send(command);

        //     return NoContent();
        // }

        // [HttpPut("[action]")]
        // public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
        // {
        //     if (id != command.Id)
        //     {
        //         return BadRequest();
        //     }

        //     await Mediator.Send(command);

        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult> Delete(int id)
        // {
        //     await Mediator.Send(new DeleteTodoItemCommand { Id = id });

        //     return NoContent();
        // }
    }
}