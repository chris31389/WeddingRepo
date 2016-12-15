CREATE TABLE [dbo].[Rsvp](
	[Id] [uniqueidentifier] NOT NULL,
	[CanCome] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Rsvp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) ON [PRIMARY]

GO