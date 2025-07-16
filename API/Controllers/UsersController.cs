using API.RequestHelpers;
using Application.Dtos.UserDtos;
using Application.Interfaces;
using Application.Specifications;
using Application.Specifications.Users;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Infrastructure;

namespace API.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseApiController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork unit;

    public UsersController(IUserService userService,
        IUnitOfWork unitOfWork,
      IMapper mapper) : base(mapper)
    {
        _userService = userService;
        unit = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<UserDto>>> GetUsers([FromQuery] UserFilterParams filterParams)
    {
        var spec = new UserSpecification(filterParams);
        return await CreatePagedResult(unit.Repository<User>(), spec, filterParams.PageIndex, filterParams.PageSize);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
    {
        var user = await _userService.CreateUserAsync(createUserDto);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        var user = await _userService.UpdateUserAsync(id, updateUserDto);
        return Ok(user);
    }

    //[HttpDelete("{id}")]
    //[Authorize(Roles = "Admin")]
    //public async Task<IActionResult> DeleteUser(string id)
    //{
    //    await _userService.DeleteUserAsync(id);
    //    return NoContent();
    //}

    //[HttpPost("{id}/deactivate")]
    //public async Task<IActionResult> DeactivateUser(string id)
    //{
    //    await _userService.ChangeUserStatusAsync(id, UserStatus.Deactivated);
    //    return NoContent();
    //}

    //[HttpPost("{id}/activate")]
    //public async Task<IActionResult> ActivateUser(string id)
    //{
    //    await _userService.ChangeUserStatusAsync(id, UserStatus.Active);
    //    return NoContent();
    //}
}