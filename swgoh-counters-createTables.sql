CREATE TABLE [CounterSquad] (
  [Id] NVARCHAR(255) PRIMARY KEY,
  [Name] NVARCHAR(255),
  [Type] NVARCHAR(50),
  [LeaderName] NVARCHAR(255),
  [Toon2Name] NVARCHAR(255),
  [Toon3Name] NVARCHAR(255),
  [Toon4Name] NVARCHAR(255),
  [Toon5Name] NVARCHAR(255),
  [Subs] NVARCHAR(500),
  [Description] NVARCHAR(1000),
  [CounterStrategy] NVARCHAR(1000),
  [IsLeaderRequired] BIT,
  [IsToon2Required] BIT,
  [IsToon3Required] BIT,
  [IsToon4Required] BIT,
  [IsToon5Required] BIT
)
GO

CREATE TABLE [Counter] (
  [Id] NVARCHAR(255) PRIMARY KEY,
  [OpponentTeamId] NVARCHAR(255),
  [CounterTeamId] NVARCHAR(255),
  [IsHardCounter] BIT,
  [BattleType] NVARCHAR(50),
  [Description] NVARCHAR(1000),
  [VideoUrl] NVARCHAR(255)
)
GO

CREATE TABLE [User] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [Username] NVARCHAR(50),
  [FirebaseUid] NVARCHAR(255),
  [AllyCode] NVARCHAR(9)
)
GO

ALTER TABLE [Counter] ADD FOREIGN KEY ([OpponentTeamId]) REFERENCES [CounterSquad] ([Id])
GO

ALTER TABLE [Counter] ADD FOREIGN KEY ([CounterTeamId]) REFERENCES [CounterSquad] ([Id])
GO
