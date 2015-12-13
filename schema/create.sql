IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Action_ObjectType]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Action] DROP CONSTRAINT [FK_Action_ObjectType]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Activity_Issue]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Activity] DROP CONSTRAINT [FK_Activity_Issue]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Activity_Principal]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Activity] DROP CONSTRAINT [FK_Activity_Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Comment_Issue]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Comment] DROP CONSTRAINT [FK_Comment_Issue]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Comment_Principal]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Comment] DROP CONSTRAINT [FK_Comment_Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Issue_Project]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Issue] DROP CONSTRAINT [FK_Issue_Project]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Issue_Sprint]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Issue] DROP CONSTRAINT [FK_Issue_Sprint]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_MailQueue_Principal]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [MailQueue] DROP CONSTRAINT [FK_MailQueue_Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_MediaContent_Issue]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [MediaContent] DROP CONSTRAINT [FK_MediaContent_Issue]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_User_Principal]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PrincipalExtended] DROP CONSTRAINT [FK_User_Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PrincipalProject_Principal]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PrincipalProject] DROP CONSTRAINT [FK_PrincipalProject_Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PrincipalProject_Project]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PrincipalProject] DROP CONSTRAINT [FK_PrincipalProject_Project]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PrincipalRole_Principal]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PrincipalRole] DROP CONSTRAINT [FK_PrincipalRole_Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_PrincipalRole_Role]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [PrincipalRole] DROP CONSTRAINT [FK_PrincipalRole_Role]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Project_Principal]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Project] DROP CONSTRAINT [FK_Project_Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Role_RoleType]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Role] DROP CONSTRAINT [FK_Role_RoleType]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_RoleAction_Action]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [RoleAction] DROP CONSTRAINT [FK_RoleAction_Action]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_RoleAction_Role]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [RoleAction] DROP CONSTRAINT [FK_RoleAction_Role]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_RoleTypeAction_Action]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [RoleTypeAction] DROP CONSTRAINT [FK_RoleTypeAction_Action]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_RoleTypeAction_RoleType]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [RoleTypeAction] DROP CONSTRAINT [FK_RoleTypeAction_RoleType]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Sprint_Project]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Sprint] DROP CONSTRAINT [FK_Sprint_Project]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Action]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Action]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Activity]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Activity]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Comment]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Comment]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Issue]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Issue]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Localisation]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Localisation]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Log]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Log]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[MailQueue]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [MailQueue]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[MediaContent]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [MediaContent]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[ObjectType]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [ObjectType]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Principal]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PrincipalExtended]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PrincipalExtended]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PrincipalProject]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PrincipalProject]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[PrincipalRole]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [PrincipalRole]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Project]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Project]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Reports]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Reports]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Role]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Role]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[RoleAction]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [RoleAction]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[RoleType]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [RoleType]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[RoleTypeAction]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [RoleTypeAction]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Settings]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Settings]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Sprint]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Sprint]
;

CREATE TABLE [Action]
(
	[Id] uniqueidentifier NOT NULL,
	[Name] nvarchar(100) NOT NULL,
	[ObjectTypeId] uniqueidentifier NOT NULL
)
;

CREATE TABLE [Activity]
(
	[Id] uniqueidentifier NOT NULL,
	[ActivityType] int NOT NULL,
	[CreateTime] datetime NOT NULL,
	[CreatorId] uniqueidentifier NOT NULL,
	[IssueId] uniqueidentifier NOT NULL,
	[OldValue] nvarchar(max),
	[NewValue] nvarchar(max)
)
;

CREATE TABLE [Comment]
(
	[Id] uniqueidentifier NOT NULL,
	[Text] nvarchar(max) NOT NULL,
	[CreatorId] uniqueidentifier NOT NULL,
	[CreateTime] datetime NOT NULL,
	[IssueId] uniqueidentifier NOT NULL
)
;

