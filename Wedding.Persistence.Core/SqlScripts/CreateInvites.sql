CREATE TABLE [dbo].[Invite](
	[Id] [uniqueidentifier] NOT NULL,
	[EmailAddress] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL
 CONSTRAINT [PK_dbo.Invite] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
