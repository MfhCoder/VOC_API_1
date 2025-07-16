namespace Application.Dtos.UserDtos;

public record UserDto(
    string Id,
    string Name,
    string Email,
    string Mobile,
    DateTime JoiningDate,
    string Status,
    string Role,
    string Organization);
