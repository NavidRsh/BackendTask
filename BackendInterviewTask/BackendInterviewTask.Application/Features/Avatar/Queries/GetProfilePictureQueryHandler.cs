using BackendInterviewTask.Application.Gateways.Repositories.Image;
using BackendInterviewTask.Application.Strategies;
using BackendInterviewTask.Domain.Common;
using BackendInterviewTask.Domain.Common.Configurations;
using BackendInterviewTask.Domain.Domain;
using BackendInterviewTask.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Application.Features.Avatar.Queries;
public class GetProfilePictureQueryHandler : IRequestHandler<GetProfilePictureQuery, GetProfilePictureResponse>
{
    private readonly IImageQueryRepository _imageQueryRepository;
    private readonly ApplicationSettings _applicationSettings;

    public GetProfilePictureQueryHandler(IImageQueryRepository imageQueryRepository,
        IConfiguration configuration)
    {
        this._imageQueryRepository = imageQueryRepository;

        this._applicationSettings = configuration
            .GetSection(nameof(ApplicationSettings)).Get<ApplicationSettings>() ??
            throw AppException.Create(ApplicationErrorEnum.ConfigurationError);
    }

    public async Task<GetProfilePictureResponse> Handle(GetProfilePictureQuery request, CancellationToken cancellationToken)
    {
        var userResponse = User.Create(request.UserIdentifier, _applicationSettings);

        if (userResponse.AppException is not null)
            throw userResponse.AppException;

        var user = userResponse.Result ??
            throw AppException.Create(ApplicationErrorEnum.InvalidOperation); 

        var strategy = ProfilePictureStrategyFactory.CreateStrategy(user, _imageQueryRepository);

        var imageUrl = await strategy.GetImageUrl(user); 

        return new GetProfilePictureResponse(imageUrl);
    }
}
