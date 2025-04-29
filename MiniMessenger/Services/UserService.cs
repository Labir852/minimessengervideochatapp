using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMessenger.Models;
using System;
using VideoChatApp.Data;
using VideoChatApp.Models;

namespace MiniMessenger.Services
{
    
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<UsersModel>> GetAllUsersExceptAsync(string currentUserId)
        {
            return await _context.Users
                .Where(u => u.Id != currentUserId)
                .Select(u => new UsersModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    // Add more fields if needed
                })
                .ToListAsync();
        }

    }
}
