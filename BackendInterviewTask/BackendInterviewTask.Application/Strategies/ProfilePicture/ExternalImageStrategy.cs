using BackendInterviewTask.Application.Gateways.Repositories.Image;
using BackendInterviewTask.Domain.Common;
using BackendInterviewTask.Domain.Domain;
using BackendInterviewTask.Domain.Dtos;
using BackendInterviewTask.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackendInterviewTask.Application.Strategies.ProfilePicture;
public sealed class ExternalImageStrategy : IProfilePictureStrategy
{   
    public async ValueTask<string> GetImageUrl(User user)
    {
        if (user is not UserWithExternalImage)
            throw new ArgumentException();

        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage response = await httpClient.GetAsync(((UserWithExternalImage)user).ExternalApiAddress);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");

                throw AppException.Create(ApplicationErrorEnum.HttpRequestError);                
            }

            string responseBody = await response.Content.ReadAsStringAsync();

            var responseObject = JsonSerializer.Deserialize<ExternalImageAddressDto>(responseBody);

            return responseObject?.Url ?? throw AppException.Create(ApplicationErrorEnum.HttpRequestError); ; 
        }
    }
}
