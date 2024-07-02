using AutoMapper;
using DotnetBackendAPI.DB;
using DotnetBackendAPI.DTOs;
using DotnetBackendAPI.Filters;
using DotnetBackendAPI.IServices;
using DotnetBackendAPI.Models;
using DotnetBackendAPI.UserInterfaces;
using DotnetBackendAPI.Validators;
using Newtonsoft.Json;

namespace DotnetBackendAPI.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(AppDbContext dbContext,
                       IMapper mapper,
                       IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task AddUsersAsync(AddUserDto userDto)
    {
        if(userDto == null) { throw new ArgumentNullException("User is null!!!"); }
        var validator = new UserValidator();
        var validatorResult = await validator.ValidateAsync(userDto);
        if(!validatorResult.IsValid) 
        {
            throw new ResponseErrors() { Errors = validatorResult.Errors.ToList() };
        }
        var config = _mapper.Map<User>(userDto);
        _unitOfWork.UserInterface.Add(config);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUsersAsync(int Id)
    {
        var accessory = await _unitOfWork.UserInterface.GetByIdAsync(Id);
        if (accessory == null) throw new Exception("User not found!");
        _unitOfWork.UserInterface.Delete(Id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<UserDto>> FilterAsync(UserFilter userFilter)
    {
        var accessories = await _unitOfWork.UserInterface.GetFilteredAccessoriesAsync(userFilter);
        return accessories.Select(i => _mapper.Map<UserDto>(i)).ToList();
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    => _mapper.Map<UserDto>(await _unitOfWork.UserInterface.GetByIdAsync(id));

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await _unitOfWork.UserInterface.GetAllAsync();
        var userDtos = _mapper.Map<List<UserDto>>(users);
        return userDtos;
    }
}