CREATE TABLE [Issue]
(
	[Id] uniqueidentifier NOT NULL,
	[Name] nvarchar(200) NOT NULL,
	[Description] nvarchar(1000),
	[Version] int NOT NULL,
	[Type] int NOT NULL,
	[ProjectId] uniqueidentifier NOT NULL,
	[Status] int NOT NULL,
	[Priority] int NOT NULL,
	[AssigneeId] uniqueidentifier NOT NULL,
	[EstimatedTime] time(7),
	[CreateTime] datetime,
	[SprintId] uniqueidentifier
)
;

CREATE TABLE [Localisation]
(
	[Id] uniqueidentifier NOT NULL,
	[TranslationKey] nvarchar(200) NOT NULL,
	[Value] nvarchar(3000) NOT NULL,
	[LanguageId] int NOT NULL
)
;

CREATE TABLE [Log]
(
	[Id] int NOT NULL,
	[Date] datetime NOT NULL,
	[Level] varchar(50) NOT NULL,
	[AppDomain] varchar(255) NOT NULL,
	[Thread] varchar(255) NOT NULL,
	[Logger] varchar(255) NOT NULL,
	[Identity] nvarchar(500) NOT NULL,
	[Exception] nvarchar(max),
	[Location] nvarchar(max)
)
;

CREATE TABLE [MailQueue]
(
	[Id] uniqueidentifier NOT NULL,
	[MessageText] nvarchar(max),
	[CreateTime] datetime NOT NULL,
	[PrincipalId] uniqueidentifier NOT NULL
)
;

CREATE TABLE [MediaContent]
(
	[Id] uniqueidentifier NOT NULL,
	[Name] nvarchar(max) NOT NULL,
	[Path] varchar(max) NOT NULL,
	[IssueId] uniqueidentifier NOT NULL,
	[Version] int NOT NULL
)
;

CREATE TABLE [ObjectType]
(
	[Id] uniqueidentifier NOT NULL,
	[Name] nvarchar(200) NOT NULL
)
;

CREATE TABLE [Principal]
(
	[Id] uniqueidentifier NOT NULL,
	[Username] nvarchar(100) NOT NULL,
	[CreateTime] datetime NOT NULL,
	[Version] int NOT NULL,
	[Password] nchar(256) NOT NULL,
	[Email] nvarchar(200) NOT NULL
)
;

CREATE TABLE [PrincipalExtended]
(
	[Id] uniqueidentifier NOT NULL,
	[FirstName] nvarchar(100) NOT NULL,
	[LastName] nvarchar(50) NOT NULL
)
;

CREATE TABLE [PrincipalProject]
(
	[Id] uniqueidentifier NOT NULL,
	[ProjectId] uniqueidentifier NOT NULL,
	[PrincipalId] uniqueidentifier NOT NULL,
	[CreateTime] datetime NOT NULL
)
;

CREATE TABLE [PrincipalRole]
(
	[Id] uniqueidentifier NOT NULL,
	[RoleId] uniqueidentifier NOT NULL,
	[PrincipalId] uniqueidentifier NOT NULL,
	[CreateTime] datetime NOT NULL
)
;

CREATE TABLE [Project]
(
	[Id] uniqueidentifier NOT NULL,
	[Name] nvarchar(300) NOT NULL,
	[ShortName] nvarchar(10) NOT NULL,
	[Description] nvarchar(3000),
	[Version] int NOT NULL,
	[CreateTime] datetime NOT NULL,
	[CreatorId] uniqueidentifier NOT NULL
)
;

CREATE TABLE [Reports]
(
	[Id] uniqueidentifier NOT NULL,
	[CreateTime] datetime NOT NULL,
	[ReportText] nvarchar(max) NOT NULL
)
;

CREATE TABLE [Role]
(
	[Id] uniqueidentifier NOT NULL,
	[RoleTypeId] uniqueidentifier NOT NULL,
	[Name] nvarchar(100) NOT NULL,
	[Description] nvarchar(500),
	[Version] int NOT NULL,
	[CreatorId] uniqueidentifier,
	[CreateTime] datetime NOT NULL
)
;

CREATE TABLE [RoleAction]
(
	[Id] uniqueidentifier NOT NULL,
	[RoleId] uniqueidentifier NOT NULL,
	[ActionId] uniqueidentifier NOT NULL
)
;

