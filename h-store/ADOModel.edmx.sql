
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2015 10:52:51
-- Generated from EDMX file: C:\Users\apurva.jalit\work\h-store\h-store\ADOModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [h-store];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AnnotationUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Annotations] DROP CONSTRAINT [FK_AnnotationUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Annotations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Annotations];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Annotations'
CREATE TABLE [dbo].[Annotations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [updated] nvarchar(max)  NOT NULL,
    [target] nvarchar(max)  NOT NULL,
    [created] nvarchar(max)  NOT NULL,
    [text] nvarchar(max)  NULL,
    [tags] nvarchar(max)  NULL,
    [uri] nvarchar(max)  NOT NULL,
    [document] nvarchar(max)  NOT NULL,
    [consumer] nvarchar(max)  NOT NULL,
    [permissions] nvarchar(max)  NOT NULL,
    [user] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [subscriptions] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Annotations'
ALTER TABLE [dbo].[Annotations]
ADD CONSTRAINT [PK_Annotations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Annotations'
ALTER TABLE [dbo].[Annotations]
ADD CONSTRAINT [FK_AnnotationUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnnotationUser'
CREATE INDEX [IX_FK_AnnotationUser]
ON [dbo].[Annotations]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------