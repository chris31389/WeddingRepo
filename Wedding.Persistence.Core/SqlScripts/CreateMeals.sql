CREATE TABLE [dbo].[Meal](
	[Id] [uniqueidentifier] NOT NULL,
	[StarterChoiceId] [uniqueidentifier] NOT NULL,
	[MainChoiceId] [uniqueidentifier] NOT NULL,
	[DessertChoiceId] [uniqueidentifier] NOT NULL,
	[DietaryRequirements] varchar(255) NULL,
 CONSTRAINT [PK_dbo.Meal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) ON [PRIMARY]

GO