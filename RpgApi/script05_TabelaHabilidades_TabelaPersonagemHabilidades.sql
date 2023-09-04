BEGIN TRANSACTION;
GO

ALTER TABLE [Personagens] ADD [Derrotas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Disputas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Vitorias] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Habilidades] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Habilidades] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PersonagemHabilidades] (
    [PersonagemId] int NOT NULL,
    [HabilidadeId] int NOT NULL,
    CONSTRAINT [PK_PersonagemHabilidades] PRIMARY KEY ([PersonagemId], [HabilidadeId]),
    CONSTRAINT [FK_PersonagemHabilidades_Habilidades_HabilidadeId] FOREIGN KEY ([HabilidadeId]) REFERENCES [Habilidades] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonagemHabilidades_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] ON;
INSERT INTO [Habilidades] ([Id], [Dano], [Nome])
VALUES (1, 39, N'Adormecer'),
(2, 41, N'Congelar'),
(3, 37, N'Hipnotizar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] OFF;
GO

UPDATE [Personagens] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Derrotas] = 0, [Disputas] = 0, [Vitorias] = 0
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [PasswordHash] = 0xC2CADA86152D266C0DF5F076023E2D192B93C789B852E069671170F09D855DE3B697E8C3E8D4E2AD3F76AEAEE99F2166283938BE8A4DC46F00DA23C78A7CDA64, [PasswordSalt] = 0xAF39F0F2657F7D41783EBF35E3FF93BC19A1206908570E7080D81BCDAA14E21DF79A58FE7926158B5902126E76C9DA612E6EC6ADD74046DE0F615FB2320081D4836A6463251F723FB8CDF28F75228EB8FD3E41049FD0C89F0054106D7C804C5C00F03313BA62CBC0ECFC33B59CE8952AA161980224C1962C729F384BB7B70D82
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] ON;
INSERT INTO [PersonagemHabilidades] ([HabilidadeId], [PersonagemId])
VALUES (1, 1),
(2, 1),
(2, 2),
(2, 3),
(3, 3),
(3, 4),
(1, 5),
(2, 6),
(3, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] OFF;
GO

CREATE INDEX [IX_PersonagemHabilidades_HabilidadeId] ON [PersonagemHabilidades] ([HabilidadeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230730172829_MigracaoMuitosParaMuitos', N'7.0.4');
GO

COMMIT;
GO

