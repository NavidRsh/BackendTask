using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.Domain;
public sealed class UserWithKnownImage : User
{
    public UserWithKnownImage(string userIdentifier, string pictureSourceUrl)
    {
        UserIdentifier = userIdentifier;
        PictureSourceUrl = pictureSourceUrl;
    }

    public static UserWithKnownImage Create(string userIdentifier, string pictureSourceUrl)
    {
        return new UserWithKnownImage(userIdentifier, pictureSourceUrl);
    }

    public string PictureSourceUrl { get; private init; }
}