CREATE TABLE [RoleType]
(
	[Id] uniqueidentifier NOT NULL,
	[Name] nvarchar(100) NOT NULL
)
;

CREATE TABLE [RoleTypeAction]
(
	[Id] uniqueidentifier NOT NULL,
	[RoleTypeId] uniqueidentifier NOT NULL,
	[ActionId] uniqueidentifier NOT NULL
)
;

CREATE TABLE [Settings]
(
	[Id] uniqueidentifier NOT NULL,
	[SettingKey] nvarchar(200) NOT NULL,
	[Value] nvarchar(max) NOT NULL
)
;

CREATE TABLE [Sprint]
(
	[Id] uniqueidentifier NOT NULL,
	[Version] int NOT NULL,
	[ProjectId] uniqueidentifier NOT NULL,
	[StartTime] datetime NOT NULL,
	[EndTime] datetime,
	[ProjectVersion] nvarchar(50) NOT NULL
)
;

CREATE INDEX [IXFK_Action_ObjectType] 
 ON [Action] ([ObjectTypeId] ASC)
;

ALTER TABLE [Action] 
 ADD CONSTRAINT [PK_Action]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_Activity_Issue] 
 ON [Activity] ([IssueId] ASC)
;

CREATE INDEX [IXFK_Activity_Principal] 
 ON [Activity] ([CreatorId] ASC)
;

ALTER TABLE [Activity] 
 ADD CONSTRAINT [PK_Activity]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_Comment_Issue] 
 ON [Comment] ([IssueId] ASC)
;

CREATE INDEX [IXFK_Comment_Principal] 
 ON [Comment] ([CreatorId] ASC)
;

ALTER TABLE [Comment] 
 ADD CONSTRAINT [PK_Comment]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_Issue_Project] 
 ON [Issue] ([ProjectId] ASC)
;

CREATE INDEX [IXFK_Issue_Sprint] 
 ON [Issue] ([Id] ASC)
;

ALTER TABLE [Issue] 
 ADD CONSTRAINT [PK_Issue]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Localisation] 
 ADD CONSTRAINT [PK_Localisation]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Log] 
 ADD CONSTRAINT [PK_Log]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_MailQueue_Principal] 
 ON [MailQueue] ([PrincipalId] ASC)
;

ALTER TABLE [MailQueue] 
 ADD CONSTRAINT [PK_MailQueue]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_MediaContent_Issue] 
 ON [MediaContent] ([IssueId] ASC)
;

ALTER TABLE [MediaContent] 
 ADD CONSTRAINT [PK_MediaContent]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [ObjectType] 
 ADD CONSTRAINT [PK_ObjectType]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Principal] 
 ADD CONSTRAINT [PK_Principal]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_User_Principal] 
 ON [PrincipalExtended] ([Id] ASC)
;

ALTER TABLE [PrincipalExtended] 
 ADD CONSTRAINT [PK_PrincipalExtended]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_PrincipalProject_Principal] 
 ON [PrincipalProject] ([PrincipalId] ASC)
;

CREATE INDEX [IXFK_PrincipalProject_Project] 
 ON [PrincipalProject] ([ProjectId] ASC)
;

ALTER TABLE [PrincipalProject] 
 ADD CONSTRAINT [PK_PrincipalProject]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_PrincipalRole_Principal] 
 ON [PrincipalRole] ([PrincipalId] ASC)
;

CREATE INDEX [IXFK_PrincipalRole_Role] 
 ON [PrincipalRole] ([RoleId] ASC)
;

ALTER TABLE [PrincipalRole] 
 ADD CONSTRAINT [PK_PrincipalRole]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_Project_Principal] 
 ON [Project] ([CreatorId] ASC)
;

ALTER TABLE [Project] 
 ADD CONSTRAINT [PK_Project]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Reports] 
 ADD CONSTRAINT [PK_Report]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_Role_RoleType] 
 ON [Role] ([RoleTypeId] ASC)
;

ALTER TABLE [Role] 
 ADD CONSTRAINT [PK_Role]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_RoleAction_Action] 
 ON [RoleAction] ([ActionId] ASC)
;

