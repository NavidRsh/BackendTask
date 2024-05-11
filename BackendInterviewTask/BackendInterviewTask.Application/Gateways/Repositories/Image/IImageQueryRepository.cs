using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Application.Gateways.Repositories.Image;
public interface IImageQueryRepository
{
    Task<string?> GetImageUrlById(int id);
}
