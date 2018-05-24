
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/24/2018 19:28:46
-- Generated from EDMX file: C:\studia\telemedycyna1\Telemedycyna-develop\ApplicationManager\DatabaseModel\WeightDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WeightDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Weights_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Weights] DROP CONSTRAINT [FK_Weights_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Weights]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Weights];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(50)  NULL,
    [Password] varchar(50)  NULL
);
GO

-- Creating table 'Weights'
CREATE TABLE [dbo].[Weights] (
    [WeightID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [Weight] int  NULL,
    [CreationDate] datetime  NULL,
    [Description] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [WeightID] in table 'Weights'
ALTER TABLE [dbo].[Weights]
ADD CONSTRAINT [PK_Weights]
    PRIMARY KEY CLUSTERED ([WeightID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'Weights'
ALTER TABLE [dbo].[Weights]
ADD CONSTRAINT [FK_Weights_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Weights_Users'
CREATE INDEX [IX_FK_Weights_Users]
ON [dbo].[Weights]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------