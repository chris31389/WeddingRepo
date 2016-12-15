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


