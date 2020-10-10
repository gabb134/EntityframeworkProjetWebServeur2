USE [BDW56Projet1VotreNom]-- insérer votre nom  pour créer votre base de données
GO
-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employee_Employee'
CREATE TABLE [dbo].[Employee_Employee] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [EntrepriseID] int  NOT NULL,	
    [FirstName] varchar(50)  NOT NULL,
    [MiddleName] varchar(50)  NULL,
    [LastName] varchar(50)  NOT NULL,
	[Gender] nvarchar(8)  NULL,
    [EmailAddress] nvarchar(50)  NULL,
    [Titre] nvarchar(50)  NOT NULL,
	[Department] nvarchar(50)  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO
-- Creating table 'Employee_PhoneNumber'
CREATE TABLE [dbo].[Employee_PhoneNumber] (
    [EmployeeID] int  NOT NULL,
    [PhoneNumberID] int IDENTITY(1,1) NOT NULL,
    [PhoneNumberTypeID] int  NOT NULL,
    [PhoneNumber] nvarchar(50)  NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'Employee_PhoneNumberType'
CREATE TABLE [dbo].[Employee_PhoneNumberType] (
    [PhoneNumberTypeID] int IDENTITY(1,1) NOT NULL,
    [PhoneNumberType] varchar(50)  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'Entreprise_Address'
CREATE TABLE [dbo].[Entreprise_Address] (
    [AddressID] int IDENTITY(1,1) NOT NULL,
    [EntrepriseID] int  NOT NULL,
    [AddressTypeID] int  NOT NULL,
    [AddressLine1] nvarchar(60)  NOT NULL,
    [AddressLine2] nvarchar(60)  NULL,
    [City] nvarchar(30)  NOT NULL,
    [Province] nvarchar(30)  NULL,
    [Country] nvarchar(50)  NULL,
    [PostalCode] nvarchar(15)  NULL,
    [EntrepriseAddWeb] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'Entreprise_AddressType'
CREATE TABLE [dbo].[Entreprise_AddressType] (
    [AddressTypeID] int IDENTITY(1,1) NOT NULL,
    [AddressType] varchar(50)  NOT NULL,
    [ModifiedDate] datetime  NOT NULL
);
GO

-- Creating table 'Entreprise_Entreprise'
CREATE TABLE [dbo].[Entreprise_Entreprise] (
    [EntrepriseID] int IDENTITY(1,1) NOT NULL,
    [EntrepriseName] nvarchar(50)  NULL,
    [EntrepriseNote] nvarchar(max)  NULL,
    [DateInscrit] datetime  NULL,
    [DateMod] datetime  NULL
);
GO


-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EmployeeID] in table 'Employee_Employee'
ALTER TABLE [dbo].[Employee_Employee]
ADD CONSTRAINT [PK_Employee_Employee]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [EmployeeID], [PhoneNumberID] in table 'Employee_PhoneNumber'
ALTER TABLE [dbo].[Employee_PhoneNumber]
ADD CONSTRAINT [PK_Employee_PhoneNumber]
    PRIMARY KEY CLUSTERED ([EmployeeID], [PhoneNumberID] ASC);
GO

-- Creating primary key on [PhoneNumberTypeID] in table 'Employee_PhoneNumberType'
ALTER TABLE [dbo].[Employee_PhoneNumberType]
ADD CONSTRAINT [PK_Employee_PhoneNumberType]
    PRIMARY KEY CLUSTERED ([PhoneNumberTypeID] ASC);
GO

-- Creating primary key on [AddressID] in table 'Entreprise_Address'
ALTER TABLE [dbo].[Entreprise_Address]
ADD CONSTRAINT [PK_Entreprise_Address]
    PRIMARY KEY CLUSTERED ([AddressID] ASC);
GO

-- Creating primary key on [AddressTypeID] in table 'Entreprise_AddressType'
ALTER TABLE [dbo].[Entreprise_AddressType]
ADD CONSTRAINT [PK_Entreprise_AddressType]
    PRIMARY KEY CLUSTERED ([AddressTypeID] ASC);
GO

-- Creating primary key on [EntrepriseID] in table 'Entreprise_Entreprise'
ALTER TABLE [dbo].[Entreprise_Entreprise]
ADD CONSTRAINT [PK_Entreprise_Entreprise]
    PRIMARY KEY CLUSTERED ([EntrepriseID] ASC);
GO


-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EntrepriseID] in table 'Employee_Employee'
ALTER TABLE [dbo].[Employee_Employee]
ADD CONSTRAINT [FK_Employee_Entreprise_EntrepriseID]
    FOREIGN KEY ([EntrepriseID])
    REFERENCES [dbo].[Entreprise_Entreprise]
        ([EntrepriseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Entreprise_EntrepriseID'
CREATE INDEX [IX_FK_Employee_Entreprise_EntrepriseID]
ON [dbo].[Employee_Employee]
    ([EntrepriseID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Employee_PhoneNumber'
ALTER TABLE [dbo].[Employee_PhoneNumber]
ADD CONSTRAINT [FK_EmployeePhoneNumber_Employee_EmployeeID]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employee_Employee]
        ([EmployeeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PhoneNumberTypeID] in table 'Employee_PhoneNumber'
ALTER TABLE [dbo].[Employee_PhoneNumber]
ADD CONSTRAINT [FK_EmployeePhoneNumber_Employee_PhoneNumberTypeID]
    FOREIGN KEY ([PhoneNumberTypeID])
    REFERENCES [dbo].[Employee_PhoneNumberType]
        ([PhoneNumberTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeePhoneNumber_Employee_PhoneNumberTypeID'
CREATE INDEX [IX_FK_EmployeePhoneNumber_Employee_PhoneNumberTypeID]
ON [dbo].[Employee_PhoneNumber]
    ([PhoneNumberTypeID]);
GO
----------------------------------
-- Creating foreign key on [AddressTypeID] in table 'Entreprise_Address'
ALTER TABLE [dbo].[Entreprise_Address]
ADD CONSTRAINT [FK_Address_AddressType_AddressTypeID]
    FOREIGN KEY ([AddressTypeID])
    REFERENCES [dbo].[Entreprise_AddressType]
        ([AddressTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Address_AddressType_AddressTypeID'
CREATE INDEX [IX_FK_Address_AddressType_AddressTypeID]
ON [dbo].[Entreprise_Address]
    ([AddressTypeID]);
GO

-- Creating foreign key on [EntrepriseID] in table 'Entreprise_Address'
ALTER TABLE [dbo].[Entreprise_Address]
ADD CONSTRAINT [FK_Address_Entreprise_EntrepriseID]
    FOREIGN KEY ([EntrepriseID])
    REFERENCES [dbo].[Entreprise_Entreprise]
        ([EntrepriseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Address_Entreprise_EntrepriseID'
CREATE INDEX [IX_FK_Address_Entreprise_EntrepriseID]
ON [dbo].[Entreprise_Address]
    ([EntrepriseID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------