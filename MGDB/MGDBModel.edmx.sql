
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/23/2018 18:11:37
-- Generated from EDMX file: C:\Users\Alex\SkyDrive\ШАГ\Программирование\Курсовые проекты\C#\MGDB\MGDB\MGDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MGDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MainJournalCustomersList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomersListSet] DROP CONSTRAINT [FK_MainJournalCustomersList];
GO
IF OBJECT_ID(N'[dbo].[FK_MainJournalMVZList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MVZListSet] DROP CONSTRAINT [FK_MainJournalMVZList];
GO
IF OBJECT_ID(N'[dbo].[FK_MainJournalTypeOfResearch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TypeOfResearchSet] DROP CONSTRAINT [FK_MainJournalTypeOfResearch];
GO
IF OBJECT_ID(N'[dbo].[FK_MainJournalListOfEngineers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListOfEngineersSet] DROP CONSTRAINT [FK_MainJournalListOfEngineers];
GO
IF OBJECT_ID(N'[dbo].[FK_MainJournalDataJournal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MainJournalSet] DROP CONSTRAINT [FK_MainJournalDataJournal];
GO
IF OBJECT_ID(N'[dbo].[FK_SamplePrepJournalListOfEngineers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListOfEngineersSet] DROP CONSTRAINT [FK_SamplePrepJournalListOfEngineers];
GO
IF OBJECT_ID(N'[dbo].[FK_SamplePrepJournalCustomersList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomersListSet] DROP CONSTRAINT [FK_SamplePrepJournalCustomersList];
GO
IF OBJECT_ID(N'[dbo].[FK_SampleMakingJournalListOfEngineers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListOfEngineersSet] DROP CONSTRAINT [FK_SampleMakingJournalListOfEngineers];
GO
IF OBJECT_ID(N'[dbo].[FK_SampleMakingJournalCustomers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomersListSet] DROP CONSTRAINT [FK_SampleMakingJournalCustomers];
GO
IF OBJECT_ID(N'[dbo].[FK_ChemistryJournalListOfEngineers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListOfEngineersSet] DROP CONSTRAINT [FK_ChemistryJournalListOfEngineers];
GO
IF OBJECT_ID(N'[dbo].[FK_ChemistryJournalCustomersList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomersListSet] DROP CONSTRAINT [FK_ChemistryJournalCustomersList];
GO
IF OBJECT_ID(N'[dbo].[FK_ChemistryJournalMVZList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MVZListSet] DROP CONSTRAINT [FK_ChemistryJournalMVZList];
GO
IF OBJECT_ID(N'[dbo].[FK_SamplePrepJournalMVZList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MVZListSet] DROP CONSTRAINT [FK_SamplePrepJournalMVZList];
GO
IF OBJECT_ID(N'[dbo].[FK_SampleMakingJournalMVZList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MVZListSet] DROP CONSTRAINT [FK_SampleMakingJournalMVZList];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MainJournalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MainJournalSet];
GO
IF OBJECT_ID(N'[dbo].[ListOfEngineersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListOfEngineersSet];
GO
IF OBJECT_ID(N'[dbo].[CustomersListSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomersListSet];
GO
IF OBJECT_ID(N'[dbo].[SamplePrepJournalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SamplePrepJournalSet];
GO
IF OBJECT_ID(N'[dbo].[SampleMakingJournalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SampleMakingJournalSet];
GO
IF OBJECT_ID(N'[dbo].[MVZListSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MVZListSet];
GO
IF OBJECT_ID(N'[dbo].[ChemistryJournalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChemistryJournalSet];
GO
IF OBJECT_ID(N'[dbo].[TypeOfResearchSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeOfResearchSet];
GO
IF OBJECT_ID(N'[dbo].[DataJournalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DataJournalSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MainJournalSet'
CREATE TABLE [dbo].[MainJournalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] nchar(4000)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [NumberOfSamples] smallint  NOT NULL,
    [Notation] nvarchar(max)  NULL,
    [Status] int  NOT NULL,
    [StatusDescription] nvarchar(max)  NULL,
    [ResearchResults] nvarchar(max)  NULL,
    [TypeOfDefect] int  NULL,
    [FinishDate] datetime  NOT NULL,
    [Document1] varbinary(max)  NULL,
    [Document2] varbinary(max)  NULL,
    [Document3] varbinary(max)  NULL,
    [ResearchData_Id] int  NOT NULL
);
GO

-- Creating table 'ListOfEngineersSet'
CREATE TABLE [dbo].[ListOfEngineersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [SampleMakingJournalId] int  NOT NULL,
    [SamplePrepJournalId] int  NOT NULL,
    [ChemistryJournalId] int  NOT NULL,
    [MainJournalId] int  NOT NULL
);
GO

-- Creating table 'CustomersListSet'
CREATE TABLE [dbo].[CustomersListSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [SampleMakingJournalId] int  NOT NULL,
    [SamplePrepJournalId] int  NOT NULL,
    [ChemistryJournalId] int  NOT NULL,
    [MainJournalId] int  NOT NULL
);
GO

-- Creating table 'SamplePrepJournalSet'
CREATE TABLE [dbo].[SamplePrepJournalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Task] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SampleMakingJournalSet'
CREATE TABLE [dbo].[SampleMakingJournalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Task] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MVZListSet'
CREATE TABLE [dbo].[MVZListSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MVZ] nchar(8)  NOT NULL,
    [SampleMakingJournalId] int  NOT NULL,
    [SamplePrepJournalId] int  NOT NULL,
    [ChemistryJournalId] int  NOT NULL,
    [MainJournalId] int  NOT NULL,
    [ChemistryJournalId1] int  NOT NULL,
    [SamplePrepJournalId1] int  NOT NULL,
    [SampleMakingJournalId1] int  NOT NULL
);
GO

-- Creating table 'ChemistryJournalSet'
CREATE TABLE [dbo].[ChemistryJournalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Steel] nvarchar(max)  NOT NULL,
    [ListOfElements] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TypeOfResearchSet'
CREATE TABLE [dbo].[TypeOfResearchSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [MainJournalId] int  NOT NULL
);
GO

-- Creating table 'DataJournalSet'
CREATE TABLE [dbo].[DataJournalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SampleMarks] nvarchar(max)  NULL,
    [Steel] nvarchar(max)  NULL,
    [Melt] nvarchar(max)  NULL,
    [MNLZ] tinyint  NULL,
    [Slab] smallint  NULL,
    [Part] nvarchar(max)  NULL,
    [Plate] smallint  NULL,
    [Thickness] real  NULL,
    [TypeOfTest] nvarchar(max)  NULL,
    [Requirements] nvarchar(max)  NULL,
    [ResultsOfTest] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MainJournalSet'
ALTER TABLE [dbo].[MainJournalSet]
ADD CONSTRAINT [PK_MainJournalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ListOfEngineersSet'
ALTER TABLE [dbo].[ListOfEngineersSet]
ADD CONSTRAINT [PK_ListOfEngineersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomersListSet'
ALTER TABLE [dbo].[CustomersListSet]
ADD CONSTRAINT [PK_CustomersListSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SamplePrepJournalSet'
ALTER TABLE [dbo].[SamplePrepJournalSet]
ADD CONSTRAINT [PK_SamplePrepJournalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SampleMakingJournalSet'
ALTER TABLE [dbo].[SampleMakingJournalSet]
ADD CONSTRAINT [PK_SampleMakingJournalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MVZListSet'
ALTER TABLE [dbo].[MVZListSet]
ADD CONSTRAINT [PK_MVZListSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChemistryJournalSet'
ALTER TABLE [dbo].[ChemistryJournalSet]
ADD CONSTRAINT [PK_ChemistryJournalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeOfResearchSet'
ALTER TABLE [dbo].[TypeOfResearchSet]
ADD CONSTRAINT [PK_TypeOfResearchSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DataJournalSet'
ALTER TABLE [dbo].[DataJournalSet]
ADD CONSTRAINT [PK_DataJournalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MainJournalId] in table 'CustomersListSet'
ALTER TABLE [dbo].[CustomersListSet]
ADD CONSTRAINT [FK_MainJournalCustomersList]
    FOREIGN KEY ([MainJournalId])
    REFERENCES [dbo].[MainJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MainJournalCustomersList'
CREATE INDEX [IX_FK_MainJournalCustomersList]
ON [dbo].[CustomersListSet]
    ([MainJournalId]);
GO

-- Creating foreign key on [MainJournalId] in table 'MVZListSet'
ALTER TABLE [dbo].[MVZListSet]
ADD CONSTRAINT [FK_MainJournalMVZList]
    FOREIGN KEY ([MainJournalId])
    REFERENCES [dbo].[MainJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MainJournalMVZList'
CREATE INDEX [IX_FK_MainJournalMVZList]
ON [dbo].[MVZListSet]
    ([MainJournalId]);
GO

-- Creating foreign key on [MainJournalId] in table 'TypeOfResearchSet'
ALTER TABLE [dbo].[TypeOfResearchSet]
ADD CONSTRAINT [FK_MainJournalTypeOfResearch]
    FOREIGN KEY ([MainJournalId])
    REFERENCES [dbo].[MainJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MainJournalTypeOfResearch'
CREATE INDEX [IX_FK_MainJournalTypeOfResearch]
ON [dbo].[TypeOfResearchSet]
    ([MainJournalId]);
GO

-- Creating foreign key on [MainJournalId] in table 'ListOfEngineersSet'
ALTER TABLE [dbo].[ListOfEngineersSet]
ADD CONSTRAINT [FK_MainJournalListOfEngineers]
    FOREIGN KEY ([MainJournalId])
    REFERENCES [dbo].[MainJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MainJournalListOfEngineers'
CREATE INDEX [IX_FK_MainJournalListOfEngineers]
ON [dbo].[ListOfEngineersSet]
    ([MainJournalId]);
GO

-- Creating foreign key on [ResearchData_Id] in table 'MainJournalSet'
ALTER TABLE [dbo].[MainJournalSet]
ADD CONSTRAINT [FK_MainJournalDataJournal]
    FOREIGN KEY ([ResearchData_Id])
    REFERENCES [dbo].[DataJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MainJournalDataJournal'
CREATE INDEX [IX_FK_MainJournalDataJournal]
ON [dbo].[MainJournalSet]
    ([ResearchData_Id]);
GO

-- Creating foreign key on [SamplePrepJournalId] in table 'ListOfEngineersSet'
ALTER TABLE [dbo].[ListOfEngineersSet]
ADD CONSTRAINT [FK_SamplePrepJournalListOfEngineers]
    FOREIGN KEY ([SamplePrepJournalId])
    REFERENCES [dbo].[SamplePrepJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SamplePrepJournalListOfEngineers'
CREATE INDEX [IX_FK_SamplePrepJournalListOfEngineers]
ON [dbo].[ListOfEngineersSet]
    ([SamplePrepJournalId]);
GO

-- Creating foreign key on [SamplePrepJournalId] in table 'CustomersListSet'
ALTER TABLE [dbo].[CustomersListSet]
ADD CONSTRAINT [FK_SamplePrepJournalCustomersList]
    FOREIGN KEY ([SamplePrepJournalId])
    REFERENCES [dbo].[SamplePrepJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SamplePrepJournalCustomersList'
CREATE INDEX [IX_FK_SamplePrepJournalCustomersList]
ON [dbo].[CustomersListSet]
    ([SamplePrepJournalId]);
GO

-- Creating foreign key on [SampleMakingJournalId] in table 'ListOfEngineersSet'
ALTER TABLE [dbo].[ListOfEngineersSet]
ADD CONSTRAINT [FK_SampleMakingJournalListOfEngineers]
    FOREIGN KEY ([SampleMakingJournalId])
    REFERENCES [dbo].[SampleMakingJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleMakingJournalListOfEngineers'
CREATE INDEX [IX_FK_SampleMakingJournalListOfEngineers]
ON [dbo].[ListOfEngineersSet]
    ([SampleMakingJournalId]);
GO

-- Creating foreign key on [SampleMakingJournalId] in table 'CustomersListSet'
ALTER TABLE [dbo].[CustomersListSet]
ADD CONSTRAINT [FK_SampleMakingJournalCustomers]
    FOREIGN KEY ([SampleMakingJournalId])
    REFERENCES [dbo].[SampleMakingJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleMakingJournalCustomers'
CREATE INDEX [IX_FK_SampleMakingJournalCustomers]
ON [dbo].[CustomersListSet]
    ([SampleMakingJournalId]);
GO

-- Creating foreign key on [ChemistryJournalId] in table 'ListOfEngineersSet'
ALTER TABLE [dbo].[ListOfEngineersSet]
ADD CONSTRAINT [FK_ChemistryJournalListOfEngineers]
    FOREIGN KEY ([ChemistryJournalId])
    REFERENCES [dbo].[ChemistryJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChemistryJournalListOfEngineers'
CREATE INDEX [IX_FK_ChemistryJournalListOfEngineers]
ON [dbo].[ListOfEngineersSet]
    ([ChemistryJournalId]);
GO

-- Creating foreign key on [ChemistryJournalId] in table 'CustomersListSet'
ALTER TABLE [dbo].[CustomersListSet]
ADD CONSTRAINT [FK_ChemistryJournalCustomersList]
    FOREIGN KEY ([ChemistryJournalId])
    REFERENCES [dbo].[ChemistryJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChemistryJournalCustomersList'
CREATE INDEX [IX_FK_ChemistryJournalCustomersList]
ON [dbo].[CustomersListSet]
    ([ChemistryJournalId]);
GO

-- Creating foreign key on [ChemistryJournalId1] in table 'MVZListSet'
ALTER TABLE [dbo].[MVZListSet]
ADD CONSTRAINT [FK_ChemistryJournalMVZList]
    FOREIGN KEY ([ChemistryJournalId1])
    REFERENCES [dbo].[ChemistryJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChemistryJournalMVZList'
CREATE INDEX [IX_FK_ChemistryJournalMVZList]
ON [dbo].[MVZListSet]
    ([ChemistryJournalId1]);
GO

-- Creating foreign key on [SamplePrepJournalId1] in table 'MVZListSet'
ALTER TABLE [dbo].[MVZListSet]
ADD CONSTRAINT [FK_SamplePrepJournalMVZList]
    FOREIGN KEY ([SamplePrepJournalId1])
    REFERENCES [dbo].[SamplePrepJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SamplePrepJournalMVZList'
CREATE INDEX [IX_FK_SamplePrepJournalMVZList]
ON [dbo].[MVZListSet]
    ([SamplePrepJournalId1]);
GO

-- Creating foreign key on [SampleMakingJournalId1] in table 'MVZListSet'
ALTER TABLE [dbo].[MVZListSet]
ADD CONSTRAINT [FK_SampleMakingJournalMVZList]
    FOREIGN KEY ([SampleMakingJournalId1])
    REFERENCES [dbo].[SampleMakingJournalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleMakingJournalMVZList'
CREATE INDEX [IX_FK_SampleMakingJournalMVZList]
ON [dbo].[MVZListSet]
    ([SampleMakingJournalId1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------