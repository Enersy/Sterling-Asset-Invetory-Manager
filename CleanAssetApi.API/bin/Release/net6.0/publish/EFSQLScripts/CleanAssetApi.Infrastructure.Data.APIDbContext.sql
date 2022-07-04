IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE TABLE [AssetInfo] (
        [Id] uniqueidentifier NOT NULL,
        [SerialNumber] nvarchar(max) NOT NULL,
        [ModelName] nvarchar(max) NOT NULL,
        [ModelNumber] nvarchar(max) NOT NULL,
        [AssetNumber] nvarchar(max) NOT NULL,
        [Brand] nvarchar(max) NOT NULL,
        [Remark] nvarchar(max) NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [underwarranty] nvarchar(max) NOT NULL,
        [YearOfManufacture] datetime2 NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_AssetInfo] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE TABLE [BranchLocations] (
        [Id] uniqueidentifier NOT NULL,
        [Region] nvarchar(max) NOT NULL,
        [Branch] nvarchar(max) NOT NULL,
        [StreetNumber] nvarchar(max) NOT NULL,
        [StreetName] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_BranchLocations] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE TABLE [CpuMonitorInfos] (
        [Id] uniqueidentifier NOT NULL,
        [SerialNumber] nvarchar(max) NOT NULL,
        [AssetTag] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_CpuMonitorInfos] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE TABLE [AssetCustodians] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Department] nvarchar(max) NOT NULL,
        [LocationId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AssetCustodians] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AssetCustodians_BranchLocations_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [BranchLocations] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE TABLE [Desktops] (
        [Id] uniqueidentifier NOT NULL,
        [CpuMonitorInfoId] uniqueidentifier NOT NULL,
        [HostName] nvarchar(max) NOT NULL,
        [CustodianId] uniqueidentifier NOT NULL,
        [AssetInfoId] uniqueidentifier NOT NULL,
        [RamSize] int NOT NULL,
        [SupportOfficer] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Desktops] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Desktops_AssetCustodians_CustodianId] FOREIGN KEY ([CustodianId]) REFERENCES [AssetCustodians] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Desktops_AssetInfo_AssetInfoId] FOREIGN KEY ([AssetInfoId]) REFERENCES [AssetInfo] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Desktops_CpuMonitorInfos_CpuMonitorInfoId] FOREIGN KEY ([CpuMonitorInfoId]) REFERENCES [CpuMonitorInfos] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE TABLE [Laptops] (
        [Id] uniqueidentifier NOT NULL,
        [HostName] nvarchar(max) NOT NULL,
        [CustodianId] uniqueidentifier NOT NULL,
        [AssetInfoId] uniqueidentifier NOT NULL,
        [RamSize] int NOT NULL,
        [SupportOfficer] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Laptops] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Laptops_AssetCustodians_CustodianId] FOREIGN KEY ([CustodianId]) REFERENCES [AssetCustodians] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Laptops_AssetInfo_AssetInfoId] FOREIGN KEY ([AssetInfoId]) REFERENCES [AssetInfo] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE INDEX [IX_AssetCustodians_LocationId] ON [AssetCustodians] ([LocationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE INDEX [IX_Desktops_AssetInfoId] ON [Desktops] ([AssetInfoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE INDEX [IX_Desktops_CpuMonitorInfoId] ON [Desktops] ([CpuMonitorInfoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE INDEX [IX_Desktops_CustodianId] ON [Desktops] ([CustodianId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE INDEX [IX_Laptops_AssetInfoId] ON [Laptops] ([AssetInfoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    CREATE INDEX [IX_Laptops_CustodianId] ON [Laptops] ([CustodianId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220519142255_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220519142255_InitialMigration', N'6.0.5');
END;
GO

COMMIT;
GO

