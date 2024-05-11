using BackendInterviewTask.Application.Gateways.Repositories.Image;
using BackendInterviewTask.Application.Strategies.ProfilePicture;
using BackendInterviewTask.Domain.Common;
using BackendInterviewTask.Domain.Domain;
using BackendInterviewTask.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Application.Strategies;
public class ProfilePictureStrategyFactory
{
    public static IProfilePictureStrategy CreateStrategy(User user,
        IImageQueryRepository imageQueryRepository)
    {
        if (user is UserWithDbImage)
            return new DbImageStrategy(imageQueryRepository);

        else if (user is UserWithExternalImage)
            return new ExternalImageStrategy();

        else if (user is UserWithKnownImage)
            return new KnownImageStrategy();

        else
            throw AppException.Create(ApplicationErrorEnum.InvalidOperation);
    }
}
