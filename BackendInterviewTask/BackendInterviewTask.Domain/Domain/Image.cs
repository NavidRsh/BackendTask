using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.Domain;
public sealed class Image
{
    private Image()
    {
        
    }

    public Image(int id, string url)
    {
        Id = id;
        Url = url;
    }

    public static Image Create(int id, string url)
    { 
        return new Image(id, url);    
    }

    public int Id { get; private init; }

    public string Url { get; private set; }
}
