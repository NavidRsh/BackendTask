using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.Common.Configurations;
public class ApplicationSettings
{
    public string GreaterLastDigitSourceApi { get; set; }

    public string VowelCharacterSourceUrl { get; set; }

    public string NonAlphanumericSourceUrl { get; set; }

    public string ElseSourceUrl { get; set; }


}
