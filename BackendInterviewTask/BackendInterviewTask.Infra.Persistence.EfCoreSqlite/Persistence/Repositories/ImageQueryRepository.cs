using BackendInterviewTask.Application.Gateways.Repositories.Image;
using BackendInterviewTask.Infra.Persistence.EfCoreSQlite.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Infra.Persistence.EfCoreSqlite.Persistence.Repositories;
public sealed class ImageQueryRepository : IImageQueryRepository
{
    protected readonly ApplicationDbContext _context;

    public ImageQueryRepository(ApplicationDbContext context)
    {
        _context = context; 
    }

    public async Task<string?> GetImageUrlById(int id)
    {
        return await _context.Images
            .Where(a => a.Id == id)
            .Select(a => a.Url)
            .FirstOrDefaultAsync(); 
    }
}
