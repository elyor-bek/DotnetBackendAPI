using DotnetBackendAPI.Filters;
using DotnetBackendAPI.Models;
using Newtonsoft.Json.Bson;

namespace DotnetBackendAPI.UserInterfaces;

public interface UserInterface
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<List<User>> GetFilteredAccessoriesAsync(UserFilter filter);
    Task<User?> GetByIdAsync(int id);
    void Add(User user);
    void Delete(int Id);
}
