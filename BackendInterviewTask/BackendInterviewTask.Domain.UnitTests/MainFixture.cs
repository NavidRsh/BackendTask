using BackendInterviewTask.Domain.Common.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.UnitTests;
public class MainFixture
{
    public ApplicationSettings AppSettings => new ApplicationSettings()
    {
        GreaterLastDigitSourceApi = "https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/",
        VowelCharacterSourceUrl = "https://api.dicebear.com/8.x/pixel-art/png?seed=vowel&size=150",
        NonAlphanumericSourceUrl = "https://api.dicebear.com/8.x/pixel-art/png?seed={randomNumber}&size=150",
        ElseSourceUrl = "https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150"
    };

}
