using DotnetBackendAPI.DTOs;
using DotnetBackendAPI.Filters;
using DotnetBackendAPI.IServices;
using DotnetBackendAPI.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBackendAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetUsersAsync();
        return Ok(users);
    }
    [HttpPost]
    public async Task<IActionResult> Post(AddUserDto dto)
    {
        try
        {
            await _userService.AddUsersAsync(dto);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(ResponseErrors ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (Exception ex)
        {
            return StatusCode(500,ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }
    [HttpGet("with-filter")]
    public async Task<IActionResult> GetByFilterAsync([FromQuery] UserFilter filter)
    {
        try
        {
            var users = await _userService.FilterAsync(filter);
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteUsersAsync(id);
        return Ok();
    }
}
