using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.Helpers;
public static class EnumHelper
{
    public static T? GetAttribute<T>(this Enum enumValue) where T : System.Attribute
    {
        try
        {
            return enumValue.GetType()
              .GetMember(enumValue.ToString())
              ?.First()
              ?.GetCustomAttribute<T>() ?? default;
        }
        catch
        {
            return default;
        }
    }
}
