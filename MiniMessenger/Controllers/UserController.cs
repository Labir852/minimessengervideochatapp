using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MiniMessenger.Repository.Interfaces;
using MiniMessenger.Services;
using System.Security.Claims;
//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    //private readonly IUserRepository _userService;

    //public UsersController(IUserRepository userService)
    //{
    //    _userService = userService;
    //}

    [HttpGet]
    public string GetUsers()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // If JWT-based auth
          
        //if (string.IsNullOrEmpty(currentUserId))
        //{
        //    return Unauthorized();
        //}

        //var users =  _userService.GetUsersListExceptCurrent(currentUserId);
        return currentUserId + "afdasfas";
    }
}
