using Application.Dtos.UserDtos;
using Application.Interfaces;
using Application.Specifications.Users;
using AutoMapper;
using Core.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emailService = emailService;
    }

    //public async Task<Pagination<UserDto>> GetUsersAsync(UserFilterParams filterParams)
    //{
    //    var spec = new UserSpecification(filterParams);
    //    var countSpec = new UserSpecification(filterParams);

    //    var totalItems = await _unitOfWork.Repository<User>().CountAsync(countSpec);
    //    var users = await _unitOfWork.Repository<User>().ListAsync(spec);

    //    var data = _mapper.Map<IReadOnlyList<UserDto>>(users);

    //    return new Pagination<UserDto>(
    //        filterParams.PageNumber,
    //        filterParams.PageSize,
    //        totalItems,
    //        data);
    //}

    public async Task<UserDto> GetUserByIdAsync(int userId)
    {
        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto createDto)
    {
        var user = _mapper.Map<User>(createDto);

        // Generate temporary password and hash it
        var tempPassword = GenerateTemporaryPassword();
        CreatePasswordHash(tempPassword, out var passwordHash, out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _unitOfWork.Repository<User>().Add(user);
        await _unitOfWork.Complete();

        // Send invitation email
        await _emailService.SendUserInvitationAsync(user.Email, tempPassword);

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateDto)
    {
        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId);
        _mapper.Map(updateDto, user);

        _unitOfWork.Repository<User>().Update(user);
        await _unitOfWork.Complete();

        return _mapper.Map<UserDto>(user);
    }

    //public async Task<bool> DeleteUserAsync(int userId)
    //{
    //    var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId);
    //    _unitOfWork.Repository<User>().Delete(user);
    //    return await _unitOfWork.Complete();
    //}

    public async Task<bool> ChangeUserStatusAsync(int userId, UserStatus status)
    {
        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId);
        user.Status = status;

        _unitOfWork.Repository<User>().Update(user);
        return await _unitOfWork.Complete();
    }

    private string GenerateTemporaryPassword()
    {
        return Guid.NewGuid().ToString("N")[..8]; // 8-character random password
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}