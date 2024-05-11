using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR; 

namespace BackendInterviewTask.Application.Features.Avatar.Queries;
public sealed class GetProfilePictureQuery : IRequest<GetProfilePictureResponse>
{
    public GetProfilePictureQuery(string userIdentifier)
    {
        UserIdentifier = userIdentifier;
    }

    public string UserIdentifier { get; init; }

}


public class GetProfilePictureResponse
{
    public GetProfilePictureResponse(string url)
    {
        Url = url;
    }
    public string Url { get; private init; }
}
