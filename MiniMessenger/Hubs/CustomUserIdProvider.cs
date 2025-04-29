using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
public class CustomUserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        return connection.User?.Identity?.Name; // Ensure Name is set correctly via authentication
    }
}
