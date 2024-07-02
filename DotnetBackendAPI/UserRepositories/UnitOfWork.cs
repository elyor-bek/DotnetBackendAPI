using DotnetBackendAPI.DB;
using DotnetBackendAPI.UserInterfaces;
using System;

namespace DotnetBackendAPI.UserRepositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dBContext = dbContext;
    public UserInterface UserInterface => new UserRepository(_dBContext);

    public void Dispose()
    =>GC.SuppressFinalize(this);

    public async Task<int> SaveAsync()
    =>await _dBContext.SaveChangesAsync();
}
