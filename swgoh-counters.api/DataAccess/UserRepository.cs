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
        private readonly string _connectionString;

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

        public User GetUserByAllyCode(string allyCode)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"SELECT * FROM [User] WHERE [User].AllyCode = @allyCode";

                var parameters = new
                {
                    allyCode
                };

                var user = connection.QueryFirstOrDefault<User>(sql, parameters);

                return user;
            }
        }

        public User GetUserByFirebaseUid(string firebaseUid)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"SELECT * FROM [User] WHERE [User].FirebaseUid = @firebaseUid";

                var parameters = new
                {
                    firebaseUid
                };

                var user = connection.QueryFirstOrDefault<User>(sql, parameters);

                return user;
            }
        }

        public User GetUserById(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"SELECT * FROM [User] WHERE [User].Id = @id";

                var parameters = new
                {
                    id = Id
                };

                var user = connection.QueryFirstOrDefault<User>(sql, parameters);

                return user;
            }
        }

        public User Create(AddUserCommand newUser)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"INSERT INTO [dbo].[User]
                                             ([Email]
                                             ,[FirebaseUid])
                                         OUTPUT INSERTED.*
                                         VALUES
                                             (@email
                                             ,@firebaseUid)";

                return connection.QueryFirst<User>(sql, newUser);
            }
        }

        public bool Update(UpdateUserCommand userToUpdate, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"UPDATE [dbo].[User]
                               SET [AllyCode] = @allyCode
                                  ,[Username] = @username
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
