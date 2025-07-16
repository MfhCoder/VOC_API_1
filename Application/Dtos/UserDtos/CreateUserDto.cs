using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.UserDtos;

public record CreateUserDto(
    [Required] string Name,
    [Required][EmailAddress] string Email,
    [Required] string Mobile,
    [Required] int RoleId,
    [Required] string Status);
