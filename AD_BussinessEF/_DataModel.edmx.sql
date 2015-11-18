
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/17/2015 22:25:59
-- Generated from EDMX file: c:\users\jcvpalma\documents\visual studio 2013\Projects\AvaliacaoDesenv\AD_BussinessEF\_DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AD_Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CompradorCompras]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compras] DROP CONSTRAINT [FK_CompradorCompras];
GO
IF OBJECT_ID(N'[dbo].[FK_FornecedorProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Produto] DROP CONSTRAINT [FK_FornecedorProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprasDetalheCompras]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalheComprasSet] DROP CONSTRAINT [FK_ComprasDetalheCompras];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalheComprasProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Produto] DROP CONSTRAINT [FK_DetalheComprasProduto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Comprador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprador];
GO
IF OBJECT_ID(N'[dbo].[Compras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Compras];
GO
IF OBJECT_ID(N'[dbo].[Fornecedor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fornecedor];
GO
IF OBJECT_ID(N'[dbo].[Produto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Produto];
GO
IF OBJECT_ID(N'[dbo].[DetalheComprasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalheComprasSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Comprador'
CREATE TABLE [dbo].[Comprador] (
    [IdCoprador] int IDENTITY(1,1) NOT NULL,
    [NomeComprador] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Compras'
CREATE TABLE [dbo].[Compras] (
    [IdCompra] int IDENTITY(1,1) NOT NULL,
    [CompradorIdCoprador] int  NOT NULL
);
GO

-- Creating table 'Fornecedor'
CREATE TABLE [dbo].[Fornecedor] (
    [IdFornecedor] int IDENTITY(1,1) NOT NULL,
    [NomeFornecedor] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Produto'
CREATE TABLE [dbo].[Produto] (
    [IdProduto] int IDENTITY(1,1) NOT NULL,
    [DescricaoProduto] nvarchar(max)  NOT NULL,
    [FornecedorIdFornecedor] int  NOT NULL,
    [DetalheComprasIdDetalheCompra] int  NOT NULL
);
GO

-- Creating table 'DetalheCompras'
CREATE TABLE [dbo].[DetalheCompras] (
    [IdDetalheCompra] int IDENTITY(1,1) NOT NULL,
    [ComprasIdCompra] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCoprador] in table 'Comprador'
ALTER TABLE [dbo].[Comprador]
ADD CONSTRAINT [PK_Comprador]
    PRIMARY KEY CLUSTERED ([IdCoprador] ASC);
GO

-- Creating primary key on [IdCompra] in table 'Compras'
ALTER TABLE [dbo].[Compras]
ADD CONSTRAINT [PK_Compras]
    PRIMARY KEY CLUSTERED ([IdCompra] ASC);
GO

-- Creating primary key on [IdFornecedor] in table 'Fornecedor'
ALTER TABLE [dbo].[Fornecedor]
ADD CONSTRAINT [PK_Fornecedor]
    PRIMARY KEY CLUSTERED ([IdFornecedor] ASC);
GO

-- Creating primary key on [IdProduto] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [PK_Produto]
    PRIMARY KEY CLUSTERED ([IdProduto] ASC);
GO

-- Creating primary key on [IdDetalheCompra] in table 'DetalheCompras'
ALTER TABLE [dbo].[DetalheCompras]
ADD CONSTRAINT [PK_DetalheCompras]
    PRIMARY KEY CLUSTERED ([IdDetalheCompra] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CompradorIdCoprador] in table 'Compras'
ALTER TABLE [dbo].[Compras]
ADD CONSTRAINT [FK_CompradorCompras]
    FOREIGN KEY ([CompradorIdCoprador])
    REFERENCES [dbo].[Comprador]
        ([IdCoprador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompradorCompras'
CREATE INDEX [IX_FK_CompradorCompras]
ON [dbo].[Compras]
    ([CompradorIdCoprador]);
GO

-- Creating foreign key on [FornecedorIdFornecedor] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [FK_FornecedorProduto]
    FOREIGN KEY ([FornecedorIdFornecedor])
    REFERENCES [dbo].[Fornecedor]
        ([IdFornecedor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FornecedorProduto'
CREATE INDEX [IX_FK_FornecedorProduto]
ON [dbo].[Produto]
    ([FornecedorIdFornecedor]);
GO

-- Creating foreign key on [ComprasIdCompra] in table 'DetalheCompras'
ALTER TABLE [dbo].[DetalheCompras]
ADD CONSTRAINT [FK_ComprasDetalheCompras]
    FOREIGN KEY ([ComprasIdCompra])
    REFERENCES [dbo].[Compras]
        ([IdCompra])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprasDetalheCompras'
CREATE INDEX [IX_FK_ComprasDetalheCompras]
ON [dbo].[DetalheCompras]
    ([ComprasIdCompra]);
GO

-- Creating foreign key on [DetalheComprasIdDetalheCompra] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [FK_DetalheComprasProduto]
    FOREIGN KEY ([DetalheComprasIdDetalheCompra])
    REFERENCES [dbo].[DetalheCompras]
        ([IdDetalheCompra])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalheComprasProduto'
CREATE INDEX [IX_FK_DetalheComprasProduto]
ON [dbo].[Produto]
    ([DetalheComprasIdDetalheCompra]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------