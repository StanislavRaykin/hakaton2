IF DB_ID(N'Hakaton') IS NULL
BEGIN
    PRINT 'Creating database [Hakaton]...';
    CREATE DATABASE [Hakaton];
END
GO

USE [Hakaton];
GO

-- WARNING: this script will DROP the tables if they exist — ALL DATA WILL BE LOST.
-- Make a backup first if you need to preserve data:
-- BACKUP DATABASE [Hakaton] TO DISK = N'C:\Backups\Hakaton.bak' WITH INIT;
-- (Run the BACKUP command in SSMS or your preferred tooling prior to executing this script.)

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- Drop dependent objects safely (if you have FKs, drop them first).
-- Here we simply drop the tables if they exist.
IF OBJECT_ID(N'dbo.[User]', N'U') IS NOT NULL
BEGIN
    PRINT 'Dropping table [dbo].[User]...';
    DROP TABLE dbo.[User];
END
GO

IF OBJECT_ID(N'dbo.[Event]', N'U') IS NOT NULL
BEGIN
    PRINT 'Dropping table [dbo].[Event]...';
    DROP TABLE dbo.[Event];
END
GO

-- Recreate [dbo].[User]
PRINT 'Creating table [dbo].[User]...';
CREATE TABLE [dbo].[User](
    [UserID] [int] IDENTITY(1,1) NOT NULL,
    [Username] [nvarchar](20) NULL,
    [Email] [nvarchar](50) NULL,
    [Points] [int] NULL,
    [Role] [int] NULL,
    [Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
    [UserID] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) 
ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
GO

-- Recreate [dbo].[Event]
PRINT 'Creating table [dbo].[Event]...';
CREATE TABLE [dbo].[Event](
    [EventId] [int] IDENTITY(1,1) NOT NULL,
    [Title] [nvarchar](50) NULL,
    [Description] [nvarchar](255) NULL,
    [Start] [datetime] NULL,
    [End] [datetime] NULL,
    [MaxParticipants] [int] NULL,
    [CurrentParticipants] [int] NULL,
    [CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
    [EventId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
       ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) 
ON [PRIMARY]
) ON [PRIMARY];
GO

PRINT 'Tables re-created successfully.';        