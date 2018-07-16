﻿/*
Deployment script for aspnet-Forum.Web-20180711032047

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "aspnet-Forum.Web-20180711032047"
:setvar DefaultFilePrefix "aspnet-Forum.Web-20180711032047"
:setvar DefaultDataPath "C:\Users\Lusine\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\Lusine\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering [dbo].[Post]...';


GO
ALTER TABLE [dbo].[Post] ALTER COLUMN [UserId] NVARCHAR (128) NOT NULL;


GO
PRINT N'Creating [dbo].[FK_UserId]...';


GO
ALTER TABLE [dbo].[Post] WITH NOCHECK
    ADD CONSTRAINT [FK_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Post] WITH CHECK CHECK CONSTRAINT [FK_UserId];


GO
PRINT N'Update complete.';


GO
