using Microsoft.AspNetCore.Mvc;
using MiniMessenger.Services;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsersController(UserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // If JWT-based auth
        if (string.IsNullOrEmpty(currentUserId))
        {
            return Unauthorized();
        }

        var users = await _userService.GetAllUsersExceptAsync(currentUserId);
        return Ok(users);
    }
}
