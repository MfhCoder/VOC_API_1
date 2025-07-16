using Application.Dtos.UserDtos;
using Application.DTOs;

namespace Application.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(int userId);
    //Task<Pagination<UserDto>> GetUsersAsync(UserFilterParams filterParams);
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
    Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto);
    //Task<bool> DeleteUserAsync(string userId);
    //Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    //Task<AuthResponseDto> RefreshTokenAsync(string token, string refreshToken);
}

