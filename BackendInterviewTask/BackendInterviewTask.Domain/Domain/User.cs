using BackendInterviewTask.Domain.Common;
using BackendInterviewTask.Domain.Common.Configurations;
using BackendInterviewTask.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BackendInterviewTask.Domain.Domain;
public abstract class User
{
    public User()
    {

    }
    private User(string userIdentifier) : base()
    {
        UserIdentifier = userIdentifier;
    }

    #region Factory
    public static DomainResult<User> Create(string userIdentifier, ApplicationSettings appSettings)
    {
        if (String.IsNullOrEmpty(userIdentifier))
            return DomainResult<User>.CreateErrorResponse(ApplicationErrorEnum.InvalidUserIdentifier);

        var lastDigit = GetLastCharAsNumber(userIdentifier);

        if (InGreaterLastDigits(lastDigit))
        {
            return DomainResult<User>.CreateOkResponse(
                UserWithExternalImage.Create(userIdentifier,
                appSettings.GreaterLastDigitSourceApi + lastDigit?.ToString()));
        }
        else if (InSmallerLastDigits(lastDigit))
        {
            return DomainResult<User>.CreateOkResponse(
                UserWithDbImage.Create(userIdentifier, lastDigit ?? 0));
        }
        else if (ContainsVowelCharacter(userIdentifier))
        {
            return DomainResult<User>.CreateOkResponse(
                UserWithKnownImage.Create(userIdentifier,
                appSettings.VowelCharacterSourceUrl));
        }
        else if (ContainsNonAlphanumeric(userIdentifier))
        {
            var rand = new Random();
            var randomNumber = rand.Next(1, 5);

            var nonAlphanumericUrl = appSettings.NonAlphanumericSourceUrl
                .Replace("{randomNumber}", randomNumber.ToString());

            return DomainResult<User>.CreateOkResponse(
                UserWithKnownImage.Create(userIdentifier, nonAlphanumericUrl));
        }
        else
        {
            return DomainResult<User>.CreateOkResponse(
                UserWithKnownImage.Create(userIdentifier, appSettings.ElseSourceUrl));
        }
    }
    #endregion 

    public string UserIdentifier { get; protected init; }

    #region Helper methods for domain logic 
    private static bool InGreaterLastDigits(int? lastDigit)
    {
        var greaterLastDigits = new List<int>() { 6, 7, 8, 9 };

        return
            lastDigit is not null && greaterLastDigits.Contains(lastDigit.Value);
    }

    private static bool InSmallerLastDigits(int? lastDigit)
    {
        var smallerLastDigits = new List<int>() { 1, 2, 3, 4, 5 };

        return
            lastDigit is not null && smallerLastDigits.Contains(lastDigit.Value);
    }

    private static bool ContainsVowelCharacter(string identifier)
    {
        var vowelCharacters = new List<Char>() { 'a', 'e', 'u', 'i', 'o' };

        return identifier.Any(c => vowelCharacters.Contains(c));
    }

    private static bool ContainsNonAlphanumeric(string identifier)
    {
        string pattern = @"[^a-zA-Z0-9]";

        return Regex.IsMatch(identifier, pattern);
    }

    private static int? GetLastCharAsNumber(string text)
    {
        var lastCharacter = text
            .Substring(text.Length - 1);

        if (Char.IsNumber(lastCharacter, 0))
        {
            return int.Parse(lastCharacter);
        }

        return null;
    }

    #endregion
}
