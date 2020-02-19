IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Carros] (
    [Id] uniqueidentifier NOT NULL,
    [Modelo] varchar(50) NOT NULL,
    [Placa] varchar(7) NOT NULL,
    [Marca] varchar(50) NOT NULL,
    CONSTRAINT [PK_Carros] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Manobristas] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Cpf] varchar(11) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    CONSTRAINT [PK_Manobristas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ResponsaveisManobras] (
    [Id] uniqueidentifier NOT NULL,
    [ManobristaId] uniqueidentifier NOT NULL,
    [CarroId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ResponsaveisManobras] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ResponsaveisManobras_Carros_CarroId] FOREIGN KEY ([CarroId]) REFERENCES [Carros] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ResponsaveisManobras_Manobristas_ManobristaId] FOREIGN KEY ([ManobristaId]) REFERENCES [Manobristas] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_ResponsaveisManobras_CarroId] ON [ResponsaveisManobras] ([CarroId]);

GO

CREATE INDEX [IX_ResponsaveisManobras_ManobristaId] ON [ResponsaveisManobras] ([ManobristaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200218160354_Inicial', N'2.2.6-servicing-10079');

GO

