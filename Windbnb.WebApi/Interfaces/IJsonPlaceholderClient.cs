using Windbnb.WebApi.Clients;
using Windbnb.WebApi.Models.DTOs.RequestDTOs;
using Windbnb.WebApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Windbnb.WebApi.Interfaces
{
    public interface IJsonPlaceholderClient
    {
        Task<JsonPlaceholderResult<User>> AddUserAsync([FromBody] AddUserRequest addUserRequest);

        Task<JsonPlaceholderResult<User>> GetUserByIdAsync(int id);

        Task<JsonPlaceholderResult<List<User>>> GetUsersAsync();
    }
}