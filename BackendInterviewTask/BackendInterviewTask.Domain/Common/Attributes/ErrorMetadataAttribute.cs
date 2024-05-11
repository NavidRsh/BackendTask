using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.Common.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class ErrorMetadataAttribute : Attribute
{
    public string Title { get; set; }

    public string Message { get; set; }
}
