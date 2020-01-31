using Dapper;
using Microsoft.Extensions.Configuration;
using swgoh_counters.api.Commands;
using swgoh_counters.api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace swgoh_counters.api.DataAccess
{
    public class UserRepository
    {
        private string _connectionString;

        public UserRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SWGOHCountersConnection");
        }

        public List<User> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var users = connection.Query<User>("Select * from [User]");

                return users.AsList();
            }
        }

        public User Get(string AllyCode)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"SELECT * FROM [User] WHERE User.AllyCode = @AllyCode";

                var parameters = new
                {
                    AllyCode
                };

                var user = connection.QueryFirst<User>(sql, parameters);

                return user;
            }
        }

        public bool Create(AddUserCommand newUser)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"INSERT INTO [dbo].[Counter]
                                                   ([AllyCode]
                                                   ,[Email]
                                                   ,[FirebaseUid]
                                                   ,[Username])
                                             VALUES
                                                   (@allyCode
                                                   ,@email
                                                   ,@firebaseUid
                                                   ,@username)";

                var rowsAffected = connection.Execute(sql, newUser);

                return rowsAffected == 1;
            }
        }

        public bool Update(User userToUpdate, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"UPDATE [dbo].[User]
                               SET [AllyCode] = @allyCode
                             WHERE [Id] = @id";
                userToUpdate.Id = id;
                return connection.Execute(sql, userToUpdate) == 1;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"DELETE FROM  [dbo].[User]
                             WHERE [Id] = @id";

                var parameters = new { id };

                return connection.Execute(sql, parameters) == 1;
            }
        }
    }
}
