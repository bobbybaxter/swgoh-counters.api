using swgoh_counters.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace swgoh_counters.api.Repositories
{
    public class CounterSquadRepository
    {
        string _connectionString = "Server=localhost;Database=SWGOHCounters;Trusted_Connection=True;";

        public List<CounterSquad> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                var counterSquads = connection.Query<CounterSquad>("Select * from CounterSquad");
                
                return counterSquads.AsList();
            }
        }

        public CounterSquad GetCounterSquad(string Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                var sql = @"SELECT * FROM [CounterSquad] WHERE CounterSquad.Id = @CounterSquadId";
                
                var parameters = new
                {
                    CounterSquadId = Id
                };
                
                var counterSquad = connection.QueryFirst<CounterSquad>(sql, parameters);
                
                return counterSquad;
            }
        }

        public bool AddCounterSquad(CounterSquad newCounterSquad)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var addCounterSquad = @"INSERT INTO [dbo].[CounterSquad]
                                                   ([Id]
                                                   ,[Name]
                                                   ,[Type]
                                                   ,[LeaderName]
                                                   ,[Toon2Name]
                                                   ,[Toon3Name]
                                                   ,[Toon4Name]
                                                   ,[Toon5Name]
                                                   ,[Subs]
                                                   ,[Description]
                                                   ,[CounterStrategy]
                                                   ,[IsLeaderRequired]
                                                   ,[IsToon2Required]
                                                   ,[IsToon3Required]
                                                   ,[IsToon4Required]
                                                   ,[IsToon5Required])
                                             VALUES
                                                   (@id
                                                   ,@name
                                                   ,@type
                                                   ,@leaderName
                                                   ,@toon2Name
                                                   ,@toon3Name
                                                   ,@toon4Name
                                                   ,@toon5Name
                                                   ,@subs
                                                   ,@description
                                                   ,@counterStrategy
                                                   ,@isLeaderRequired
                                                   ,@isToon2Required
                                                   ,@isToon3Required
                                                   ,@isToon4Required
                                                   ,@isToon5Required)";

                var parameters = new
                {
                    id = newCounterSquad.Id,
                    name = newCounterSquad.Name,
                    type = newCounterSquad.Type,
                    leaderName = newCounterSquad.LeaderName,
                    toon2Name = newCounterSquad.Toon2Name,
                    toon3Name = newCounterSquad.Toon3Name,
                    toon4Name = newCounterSquad.Toon4Name,
                    toon5Name = newCounterSquad.Toon5Name,
                    subs = newCounterSquad.Subs,
                    description = newCounterSquad.Description,
                    counterStrategy = newCounterSquad.CounterStrategy,
                    isLeaderRequired = newCounterSquad.IsLeaderRequired,
                    isToon2Required = newCounterSquad.IsToon2Required,
                    isToon3Required = newCounterSquad.IsToon3Required,
                    isToon4Required = newCounterSquad.IsToon4Required,
                    isToon5Required = newCounterSquad.IsToon5Required
                };

                var rowsAffected = connection.Execute(addCounterSquad, parameters);
                return rowsAffected == 1;
            }

        }

        public bool UpdateCounterSquad(CounterSquad counterSquadToUpdate, string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"UPDATE [dbo].[CounterSquad]
                               SET [Id] = @id
                                  ,[Name] = @name
                                  ,[Type] = @type
                                  ,[LeaderName] = @leaderName
                                  ,[Toon2Name] = @toon2Name
                                  ,[Toon3Name] = @toon3Name
                                  ,[Toon4Name] = @toon4Name
                                  ,[Toon5Name] = @toon5Name
                                  ,[Subs] = @subs
                                  ,[Description] = @description
                                  ,[CounterStrategy] = @counterStrategy
                                  ,[IsLeaderRequired] = @isLeaderRequired
                                  ,[IsToon2Required] = @isToon2Required
                                  ,[IsToon3Required] = @isToon3Required
                                  ,[IsToon4Required] = @isToon4Required
                                  ,[IsToon5Required] = @isToon5Required
                             WHERE [Id] = @id>";

                counterSquadToUpdate.Id = id;

                return connection.Execute(sql, counterSquadToUpdate) == 1;
            }
        }

        public bool DeleteCounterSquad(CounterSquad counterSquadToDelete, string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"DELETE FROM [dbo].[CounterSquad]
                            WHERE [Id] = @id";

                counterSquadToDelete.Id = id;

                return connection.Execute(sql, counterSquadToDelete) == 1;
            }
        }
    }
}
