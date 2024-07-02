using System.ComponentModel.DataAnnotations;

namespace DotnetBackendAPI.DTOs;

public class AddUserDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public List<string> University { get; set; } = new();
}
