namespace DotnetBackendAPI.UserInterfaces;

public interface IUnitOfWork : IDisposable
{
    UserInterface UserInterface { get; }
    Task<int> SaveAsync();
}
