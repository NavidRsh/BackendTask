using BackendInterviewTask.Application.Gateways.Repositories.Image;
using BackendInterviewTask.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Application.Strategies.ProfilePicture;
public sealed class KnownImageStrategy : IProfilePictureStrategy
{
    public async ValueTask<string> GetImageUrl(User user)
    {
        if (user is not UserWithKnownImage)
            throw new ArgumentException();

        return await Task.FromResult(((UserWithKnownImage)user).PictureSourceUrl);
    }
}
