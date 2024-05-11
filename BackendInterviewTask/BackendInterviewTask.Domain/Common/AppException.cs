using BackendInterviewTask.Domain.Common.Attributes;
using BackendInterviewTask.Domain.Enums;
using BackendInterviewTask.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.Common;
public class AppException : Exception
{
    private AppException(ApplicationErrorEnum appError)
    {
        ApplicationError = appError;
        Message = appError.GetAttribute<ErrorMetadataAttribute>()?.Message ?? string.Empty; 
    }

    public static AppException Create(ApplicationErrorEnum appError)
    {
        return new AppException(appError);
    }

    public ApplicationErrorEnum ApplicationError { get; init; }

    public string Message { get; init; }

}
