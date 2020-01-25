Select * from Counter

UPDATE CounterSquad
SET Name = REPLACE(Name, 'PadmÃ© Amidala', 'Padmé Amidala'),
	LeaderName = REPLACE(LeaderName, 'PadmÃ© Amidala', 'Padmé Amidala'),
	Toon2Name = REPLACE(Toon2Name, 'PadmÃ© Amidala', 'Padmé Amidala'),
	Toon3Name = REPLACE(Toon3Name, 'PadmÃ© Amidala', 'Padmé Amidala'),
	Toon4Name = REPLACE(Toon4Name, 'PadmÃ© Amidala', 'Padmé Amidala'),
	Toon5Name = REPLACE(Toon5Name, 'PadmÃ© Amidala', 'Padmé Amidala'),
	Subs = REPLACE(Subs, 'PadmÃ© Amidala', 'Padmé Amidala'),
	[Description] = REPLACE([Description], 'PadmÃ© Amidala', 'Padmé Amidala'),
	CounterStrategy = REPLACE(CounterStrategy, 'PadmÃ© Amidala', 'Padmé Amidala')

UPDATE Counter
SET [Description] = REPLACE([Description], 'PadmÃ© Amidala', 'Padmé Amidala')