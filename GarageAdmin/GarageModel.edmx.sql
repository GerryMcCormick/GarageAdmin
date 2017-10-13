
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/12/2017 10:20:56
-- Generated from EDMX file: C:\Users\gerry\Documents\Magee\Year 4\Enterprise Computing\Assignments\Assignment 1\GarageAdmin\GarageAdmin\GarageModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GarageAdmin];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CarCarOwner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_CarCarOwner];
GO
IF OBJECT_ID(N'[dbo].[FK_CarService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_CarService];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceMechanic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_ServiceMechanic];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceServicePart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceParts] DROP CONSTRAINT [FK_ServiceServicePart];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invoices] DROP CONSTRAINT [FK_ServiceInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_PartServicePart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceParts] DROP CONSTRAINT [FK_PartServicePart];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[CarOwners]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarOwners];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO
IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invoices];
GO
IF OBJECT_ID(N'[dbo].[ServiceParts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceParts];
GO
IF OBJECT_ID(N'[dbo].[Mechanics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mechanics];
GO
IF OBJECT_ID(N'[dbo].[Parts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RegNumber] nvarchar(10)  NOT NULL,
    [Make] nvarchar(15)  NOT NULL,
    [Model] nvarchar(15)  NOT NULL,
    [CarOwnerId] int  NOT NULL
);
GO

-- Creating table 'CarOwners'
CREATE TABLE [dbo].[CarOwners] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TelNumber] nvarchar(17)  NOT NULL,
    [Address] nvarchar(50)  NOT NULL,
    [PostCode] nvarchar(8)  NOT NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateServiced] datetime  NOT NULL,
    [DurationInHours] float  NOT NULL,
    [CarId] int  NOT NULL,
    [MechanicId] int  NOT NULL
);
GO

-- Creating table 'Invoices'
CREATE TABLE [dbo].[Invoices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateIssued] datetime  NOT NULL,
    [Paid] bit  NOT NULL,
    [OverDue] bit  NOT NULL,
    [ReceivedPaymentOn] datetime  NOT NULL,
    [ServiceId] int  NOT NULL
);
GO

-- Creating table 'ServiceParts'
CREATE TABLE [dbo].[ServiceParts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [ServiceId] int  NOT NULL,
    [PartId] int  NOT NULL
);
GO

-- Creating table 'Mechanics'
CREATE TABLE [dbo].[Mechanics] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Forename] nvarchar(15)  NOT NULL,
    [Surname] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'Parts'
CREATE TABLE [dbo].[Parts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SupplierPartNumber] nvarchar(18)  NOT NULL,
    [PartName] nvarchar(20)  NOT NULL,
    [Brand] nvarchar(15)  NOT NULL,
    [Price] float  NOT NULL,
    [NoInStock] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CarOwners'
ALTER TABLE [dbo].[CarOwners]
ADD CONSTRAINT [PK_CarOwners]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [PK_Invoices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceParts'
ALTER TABLE [dbo].[ServiceParts]
ADD CONSTRAINT [PK_ServiceParts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Mechanics'
ALTER TABLE [dbo].[Mechanics]
ADD CONSTRAINT [PK_Mechanics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Parts'
ALTER TABLE [dbo].[Parts]
ADD CONSTRAINT [PK_Parts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarOwnerId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_CarCarOwner]
    FOREIGN KEY ([CarOwnerId])
    REFERENCES [dbo].[CarOwners]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarCarOwner'
CREATE INDEX [IX_FK_CarCarOwner]
ON [dbo].[Cars]
    ([CarOwnerId]);
GO

-- Creating foreign key on [CarId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_CarService]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarService'
CREATE INDEX [IX_FK_CarService]
ON [dbo].[Services]
    ([CarId]);
GO

-- Creating foreign key on [MechanicId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_ServiceMechanic]
    FOREIGN KEY ([MechanicId])
    REFERENCES [dbo].[Mechanics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceMechanic'
CREATE INDEX [IX_FK_ServiceMechanic]
ON [dbo].[Services]
    ([MechanicId]);
GO

-- Creating foreign key on [ServiceId] in table 'ServiceParts'
ALTER TABLE [dbo].[ServiceParts]
ADD CONSTRAINT [FK_ServiceServicePart]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceServicePart'
CREATE INDEX [IX_FK_ServiceServicePart]
ON [dbo].[ServiceParts]
    ([ServiceId]);
GO

-- Creating foreign key on [ServiceId] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [FK_ServiceInvoice]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceInvoice'
CREATE INDEX [IX_FK_ServiceInvoice]
ON [dbo].[Invoices]
    ([ServiceId]);
GO

-- Creating foreign key on [PartId] in table 'ServiceParts'
ALTER TABLE [dbo].[ServiceParts]
ADD CONSTRAINT [FK_PartServicePart]
    FOREIGN KEY ([PartId])
    REFERENCES [dbo].[Parts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PartServicePart'
CREATE INDEX [IX_FK_PartServicePart]
ON [dbo].[ServiceParts]
    ([PartId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------