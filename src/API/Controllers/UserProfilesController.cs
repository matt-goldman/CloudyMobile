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
    }
}