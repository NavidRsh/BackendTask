using BackendInterviewTask.Domain.Common;
using BackendInterviewTask.Domain.Common.Configurations;
using BackendInterviewTask.Domain.Domain;
using BackendInterviewTask.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendInterviewTask.Domain.UnitTests.Domain;
public class UserTests: IClassFixture<MainFixture>
{
    private readonly MainFixture _mainFixture;
    public UserTests(MainFixture mainFixture)
    {
        _mainFixture = mainFixture; 
    }

    [Theory]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("23")]
    [InlineData("154")]
    [InlineData("10005")]
    public void User_WhenSmallerLastDigit_ShouldBeUserWithDbImage(string userIdentifier)
    {
        var user = User.Create(userIdentifier, _mainFixture.AppSettings);

        Assert.Equal(typeof(UserWithDbImage), user.Result.GetType());
    }

    [Theory]
    [InlineData("6")]
    [InlineData("17")]
    [InlineData("2008")]
    [InlineData("9")]    
    public void User_WhenGreaterLastDigit_ShouldBeUserWithExternalImage(string userIdentifier)
    {
        var user = User.Create(userIdentifier, _mainFixture.AppSettings);

        Assert.Equal(typeof(UserWithExternalImage), user.Result.GetType());
    }

    [Theory]
    [InlineData("adfas0")]
    [InlineData("a")]
    [InlineData("test10%")]
    [InlineData("15420$")]
    [InlineData("0")]
    public void User_WhenOtherConditions_ShouldBeUserWithKnownImage(string userIdentifier)
    {
        var user = User.Create(userIdentifier, _mainFixture.AppSettings);

        Assert.Equal(typeof(UserWithKnownImage), user.Result.GetType());        
    }

    [Theory]
    [InlineData("1a")]
    [InlineData("io")]
    [InlineData("io0")]
    public void ImageUrl_WhenVowelCharacter_ShouldBeCorrect(string userIdentifier)
    {
        var user = User.Create(userIdentifier, _mainFixture.AppSettings);

        Assert.Equal(_mainFixture.AppSettings.VowelCharacterSourceUrl, ((UserWithKnownImage)user.Result).PictureSourceUrl);
    }

    [Theory]
    [InlineData("bcd")]
    [InlineData("210")]
    public void ImageUrl_WhenElse_ShouldBeCorrect(string userIdentifier)
    {
        var user = User.Create(userIdentifier, _mainFixture.AppSettings);

        Assert.Equal(_mainFixture.AppSettings.ElseSourceUrl, ((UserWithKnownImage)user.Result).PictureSourceUrl);
    }
}
