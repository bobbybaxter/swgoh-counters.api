Select * from Counter

UPDATE CounterSquad
SET Name = REPLACE(Name, 'Padmé Amidala', 'Padm� Amidala'),
	LeaderName = REPLACE(LeaderName, 'Padmé Amidala', 'Padm� Amidala'),
	Toon2Name = REPLACE(Toon2Name, 'Padmé Amidala', 'Padm� Amidala'),
	Toon3Name = REPLACE(Toon3Name, 'Padmé Amidala', 'Padm� Amidala'),
	Toon4Name = REPLACE(Toon4Name, 'Padmé Amidala', 'Padm� Amidala'),
	Toon5Name = REPLACE(Toon5Name, 'Padmé Amidala', 'Padm� Amidala'),
	Subs = REPLACE(Subs, 'Padmé Amidala', 'Padm� Amidala'),
	[Description] = REPLACE([Description], 'Padmé Amidala', 'Padm� Amidala'),
	CounterStrategy = REPLACE(CounterStrategy, 'Padmé Amidala', 'Padm� Amidala')

UPDATE Counter
SET [Description] = REPLACE([Description], 'Padmé Amidala', 'Padm� Amidala')