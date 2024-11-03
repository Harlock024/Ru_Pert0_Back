using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ru_pert0_back.api.Context;
using ru_pert0_back.api.Customs;
using ru_pert0_back.api.DTO;
using ru_pert0_back.api.Models;

namespace ru_pert0_back.api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class AuthControllers(AppDbContext context, Utils utils) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDTO user)
    {
        var newUser = new User
        {
                Username = user.Username,
                Email = user.Email,
                Password = utils.EncriptToken(user.Password)
        };
        await context.Users.AddAsync(newUser);
        await context.SaveChangesAsync();
        return newUser.Id !=0? StatusCode(StatusCodes.Status201Created, new {isSuccess = true}) : StatusCode(StatusCodes.Status400BadRequest, new {isSuccess = false});
        }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDto)
    {
        var userExisted = await context.Users
            .Where(u =>
                u.Email == loginDto.Email &&
                u.Password == utils.EncriptToken(loginDto.Password)).FirstOrDefaultAsync();
        return userExisted  !=null ? StatusCode(StatusCodes.Status200OK, new {isSuccess = true, token= utils.GenerateToken(userExisted)}) : StatusCode(StatusCodes.Status400BadRequest, new {isSuccess = false});
    }
}