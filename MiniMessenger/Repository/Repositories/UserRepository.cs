using Microsoft.AspNetCore.Http.HttpResults;
using MiniMessenger.Models;
using MiniMessenger.Repository.Interfaces;
using System.Data;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace MiniMessenger.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string DefaultConnection) 
        {
            _connectionString = DefaultConnection;
        }

        public IEnumerable<UsersModel> GetUsersListExceptCurrent(string currentUserId)
        {
            var users = new List<UsersModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetAllUsersExceptCurrent", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new UsersModel
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")).ToString(),
                            UserName = reader.GetString(reader.GetOrdinal("UserName"))
                        });
                    }
                }
            }

            return users;
        }
    }
}
