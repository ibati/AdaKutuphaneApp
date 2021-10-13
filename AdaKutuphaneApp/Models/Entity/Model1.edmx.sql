
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/13/2021 22:35:09
-- Generated from EDMX file: C:\Users\ibrahim.bati\source\repos\AdaKutuphaneApp\AdaKutuphaneApp\Models\Entity\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AdaKutuphane];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tblCezalar_tblHareketler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCezalar] DROP CONSTRAINT [FK_tblCezalar_tblHareketler];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCezalar_tblUyeler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCezalar] DROP CONSTRAINT [FK_tblCezalar_tblUyeler];
GO
IF OBJECT_ID(N'[dbo].[FK_tblHareketler_Personeller]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHareketler] DROP CONSTRAINT [FK_tblHareketler_Personeller];
GO
IF OBJECT_ID(N'[dbo].[FK_tblHareketler_tblKitaplar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHareketler] DROP CONSTRAINT [FK_tblHareketler_tblKitaplar];
GO
IF OBJECT_ID(N'[dbo].[FK_tblHareketler_tblUyeler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHareketler] DROP CONSTRAINT [FK_tblHareketler_tblUyeler];
GO
IF OBJECT_ID(N'[dbo].[FK_tblKitaplar_tblKategoriler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKitaplar] DROP CONSTRAINT [FK_tblKitaplar_tblKategoriler];
GO
IF OBJECT_ID(N'[dbo].[FK_tblKitaplar_tblYazarlar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblKitaplar] DROP CONSTRAINT [FK_tblKitaplar_tblYazarlar];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tblCezalar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCezalar];
GO
IF OBJECT_ID(N'[dbo].[tblHareketler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblHareketler];
GO
IF OBJECT_ID(N'[dbo].[tblKasa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblKasa];
GO
IF OBJECT_ID(N'[dbo].[tblKategoriler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblKategoriler];
GO
IF OBJECT_ID(N'[dbo].[tblKitaplar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblKitaplar];
GO
IF OBJECT_ID(N'[dbo].[tblPersoneller]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPersoneller];
GO
IF OBJECT_ID(N'[dbo].[tblUyeler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUyeler];
GO
IF OBJECT_ID(N'[dbo].[tblYazarlar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblYazarlar];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'tblCezalar'
CREATE TABLE [dbo].[tblCezalar] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UYE] int  NULL,
    [HAREKET] int  NULL,
    [BASLANGIC] datetime  NULL,
    [BITIS] datetime  NULL,
    [CEZA] decimal(18,2)  NULL
);
GO

-- Creating table 'tblHareketler'
CREATE TABLE [dbo].[tblHareketler] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [KITAP] int  NULL,
    [UYE] int  NULL,
    [PERSONEL] int  NULL,
    [ALISTARIH] datetime  NULL,
    [IADETARIH] datetime  NULL
);
GO

-- Creating table 'tblKasa'
CREATE TABLE [dbo].[tblKasa] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AY] varchar(20)  NULL,
    [TUTAR] decimal(18,2)  NULL
);
GO

-- Creating table 'tblKategoriler'
CREATE TABLE [dbo].[tblKategoriler] (
    [ID] tinyint IDENTITY(1,1) NOT NULL,
    [AD] varchar(50)  NULL
);
GO

-- Creating table 'tblKitaplar'
CREATE TABLE [dbo].[tblKitaplar] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AD] varchar(50)  NULL,
    [KATEGORI] tinyint  NULL,
    [YAZAR] int  NULL,
    [BASIMYILI] char(4)  NULL,
    [YAYINEVİ] varchar(50)  NULL,
    [SAYFASAYISI] varchar(5)  NULL,
    [DURUM] bit  NULL
);
GO

-- Creating table 'tblPersoneller'
CREATE TABLE [dbo].[tblPersoneller] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AD] varchar(50)  NULL,
    [SOYAD] varchar(50)  NULL
);
GO

-- Creating table 'tblUyeler'
CREATE TABLE [dbo].[tblUyeler] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AD] varchar(50)  NULL,
    [SOYAD] varchar(50)  NULL,
    [MAIL] varchar(50)  NULL,
    [KULLANICIADI] varchar(50)  NULL,
    [PAROLA] varchar(50)  NULL,
    [FOTOGRAF] varchar(250)  NULL,
    [TELEFON] varchar(50)  NULL
);
GO

-- Creating table 'tblYazarlar'
CREATE TABLE [dbo].[tblYazarlar] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AD] varchar(50)  NULL,
    [SOYAD] varchar(50)  NULL,
    [DETAY] varchar(1000)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'tblCezalar'
