CREATE TABLE ReferenceData(
	Id uniqueidentifier,
	Discriminator varchar(255),
	Value varchar(255),
	SecondaryValue varchar(255),
	CONSTRAINT [PK_dbo.ReferenceData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) ON [PRIMARY]

--- Adult meal choices
INSERT INTO ReferenceData VALUES 
(newid(), 'MainChoice', 'Seabass', 'Adult'),
(newid(), 'MainChoice', 'Lamb', 'Adult'),
(newid(), 'MainChoice', 'Tartlet (v)', 'Adult'),
(newid(), 'DessertChoice', 'Brulee (v)', 'Adult'),
(newid(), 'DessertChoice', 'Crumble (v)', 'Adult'),
(newid(), 'StarterChoice', 'Duck', 'Adult'),
(newid(), 'StarterChoice', 'Risotto (v)', 'Adult'),
(newid(), 'WeddingEvent', 'Wedding Breakfast', NULL),
(newid(), 'WeddingEvent', 'Wedding Ceremony', NULL),
(newid(), 'WeddingEvent', 'Evening Reception', NULL),
(newid(), 'WeddingEvent', 'Pub Lunch', NULL)

-- Child meal choices
INSERT INTO ReferenceData VALUES 
(newid(), 'StarterChoice', 'Fruit Juice', 'Child'),
(newid(), 'MainChoice', 'Chicken Nuggets', 'Child'),
(newid(), 'MainChoice', 'Sausages', 'Child'),
(newid(), 'MainChoice', 'Fish Fingers', 'Child'),
(newid(), 'MainChoice', 'Lasagne', 'Child'),
(newid(), 'DessertChoice', 'Ice Cream', 'Child')