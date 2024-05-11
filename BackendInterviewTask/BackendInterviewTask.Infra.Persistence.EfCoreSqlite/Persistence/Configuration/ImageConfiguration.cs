using BackendInterviewTask.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Infra.Persistence.EfCoreSqlite.Persistence.Configuration;
public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(
            
            Image.Create(1, "https://api.dicebear.com/8.x/pixel-art/png?seed=john&size=150"),

            Image.Create(2, "https://api.dicebear.com/8.x/pixel-art/png?seed=jane&size=150"),

            Image.Create(3, "https://api.dicebear.com/8.x/pixel-art/png?seed=aneka&size=150"),

            Image.Create(4, "https://api.dicebear.com/8.x/pixel-art/png?seed=flix&size=150"),

            Image.Create(5, "https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150"));
    }
}
