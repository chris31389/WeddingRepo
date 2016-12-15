USE TestDb

SELECT * FROM Invite
SELECT * FROM Invitee
SELECT * FROM Meal
SELECT * FROM Rsvp
SELECT * FROM InviteWeddingEvent


DELETE FROM Invite
DELETE FROM Meal
DELETE FROM Rsvp
DELETE FROM Invitee
DELETE FROM InviteWeddingEvent

USE Master

-- 

USE Master

EXEC('DROP DATABASE TestDb')
EXEC('CREATE DATABASE TestDb')

USE TestDb

CREATE TABLE ReferenceData(
	Id uniqueidentifier,
	Discriminator varchar(255),
	Value varchar(255),
	SecondaryValue varchar(255)
)

INSERT INTO ReferenceData VALUES 
(newid(), 'MainChoice', 'Seabass', 'Adult'),
(newid(), 'MainChoice', 'Lamb', 'Adult'),
(newid(), 'MainChoice', 'Tartlet', 'Adult'),
(newid(), 'MainChoice', 'Child1', 'Child'),
(newid(), 'DessertChoice', 'Brulee', 'Adult'),
(newid(), 'DessertChoice', 'Crumble', 'Adult'),
(newid(), 'DessertChoice', 'Child1', 'Child'),
(newid(), 'StarterChoice', 'Duck', 'Adult'),
(newid(), 'StarterChoice', 'Risotto', 'Adult'),
(newid(), 'StarterChoice', 'Child1', 'Child'),
(newid(), 'WeddingEvent', 'Breakfast'),
(newid(), 'WeddingEvent', 'Ceremony'),
(newid(), 'WeddingEvent', 'Evening')

USE Master

-- 

USE TestDb

SELECT * FROM Users

USE Master

CREATE TABLE InviteWeddingEvent(
	Id uniqueidentifier,
	InviteId uniqueidentifier,
	WeddingEventId uniqueidentifier
)








DROP TABLE Invitee;
DROP TABLE Invite;
DROP TABLE Meal;
DROP TABLE Rsvp;
DROP TABLE InviteWeddingEvent




CREATE TABLE InviteWeddingEvent(
	Id uniqueidentifier,
	InviteId uniqueidentifier,
	WeddingEventId uniqueidentifier
)

CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[Rsvp](
	[Id] [uniqueidentifier] NOT NULL,
	[CanCome] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Rsvp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) ON [PRIMARY]

GO


CREATE TABLE [dbo].[Meal](
	[Id] [uniqueidentifier] NOT NULL,
	[StarterChoice] [uniqueidentifier] NOT NULL,
	[MainChoice] [uniqueidentifier] NOT NULL,
	[DessertChoice] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Meal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) ON [PRIMARY]

GO


CREATE TABLE [dbo].[Invite](
	[Id] [uniqueidentifier] NOT NULL,
	[EmailAddress] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Invite] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[Invitee](
	[Id] [uniqueidentifier] NOT NULL,
	[Fullname] [nvarchar](max) NULL,
	[IsAdult] [bit] NOT NULL,
	[MealId] [uniqueidentifier] NULL,
	[RsvpId] [uniqueidentifier] NULL,
	[InviteId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Invitee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Invitee]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Invitee_dbo.Invite_InviteId] FOREIGN KEY([InviteId])
REFERENCES [dbo].[Invite] ([Id])
GO

ALTER TABLE [dbo].[Invitee] CHECK CONSTRAINT [FK_dbo.Invitee_dbo.Invite_InviteId]
GO

ALTER TABLE [dbo].[Invitee]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Invitee_dbo.Meal_MealId] FOREIGN KEY([MealId])
REFERENCES [dbo].[Meal] ([Id])
GO

ALTER TABLE [dbo].[Invitee] CHECK CONSTRAINT [FK_dbo.Invitee_dbo.Meal_MealId]
GO

ALTER TABLE [dbo].[Invitee]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Invitee_dbo.Rsvp_RsvpId] FOREIGN KEY([RsvpId])
REFERENCES [dbo].[Rsvp] ([Id])
GO

ALTER TABLE [dbo].[Invitee] CHECK CONSTRAINT [FK_dbo.Invitee_dbo.Rsvp_RsvpId]
GO


