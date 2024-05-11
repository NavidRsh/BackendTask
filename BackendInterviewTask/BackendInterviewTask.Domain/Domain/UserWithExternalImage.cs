using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.Domain;
public sealed class UserWithExternalImage : User
{
    public UserWithExternalImage(string userIdentifier, string externalApiAddress)
    {
        UserIdentifier = userIdentifier;
        ExternalApiAddress = externalApiAddress;
    }

    public static UserWithExternalImage Create(string userIdentifier, string externalApiAddress)
    {
        return new UserWithExternalImage(userIdentifier, externalApiAddress);
    }

    public string ExternalApiAddress { get; private init; }
}
