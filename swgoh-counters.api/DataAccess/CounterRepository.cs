using Dapper;
using swgoh_counters.api.Commands;
using swgoh_counters.api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace swgoh_counters.api.DataAccess
{
    public class CounterRepository
    {
        string _connectionString = "Server=localhost;Database=SWGOHCounters;Trusted_Connection=True;";

        public List<Counter> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var counters = connection.Query<Counter>("Select * from Counter");

                return counters.AsList();
            }
        }

        public Counter Get(string Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"SELECT * FROM [Counter] WHERE Counter.Id = @CounterId";

                var parameters = new
                {
                    CounterId = Id
                };

                var counter = connection.QueryFirst<Counter>(sql, parameters);

                return counter;
            }
        }

        public bool Create(AddCounterCommand newCounter)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var addCounter = @"INSERT INTO [dbo].[Counter]
                                                   ([Id]
                                                   ,[OpponentTeamId]
                                                   ,[CounterTeamId]
                                                   ,[IsHardCounter]
                                                   ,[BattleType]
                                                   ,[Description]
                                                   ,[VideoUrl])
                                             VALUES
                                                   (@id
                                                   ,@opponentTeamId
                                                   ,@counterTeamId
                                                   ,@isHardCounter
                                                   ,@battleType
                                                   ,@description
                                                   ,@videoUrl)";

                var parameters = new
                {
                    id = $"{newCounter.OpponentTeamId}-v-{newCounter.CounterTeamId}",
                    opponentTeamId = newCounter.OpponentTeamId,
                    counterTeamId = newCounter.CounterTeamId,
                    isHardCounter = newCounter.IsHardCounter,
                    battleType = newCounter.BattleType,
                    description = newCounter.Description,
                    videoUrl = newCounter.VideoUrl
                };

                var rowsAffected = connection.Execute(addCounter, parameters);

                return rowsAffected == 1;
            }

        }

        public bool Update(AddCounterCommand counterToUpdate, string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"UPDATE [dbo].[Counter]
                               SET [Id] = @newId
                                  ,[OpponentTeamId] = @opponentTeamId
                                  ,[CounterTeamId] = @counterTeamId
                                  ,[IsHardCounter] = @isHardCounter
                                  ,[BattleType] = @battleType
                                  ,[Description] = @description
                                  ,[VideoUrl] = @videoUrl
                             WHERE [Id] = @id";

                var parameters = new
                {
                    id,
                    newId = $"{counterToUpdate.OpponentTeamId}-v-{counterToUpdate.CounterTeamId}",
                    opponentTeamId = counterToUpdate.OpponentTeamId,
                    counterTeamId = counterToUpdate.CounterTeamId,
                    isHardCounter = counterToUpdate.IsHardCounter,
                    battleType = counterToUpdate.BattleType,
                    description = counterToUpdate.Description,
                    videoUrl = counterToUpdate.VideoUrl
                };

                return connection.Execute(sql, parameters) == 1;
            }
        }

        public bool Delete(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"DELETE FROM [dbo].[Counter]
                            WHERE [Id] = @id";

                var parameters = new { id };

                return connection.Execute(sql, parameters) == 1;
            }
        }
    }
}
