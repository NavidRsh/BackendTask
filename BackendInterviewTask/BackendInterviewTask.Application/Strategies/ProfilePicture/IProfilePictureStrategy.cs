using BackendInterviewTask.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Application.Strategies.ProfilePicture;
public interface IProfilePictureStrategy
{
    ValueTask<string> GetImageUrl(User user); 

}