ALTER TABLE [dbo].[tblCezalar]
ADD CONSTRAINT [PK_tblCezalar]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblHareketler'
ALTER TABLE [dbo].[tblHareketler]
ADD CONSTRAINT [PK_tblHareketler]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblKasa'
ALTER TABLE [dbo].[tblKasa]
ADD CONSTRAINT [PK_tblKasa]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblKategoriler'
ALTER TABLE [dbo].[tblKategoriler]
ADD CONSTRAINT [PK_tblKategoriler]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblKitaplar'
ALTER TABLE [dbo].[tblKitaplar]
ADD CONSTRAINT [PK_tblKitaplar]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblPersoneller'
ALTER TABLE [dbo].[tblPersoneller]
ADD CONSTRAINT [PK_tblPersoneller]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblUyeler'
ALTER TABLE [dbo].[tblUyeler]
ADD CONSTRAINT [PK_tblUyeler]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblYazarlar'
ALTER TABLE [dbo].[tblYazarlar]
ADD CONSTRAINT [PK_tblYazarlar]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HAREKET] in table 'tblCezalar'
ALTER TABLE [dbo].[tblCezalar]
ADD CONSTRAINT [FK_tblCezalar_tblHareketler]
    FOREIGN KEY ([HAREKET])
    REFERENCES [dbo].[tblHareketler]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCezalar_tblHareketler'
CREATE INDEX [IX_FK_tblCezalar_tblHareketler]
ON [dbo].[tblCezalar]
    ([HAREKET]);
GO

-- Creating foreign key on [UYE] in table 'tblCezalar'
ALTER TABLE [dbo].[tblCezalar]
ADD CONSTRAINT [FK_tblCezalar_tblUyeler]
    FOREIGN KEY ([UYE])
    REFERENCES [dbo].[tblUyeler]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCezalar_tblUyeler'
CREATE INDEX [IX_FK_tblCezalar_tblUyeler]
ON [dbo].[tblCezalar]
    ([UYE]);
GO

-- Creating foreign key on [PERSONEL] in table 'tblHareketler'
ALTER TABLE [dbo].[tblHareketler]
ADD CONSTRAINT [FK_tblHareketler_Personeller]
    FOREIGN KEY ([PERSONEL])
    REFERENCES [dbo].[tblPersoneller]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblHareketler_Personeller'
CREATE INDEX [IX_FK_tblHareketler_Personeller]
ON [dbo].[tblHareketler]
    ([PERSONEL]);
GO

-- Creating foreign key on [KITAP] in table 'tblHareketler'
ALTER TABLE [dbo].[tblHareketler]
ADD CONSTRAINT [FK_tblHareketler_tblKitaplar]
    FOREIGN KEY ([KITAP])
    REFERENCES [dbo].[tblKitaplar]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblHareketler_tblKitaplar'
CREATE INDEX [IX_FK_tblHareketler_tblKitaplar]
ON [dbo].[tblHareketler]
    ([KITAP]);
GO

-- Creating foreign key on [UYE] in table 'tblHareketler'
ALTER TABLE [dbo].[tblHareketler]
ADD CONSTRAINT [FK_tblHareketler_tblUyeler]
    FOREIGN KEY ([UYE])
    REFERENCES [dbo].[tblUyeler]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblHareketler_tblUyeler'
CREATE INDEX [IX_FK_tblHareketler_tblUyeler]
ON [dbo].[tblHareketler]
    ([UYE]);
GO

-- Creating foreign key on [KATEGORI] in table 'tblKitaplar'
ALTER TABLE [dbo].[tblKitaplar]
ADD CONSTRAINT [FK_tblKitaplar_tblKategoriler]
    FOREIGN KEY ([KATEGORI])
    REFERENCES [dbo].[tblKategoriler]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblKitaplar_tblKategoriler'
CREATE INDEX [IX_FK_tblKitaplar_tblKategoriler]
ON [dbo].[tblKitaplar]
    ([KATEGORI]);
GO

-- Creating foreign key on [YAZAR] in table 'tblKitaplar'
ALTER TABLE [dbo].[tblKitaplar]
ADD CONSTRAINT [FK_tblKitaplar_tblYazarlar]
    FOREIGN KEY ([YAZAR])
    REFERENCES [dbo].[tblYazarlar]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblKitaplar_tblYazarlar'
CREATE INDEX [IX_FK_tblKitaplar_tblYazarlar]
ON [dbo].[tblKitaplar]
    ([YAZAR]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------