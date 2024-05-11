using BackendInterviewTask.Domain.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.Enums;
public enum ApplicationErrorEnum
{
    [ErrorMetadata(Message = "User identifier is not valid!")]
    InvalidUserIdentifier = 1,

    [ErrorMetadata(Message = "Invalid object operation!")]
    InvalidOperation = 2,

    [ErrorMetadata(Message = "External api calll error!")]
    HttpRequestError = 3,

    [ErrorMetadata(Message = "App configuration is not found!")]
    ConfigurationError = 4
}
