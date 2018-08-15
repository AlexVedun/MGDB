
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/15/2018 19:43:52
-- Generated from EDMX file: C:\Users\Alex\SkyDrive\ШАГ\Программирование\Курсовые проекты\C#\MGDB\MGDB\Models\MGDBModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_MainJournalDataJournal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResearchSet] DROP CONSTRAINT [FK_MainJournalDataJournal];
GO
IF OBJECT_ID(N'[dbo].[FK_MainJournalListOfEngineers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResearchSet] DROP CONSTRAINT [FK_MainJournalListOfEngineers];
GO
IF OBJECT_ID(N'[dbo].[FK_MainJournalMVZList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResearchSet] DROP CONSTRAINT [FK_MainJournalMVZList];
GO
IF OBJECT_ID(N'[dbo].[FK_MainJournalCustomersList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResearchSet] DROP CONSTRAINT [FK_MainJournalCustomersList];
GO
IF OBJECT_ID(N'[dbo].[FK_ResearchTypeOfResearch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResearchSet] DROP CONSTRAINT [FK_ResearchTypeOfResearch];
GO
IF OBJECT_ID(N'[dbo].[FK_ChemistryJournalListOfEngineers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChemistryJournalSet] DROP CONSTRAINT [FK_ChemistryJournalListOfEngineers];
GO
IF OBJECT_ID(N'[dbo].[FK_ChemistryJournalCustomersList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChemistryJournalSet] DROP CONSTRAINT [FK_ChemistryJournalCustomersList];
GO
IF OBJECT_ID(N'[dbo].[FK_ChemistryJournalMVZList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChemistryJournalSet] DROP CONSTRAINT [FK_ChemistryJournalMVZList];
GO
IF OBJECT_ID(N'[dbo].[FK_SamplePrepJournalListOfEngineers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SamplePrepJournalSet] DROP CONSTRAINT [FK_SamplePrepJournalListOfEngineers];
GO
IF OBJECT_ID(N'[dbo].[FK_SamplePrepJournalCustomersList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SamplePrepJournalSet] DROP CONSTRAINT [FK_SamplePrepJournalCustomersList];
GO
IF OBJECT_ID(N'[dbo].[FK_SamplePrepJournalMVZList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SamplePrepJournalSet] DROP CONSTRAINT [FK_SamplePrepJournalMVZList];
GO
IF OBJECT_ID(N'[dbo].[FK_SampleMakingJournalListOfEngineers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SampleMakingJournalSet] DROP CONSTRAINT [FK_SampleMakingJournalListOfEngineers];
GO
IF OBJECT_ID(N'[dbo].[FK_SampleMakingJournalCustomersList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SampleMakingJournalSet] DROP CONSTRAINT [FK_SampleMakingJournalCustomersList];
GO
IF OBJECT_ID(N'[dbo].[FK_SampleMakingJournalMVZList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SampleMakingJournalSet] DROP CONSTRAINT [FK_SampleMakingJournalMVZList];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomersListMVZList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MVZListSet] DROP CONSTRAINT [FK_CustomersListMVZList];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ResearchSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResearchSet];
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
IF OBJECT_ID(N'[dbo].[ResearchDataSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResearchDataSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ResearchSet'
CREATE TABLE [dbo].[ResearchSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] nchar(8)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [NumberOfSamples] smallint  NOT NULL,
    [Notation] nvarchar(512)  NULL,
    [Status] int  NOT NULL,
    [StatusDescription] nvarchar(512)  NULL,
    [ResearchResults] nvarchar(max)  NULL,
    [TypeOfDefect] int  NULL,
    [FinishDate] datetime  NULL,
    [Document1] varbinary(max)  NULL,
    [Document2] varbinary(max)  NULL,
    [Document3] varbinary(max)  NULL,
    [ListOfEngineersId] int  NOT NULL,
    [MVZListId] int  NOT NULL,
    [CustomersListId] int  NOT NULL,
    [TypeOfResearchId] int  NOT NULL,
    [ResearchData_Id] int  NOT NULL
);
GO

-- Creating table 'EngineerSet'
CREATE TABLE [dbo].[EngineerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SamplePrepJournalSet'
CREATE TABLE [dbo].[SamplePrepJournalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Task] nvarchar(max)  NOT NULL,
    [ListOfEngineersId] int  NOT NULL,
    [CustomersListId] int  NOT NULL,
    [MVZListId] int  NOT NULL
);
GO

-- Creating table 'SampleMakingJournalSet'
CREATE TABLE [dbo].[SampleMakingJournalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Task] nvarchar(max)  NOT NULL,
    [ListOfEngineersId] int  NOT NULL,
    [CustomersListId] int  NOT NULL,
    [MVZListId] int  NOT NULL
);
GO

-- Creating table 'MVZSet'
CREATE TABLE [dbo].[MVZSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nchar(8)  NOT NULL,
    [CustomersListId] int  NOT NULL
);
GO

-- Creating table 'ChemistryJournalSet'
CREATE TABLE [dbo].[ChemistryJournalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Steel] nvarchar(max)  NOT NULL,
    [ListOfElements] nvarchar(max)  NOT NULL,
    [ListOfEngineersId] int  NOT NULL,
    [CustomersListId] int  NOT NULL,
    [MVZListId] int  NOT NULL
);
GO

-- Creating table 'TypeOfResearchSet'
CREATE TABLE [dbo].[TypeOfResearchSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ResearchDataSet'
CREATE TABLE [dbo].[ResearchDataSet] (
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

-- Creating primary key on [Id] in table 'ResearchSet'
ALTER TABLE [dbo].[ResearchSet]
ADD CONSTRAINT [PK_ResearchSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EngineerSet'
ALTER TABLE [dbo].[EngineerSet]
ADD CONSTRAINT [PK_EngineerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
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

-- Creating primary key on [Id] in table 'MVZSet'
ALTER TABLE [dbo].[MVZSet]
ADD CONSTRAINT [PK_MVZSet]
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

-- Creating primary key on [Id] in table 'ResearchDataSet'
ALTER TABLE [dbo].[ResearchDataSet]
ADD CONSTRAINT [PK_ResearchDataSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ListOfEngineersId] in table 'ResearchSet'
ALTER TABLE [dbo].[ResearchSet]
ADD CONSTRAINT [FK_MainJournalListOfEngineers]
    FOREIGN KEY ([ListOfEngineersId])
    REFERENCES [dbo].[EngineerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MainJournalListOfEngineers'
CREATE INDEX [IX_FK_MainJournalListOfEngineers]
ON [dbo].[ResearchSet]
    ([ListOfEngineersId]);
GO

-- Creating foreign key on [MVZListId] in table 'ResearchSet'
ALTER TABLE [dbo].[ResearchSet]
ADD CONSTRAINT [FK_MainJournalMVZList]
    FOREIGN KEY ([MVZListId])
    REFERENCES [dbo].[MVZSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MainJournalMVZList'
CREATE INDEX [IX_FK_MainJournalMVZList]
ON [dbo].[ResearchSet]
    ([MVZListId]);
GO

-- Creating foreign key on [CustomersListId] in table 'ResearchSet'
ALTER TABLE [dbo].[ResearchSet]
ADD CONSTRAINT [FK_MainJournalCustomersList]
    FOREIGN KEY ([CustomersListId])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MainJournalCustomersList'
CREATE INDEX [IX_FK_MainJournalCustomersList]
ON [dbo].[ResearchSet]
    ([CustomersListId]);
GO

-- Creating foreign key on [TypeOfResearchId] in table 'ResearchSet'
ALTER TABLE [dbo].[ResearchSet]
ADD CONSTRAINT [FK_ResearchTypeOfResearch]
    FOREIGN KEY ([TypeOfResearchId])
    REFERENCES [dbo].[TypeOfResearchSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResearchTypeOfResearch'
CREATE INDEX [IX_FK_ResearchTypeOfResearch]
ON [dbo].[ResearchSet]
    ([TypeOfResearchId]);
GO

-- Creating foreign key on [ListOfEngineersId] in table 'ChemistryJournalSet'
ALTER TABLE [dbo].[ChemistryJournalSet]
ADD CONSTRAINT [FK_ChemistryJournalListOfEngineers]
    FOREIGN KEY ([ListOfEngineersId])
    REFERENCES [dbo].[EngineerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChemistryJournalListOfEngineers'
CREATE INDEX [IX_FK_ChemistryJournalListOfEngineers]
ON [dbo].[ChemistryJournalSet]
    ([ListOfEngineersId]);
GO

-- Creating foreign key on [CustomersListId] in table 'ChemistryJournalSet'
ALTER TABLE [dbo].[ChemistryJournalSet]
ADD CONSTRAINT [FK_ChemistryJournalCustomersList]
    FOREIGN KEY ([CustomersListId])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChemistryJournalCustomersList'
CREATE INDEX [IX_FK_ChemistryJournalCustomersList]
ON [dbo].[ChemistryJournalSet]
    ([CustomersListId]);
GO

-- Creating foreign key on [MVZListId] in table 'ChemistryJournalSet'
ALTER TABLE [dbo].[ChemistryJournalSet]
ADD CONSTRAINT [FK_ChemistryJournalMVZList]
    FOREIGN KEY ([MVZListId])
    REFERENCES [dbo].[MVZSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChemistryJournalMVZList'
CREATE INDEX [IX_FK_ChemistryJournalMVZList]
ON [dbo].[ChemistryJournalSet]
    ([MVZListId]);
GO

-- Creating foreign key on [ListOfEngineersId] in table 'SamplePrepJournalSet'
ALTER TABLE [dbo].[SamplePrepJournalSet]
ADD CONSTRAINT [FK_SamplePrepJournalListOfEngineers]
    FOREIGN KEY ([ListOfEngineersId])
    REFERENCES [dbo].[EngineerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SamplePrepJournalListOfEngineers'
CREATE INDEX [IX_FK_SamplePrepJournalListOfEngineers]
ON [dbo].[SamplePrepJournalSet]
    ([ListOfEngineersId]);
GO

-- Creating foreign key on [CustomersListId] in table 'SamplePrepJournalSet'
ALTER TABLE [dbo].[SamplePrepJournalSet]
ADD CONSTRAINT [FK_SamplePrepJournalCustomersList]
    FOREIGN KEY ([CustomersListId])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SamplePrepJournalCustomersList'
CREATE INDEX [IX_FK_SamplePrepJournalCustomersList]
ON [dbo].[SamplePrepJournalSet]
    ([CustomersListId]);
GO

-- Creating foreign key on [MVZListId] in table 'SamplePrepJournalSet'
ALTER TABLE [dbo].[SamplePrepJournalSet]
ADD CONSTRAINT [FK_SamplePrepJournalMVZList]
    FOREIGN KEY ([MVZListId])
    REFERENCES [dbo].[MVZSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SamplePrepJournalMVZList'
CREATE INDEX [IX_FK_SamplePrepJournalMVZList]
ON [dbo].[SamplePrepJournalSet]
    ([MVZListId]);
GO

-- Creating foreign key on [ListOfEngineersId] in table 'SampleMakingJournalSet'
ALTER TABLE [dbo].[SampleMakingJournalSet]
ADD CONSTRAINT [FK_SampleMakingJournalListOfEngineers]
    FOREIGN KEY ([ListOfEngineersId])
    REFERENCES [dbo].[EngineerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleMakingJournalListOfEngineers'
CREATE INDEX [IX_FK_SampleMakingJournalListOfEngineers]
ON [dbo].[SampleMakingJournalSet]
    ([ListOfEngineersId]);
GO

-- Creating foreign key on [CustomersListId] in table 'SampleMakingJournalSet'
ALTER TABLE [dbo].[SampleMakingJournalSet]
ADD CONSTRAINT [FK_SampleMakingJournalCustomersList]
    FOREIGN KEY ([CustomersListId])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleMakingJournalCustomersList'
CREATE INDEX [IX_FK_SampleMakingJournalCustomersList]
ON [dbo].[SampleMakingJournalSet]
    ([CustomersListId]);
GO

-- Creating foreign key on [MVZListId] in table 'SampleMakingJournalSet'
ALTER TABLE [dbo].[SampleMakingJournalSet]
ADD CONSTRAINT [FK_SampleMakingJournalMVZList]
    FOREIGN KEY ([MVZListId])
    REFERENCES [dbo].[MVZSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SampleMakingJournalMVZList'
CREATE INDEX [IX_FK_SampleMakingJournalMVZList]
ON [dbo].[SampleMakingJournalSet]
    ([MVZListId]);
GO

-- Creating foreign key on [CustomersListId] in table 'MVZSet'
ALTER TABLE [dbo].[MVZSet]
ADD CONSTRAINT [FK_CustomersListMVZList]
    FOREIGN KEY ([CustomersListId])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomersListMVZList'
CREATE INDEX [IX_FK_CustomersListMVZList]
ON [dbo].[MVZSet]
    ([CustomersListId]);
GO

-- Creating foreign key on [ResearchData_Id] in table 'ResearchSet'
ALTER TABLE [dbo].[ResearchSet]
ADD CONSTRAINT [FK_ResearchResearchData]
    FOREIGN KEY ([ResearchData_Id])
    REFERENCES [dbo].[ResearchDataSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResearchResearchData'
CREATE INDEX [IX_FK_ResearchResearchData]
ON [dbo].[ResearchSet]
    ([ResearchData_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------