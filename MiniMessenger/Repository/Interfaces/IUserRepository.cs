using MiniMessenger.Models;
namespace MiniMessenger.Repository.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UsersModel> GetUsersListExceptCurrent(string currentUserId);
    }
}
