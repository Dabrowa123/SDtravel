
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/28/2017 15:03:38
-- Generated from EDMX file: C:\Users\Szymon\Documents\Visual Studio 2015\Projects\Travel\Models\TravelModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TravelDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SitePictures]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pictures1] DROP CONSTRAINT [FK_SitePictures];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Sites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sites];
GO
IF OBJECT_ID(N'[dbo].[Pictures1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pictures1];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Sites'
CREATE TABLE [dbo].[Sites] (
    [SiteId] int IDENTITY(1,1) NOT NULL,
    [SiteName] nvarchar(max)  NOT NULL,
    [SiteLocation] nvarchar(max)  NOT NULL,
    [SiteDestination] nvarchar(max)  NOT NULL,
    [SiteDescription] nvarchar(max)  NOT NULL,
    [SiteAvatar] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pictures1'
CREATE TABLE [dbo].[Pictures1] (
    [PictureId] int IDENTITY(1,1) NOT NULL,
    [PicturesURL] nvarchar(max)  NOT NULL,
    [Site_SiteId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [SiteId] in table 'Sites'
ALTER TABLE [dbo].[Sites]
ADD CONSTRAINT [PK_Sites]
    PRIMARY KEY CLUSTERED ([SiteId] ASC);
GO

-- Creating primary key on [PictureId] in table 'Pictures1'
ALTER TABLE [dbo].[Pictures1]
ADD CONSTRAINT [PK_Pictures1]
    PRIMARY KEY CLUSTERED ([PictureId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Site_SiteId] in table 'Pictures1'
ALTER TABLE [dbo].[Pictures1]
ADD CONSTRAINT [FK_SitePictures]
    FOREIGN KEY ([Site_SiteId])
    REFERENCES [dbo].[Sites]
        ([SiteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SitePictures'
CREATE INDEX [IX_FK_SitePictures]
ON [dbo].[Pictures1]
    ([Site_SiteId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------