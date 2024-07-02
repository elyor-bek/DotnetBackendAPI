using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DotnetBackendAPI.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Surname { get; set; } = string.Empty;
    [Required]
    public string Number {  get; set; } = string.Empty;
    public List<string> University { get; set; } = new();
}
