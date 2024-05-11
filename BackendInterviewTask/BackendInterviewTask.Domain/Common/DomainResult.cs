using BackendInterviewTask.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.Common;
public sealed class DomainResult<T>
{
    private DomainResult(T? result, bool hasError, AppException? appException)
    {
        Result = result;
        HasError = hasError;
        AppException = appException;
    }

    private DomainResult(bool hasError, AppException? appException)
    {
        HasError = hasError;
        AppException = appException;
    }

    public static DomainResult<T> CreateOkResponse(T result)
    {
        return new DomainResult<T>(result, false, null); 
    }

    public static DomainResult<T> CreateErrorResponse(ApplicationErrorEnum applicationError)
    {
        return new DomainResult<T>(true, AppException.Create(applicationError)); 
    }

    public T? Result { get; private set; }

    public bool HasError { get; private set; }

    public AppException? AppException { get; private set; }
}
