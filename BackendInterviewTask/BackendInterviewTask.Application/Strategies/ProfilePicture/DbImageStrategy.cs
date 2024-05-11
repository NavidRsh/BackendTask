using BackendInterviewTask.Application.Gateways.Repositories.Image;
using BackendInterviewTask.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Application.Strategies.ProfilePicture;
public sealed class DbImageStrategy : IProfilePictureStrategy
{
    private readonly IImageQueryRepository _imageQueryRepository;

    public DbImageStrategy(IImageQueryRepository imageQueryRepository)
    {
        this._imageQueryRepository = imageQueryRepository;
    }

    public async ValueTask<string> GetImageUrl(User user)
    {
        if (user is not UserWithDbImage)
            throw new ArgumentException();

        return await _imageQueryRepository
            .GetImageUrlById(((UserWithDbImage)user).ImageId) ?? ""; 
    }
}
