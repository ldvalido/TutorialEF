
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/02/2016 12:13:00
-- Generated from EDMX file: C:\projects\TutorialEF\EFCFBanco\Mapping\BancoModelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TutorialEF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClienteCuenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_ClienteCuenta];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Cuentas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuentas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [ClienteId] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Cuentas'
CREATE TABLE [dbo].[Cuentas] (
    [CuentaId] int IDENTITY(1,1) NOT NULL,
    [CBU] nvarchar(max)  NOT NULL,
    [Saldo] nvarchar(max)  NOT NULL,
    [ClienteID] int  NOT NULL
);
GO

-- Creating table 'ClienteCuenta'
CREATE TABLE [dbo].[ClienteCuenta] (
    [Cliente_ClienteId] int  NOT NULL,
    [Cuenta_CuentaId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ClienteId] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([ClienteId] ASC);
GO

-- Creating primary key on [CuentaId] in table 'Cuentas'
ALTER TABLE [dbo].[Cuentas]
ADD CONSTRAINT [PK_Cuentas]
    PRIMARY KEY CLUSTERED ([CuentaId] ASC);
GO

-- Creating primary key on [Cliente_ClienteId], [Cuenta_CuentaId] in table 'ClienteCuenta'
ALTER TABLE [dbo].[ClienteCuenta]
ADD CONSTRAINT [PK_ClienteCuenta]
    PRIMARY KEY CLUSTERED ([Cliente_ClienteId], [Cuenta_CuentaId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Cliente_ClienteId] in table 'ClienteCuenta'
ALTER TABLE [dbo].[ClienteCuenta]
ADD CONSTRAINT [FK_ClienteCuenta_Cliente]
    FOREIGN KEY ([Cliente_ClienteId])
    REFERENCES [dbo].[Clientes]
        ([ClienteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Cuenta_CuentaId] in table 'ClienteCuenta'
ALTER TABLE [dbo].[ClienteCuenta]
ADD CONSTRAINT [FK_ClienteCuenta_Cuenta]
    FOREIGN KEY ([Cuenta_CuentaId])
    REFERENCES [dbo].[Cuentas]
        ([CuentaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteCuenta_Cuenta'
CREATE INDEX [IX_FK_ClienteCuenta_Cuenta]
ON [dbo].[ClienteCuenta]
    ([Cuenta_CuentaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------