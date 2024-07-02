using DotnetBackendAPI.DB;
using DotnetBackendAPI.Filters;
using DotnetBackendAPI.Models;
using DotnetBackendAPI.UserInterfaces;
using Microsoft.EntityFrameworkCore;

namespace DotnetBackendAPI.UserRepositories;

public class UserRepository : UserInterface
{
    public AppDbContext _dbContext;
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(User user)
    =>_dbContext.Users.Add(user);

    public void Delete(int Id)
    {
      var entity = _dbContext.Users.AsNoTracking().FirstOrDefault(o => o.Id == Id);
      _dbContext.Users.Remove(entity!);
    }
    public async Task<IEnumerable<User>> GetAllAsync()
    => await _dbContext.Users.AsNoTracking().ToListAsync();

    public async Task<User?> GetByIdAsync(int Id)
    => await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);

    public async Task<List<User>> GetFilteredAccessoriesAsync(UserFilter filter)
    {
        var query = _dbContext.Users.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Name))
            query = query.Where(h => h.Name == filter.Name);
        
        if (!string.IsNullOrEmpty(filter.Surname))
            query = query.Where(h => h.Surname == filter.Surname);

        if (!string.IsNullOrEmpty(filter.Number))
            query = query.Where(h => h.Number == filter.Number);

        query = query.Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize);

        return await query.ToListAsync();
    }
}
