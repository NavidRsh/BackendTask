using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.Domain;
public sealed class UserWithDbImage : User
{
    public UserWithDbImage(string userIdentifier, int imageId)
    {
        UserIdentifier = userIdentifier;
        ImageId = imageId;        
    }

    public static UserWithDbImage Create(string userIdentifier, int imageId)
    {
        return new UserWithDbImage(userIdentifier, imageId);        
    }

    public int ImageId { get; private init; }
}
