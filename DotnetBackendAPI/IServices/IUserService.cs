using DotnetBackendAPI.DTOs;
using DotnetBackendAPI.Filters;

namespace DotnetBackendAPI.IServices;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task AddUsersAsync(AddUserDto userDto);
    Task DeleteUsersAsync(int Id);
    Task<List<UserDto>> FilterAsync(UserFilter userFilter);
    Task<UserDto> GetUserByIdAsync(int id);
}
