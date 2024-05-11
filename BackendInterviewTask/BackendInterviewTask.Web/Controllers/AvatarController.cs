using BackendInterviewTask.Application.Features.Avatar.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR; 

namespace BackendInterviewTask.Web.Controllers;
[Route("[controller]")]
[ApiController]
public class AvatarController : ControllerBase
{
    private readonly IMediator _mediator;
    public AvatarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetProfilePictureResponse> Get(string userIdentifier)
    {
        var query = new GetProfilePictureQuery(userIdentifier);

        return await _mediator.Send(query);
    }
}