CREATE INDEX [IXFK_RoleAction_Role] 
 ON [RoleAction] ([RoleId] ASC)
;

ALTER TABLE [RoleAction] 
 ADD CONSTRAINT [PK_RoleAction]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [RoleType] 
 ADD CONSTRAINT [PK_RoleType]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_RoleTypeAction_Action] 
 ON [RoleTypeAction] ([ActionId] ASC)
;

CREATE INDEX [IXFK_RoleTypeAction_RoleType] 
 ON [RoleTypeAction] ([RoleTypeId] ASC)
;

ALTER TABLE [RoleTypeAction] 
 ADD CONSTRAINT [PK_RoleTypeAction]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Settings] 
 ADD CONSTRAINT [PK_Settings]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_Sprint_Project] 
 ON [Sprint] ([ProjectId] ASC)
;

ALTER TABLE [Sprint] 
 ADD CONSTRAINT [PK_Sprint]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Action] ADD CONSTRAINT [FK_Action_ObjectType]
	FOREIGN KEY ([ObjectTypeId]) REFERENCES [ObjectType] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Activity] ADD CONSTRAINT [FK_Activity_Issue]
	FOREIGN KEY ([IssueId]) REFERENCES [Issue] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Activity] ADD CONSTRAINT [FK_Activity_Principal]
	FOREIGN KEY ([CreatorId]) REFERENCES [Principal] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Comment] ADD CONSTRAINT [FK_Comment_Issue]
	FOREIGN KEY ([IssueId]) REFERENCES [Issue] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Comment] ADD CONSTRAINT [FK_Comment_Principal]
	FOREIGN KEY ([CreatorId]) REFERENCES [Principal] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Issue] ADD CONSTRAINT [FK_Issue_Project]
	FOREIGN KEY ([ProjectId]) REFERENCES [Project] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Issue] ADD CONSTRAINT [FK_Issue_Sprint]
	FOREIGN KEY ([Id]) REFERENCES [Sprint] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [MailQueue] ADD CONSTRAINT [FK_MailQueue_Principal]
	FOREIGN KEY ([PrincipalId]) REFERENCES [Principal] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [MediaContent] ADD CONSTRAINT [FK_MediaContent_Issue]
	FOREIGN KEY ([IssueId]) REFERENCES [Issue] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PrincipalExtended] ADD CONSTRAINT [FK_User_Principal]
	FOREIGN KEY ([Id]) REFERENCES [Principal] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PrincipalProject] ADD CONSTRAINT [FK_PrincipalProject_Principal]
	FOREIGN KEY ([PrincipalId]) REFERENCES [Principal] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PrincipalProject] ADD CONSTRAINT [FK_PrincipalProject_Project]
	FOREIGN KEY ([ProjectId]) REFERENCES [Project] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PrincipalRole] ADD CONSTRAINT [FK_PrincipalRole_Principal]
	FOREIGN KEY ([PrincipalId]) REFERENCES [Principal] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [PrincipalRole] ADD CONSTRAINT [FK_PrincipalRole_Role]
	FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Project] ADD CONSTRAINT [FK_Project_Principal]
	FOREIGN KEY ([CreatorId]) REFERENCES [Principal] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Role] ADD CONSTRAINT [FK_Role_RoleType]
	FOREIGN KEY ([RoleTypeId]) REFERENCES [RoleType] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [RoleAction] ADD CONSTRAINT [FK_RoleAction_Action]
	FOREIGN KEY ([ActionId]) REFERENCES [Action] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [RoleAction] ADD CONSTRAINT [FK_RoleAction_Role]
	FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [RoleTypeAction] ADD CONSTRAINT [FK_RoleTypeAction_Action]
	FOREIGN KEY ([ActionId]) REFERENCES [Action] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [RoleTypeAction] ADD CONSTRAINT [FK_RoleTypeAction_RoleType]
	FOREIGN KEY ([RoleTypeId]) REFERENCES [RoleType] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Sprint] ADD CONSTRAINT [FK_Sprint_Project]
	FOREIGN KEY ([ProjectId]) REFERENCES [Project] ([Id]) ON DELETE No Action ON UPDATE No Action
;
