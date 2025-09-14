-- Insert sample data into Teams table with proper Unicode support
INSERT INTO [dbo].[Teams]
           ([Name]
           ,[City]
           ,[FoundedYear]
           ,[Stadium]
           ,[LeagueId]
           ,[CreatedAt]
           ,[UpdatedAt])
VALUES
-- Premier League Teams (LeagueId 1)
(N'Arsenal', N'London', 1886, N'Emirates Stadium', 1, GETDATE(), GETDATE()),
(N'Manchester City', N'Manchester', 1880, N'Etihad Stadium', 1, GETDATE(), GETDATE()),
(N'Manchester United', N'Manchester', 1878, N'Old Trafford', 1, GETDATE(), GETDATE()),
(N'Liverpool', N'Liverpool', 1892, N'Anfield', 1, GETDATE(), GETDATE()),
(N'Chelsea', N'London', 1905, N'Stamford Bridge', 1, GETDATE(), GETDATE()),
(N'Tottenham Hotspur', N'London', 1882, N'Tottenham Hotspur Stadium', 1, GETDATE(), GETDATE()),

-- La Liga Teams (LeagueId 2)
(N'FC Barcelona', N'Barcelona', 1899, N'Spotify Camp Nou', 2, GETDATE(), GETDATE()),
(N'Real Madrid', N'Madrid', 1902, N'Santiago Bernabéu', 2, GETDATE(), GETDATE()),
(N'Atlético Madrid', N'Madrid', 1903, N'Cívitas Metropolitano', 2, GETDATE(), GETDATE()),
(N'Sevilla', N'Seville', 1890, N'Ramón Sánchez Pizjuán', 2, GETDATE(), GETDATE()),
(N'Valencia', N'Valencia', 1919, N'Mestalla', 2, GETDATE(), GETDATE()),
(N'Villarreal', N'Villarreal', 1923, N'Estadio de la Cerámica', 2, GETDATE(), GETDATE()),

-- Serie A Teams (LeagueId 4)
(N'Inter Milan', N'Milan', 1908, N'San Siro', 4, GETDATE(), GETDATE()),
(N'AC Milan', N'Milan', 1899, N'San Siro', 4, GETDATE(), GETDATE()),
(N'Juventus', N'Turin', 1897, N'Allianz Stadium', 4, GETDATE(), GETDATE()),
(N'Napoli', N'Naples', 1926, N'Diego Armando Maradona Stadium', 4, GETDATE(), GETDATE()),
(N'Roma', N'Rome', 1927, N'Stadio Olimpico', 4, GETDATE(), GETDATE()),
(N'Lazio', N'Rome', 1900, N'Stadio Olimpico', 4, GETDATE(), GETDATE()),

-- Ligue 1 Teams (LeagueId 5)
(N'Paris Saint-Germain', N'Paris', 1970, N'Parc des Princes', 5, GETDATE(), GETDATE()),
(N'Olympique Marseille', N'Marseille', 1899, N'Orange Vélodrome', 5, GETDATE(), GETDATE()),
(N'Lyon', N'Lyon', 1950, N'Groupama Stadium', 5, GETDATE(), GETDATE()),
(N'Monaco', N'Monaco', 1924, N'Stade Louis II', 5, GETDATE(), GETDATE()),
(N'Lille', N'Lille', 1944, N'Stade Pierre-Mauroy', 5, GETDATE(), GETDATE()),

-- Eredivisie Teams (LeagueId 8)
(N'Ajax', N'Amsterdam', 1900, N'Johan Cruyff Arena', 8, GETDATE(), GETDATE()),
(N'PSV Eindhoven', N'Eindhoven', 1913, N'Philips Stadion', 8, GETDATE(), GETDATE()),
(N'Feyenoord', N'Rotterdam', 1908, N'De Kuip', 8, GETDATE(), GETDATE()),
(N'AZ Alkmaar', N'Alkmaar', 1967, N'AFAS Stadion', 8, GETDATE(), GETDATE()),

-- Primeira Liga Teams (LeagueId 9)
(N'Benfica', N'Lisbon', 1904, N'Estádio da Luz', 9, GETDATE(), GETDATE()),
(N'Porto', N'Porto', 1893, N'Estádio do Dragão', 9, GETDATE(), GETDATE()),
(N'Sporting CP', N'Lisbon', 1906, N'Estádio José Alvalade', 9, GETDATE(), GETDATE()),
(N'Braga', N'Braga', 1921, N'Estádio Municipal de Braga', 9, GETDATE(), GETDATE()),

-- Scottish Premiership Teams (LeagueId 10)
(N'Celtic', N'Glasgow', 1888, N'Celtic Park', 10, GETDATE(), GETDATE()),
(N'Rangers', N'Glasgow', 1872, N'Ibrox Stadium', 10, GETDATE(), GETDATE()),
(N'Aberdeen', N'Aberdeen', 1903, N'Pittodrie Stadium', 10, GETDATE(), GETDATE()),

-- MLS Teams (LeagueId 11)
(N'LA Galaxy', N'Los Angeles', 1994, N'Dignity Health Sports Park', 11, GETDATE(), GETDATE()),
(N'New York City FC', N'New York City', 2013, N'Yankee Stadium', 11, GETDATE(), GETDATE()),
(N'Inter Miami CF', N'Miami', 2018, N'DRV PNK Stadium', 11, GETDATE(), GETDATE()),
(N'Seattle Sounders', N'Seattle', 2007, N'Lumen Field', 11, GETDATE(), GETDATE()),

-- Brasileirão Teams (LeagueId 12) - with proper Unicode characters
(N'Flamengo', N'Rio de Janeiro', 1895, N'Maracanã', 12, GETDATE(), GETDATE()),
(N'Palmeiras', N'São Paulo', 1914, N'Allianz Parque', 12, GETDATE(), GETDATE()),
(N'Santos', N'Santos', 1912, N'Vila Belmiro', 12, GETDATE(), GETDATE()),
(N'São Paulo', N'São Paulo', 1930, N'Morumbi', 12, GETDATE(), GETDATE()),
(N'Corinthians', N'São Paulo', 1910, N'Neo Química Arena', 12, GETDATE(), GETDATE()),
(N'Grêmio', N'Porto Alegre', 1903, N'Arena do Grêmio', 12, GETDATE(), GETDATE()),
(N'Internacional', N'Porto Alegre', 1909, N'Beira-Rio', 12, GETDATE(), GETDATE()),
(N'Atlético Mineiro', N'Belo Horizonte', 1908, N'Arena MRV', 12, GETDATE(), GETDATE()),
(N'Cruzeiro', N'Belo Horizonte', 1921, N'Mineirão', 12, GETDATE(), GETDATE()),
(N'Fluminense', N'Rio de Janeiro', 1902, N'Maracanã', 12, GETDATE(), GETDATE()),
(N'Botafogo', N'Rio de Janeiro', 1904, N'Nilton Santos', 12, GETDATE(), GETDATE()),
(N'Vasco da Gama', N'Rio de Janeiro', 1898, N'São Januário', 12, GETDATE(), GETDATE()),

-- UEFA Champions League Teams (LeagueId 14) - Top teams from various leagues
(N'Manchester City', N'Manchester', 1880, N'Etihad Stadium', 14, GETDATE(), GETDATE()),
(N'Real Madrid', N'Madrid', 1902, N'Santiago Bernabéu', 14, GETDATE(), GETDATE()),
(N'Paris Saint-Germain', N'Paris', 1970, N'Parc des Princes', 14, GETDATE(), GETDATE()),
(N'Inter Milan', N'Milan', 1908, N'San Siro', 14, GETDATE(), GETDATE()),
(N'FC Barcelona', N'Barcelona', 1899, N'Spotify Camp Nou', 14, GETDATE(), GETDATE()),
(N'Bayern Munich', N'Munich', 1900, N'Allianz Arena', 14, GETDATE(), GETDATE()),

-- UEFA Europa League Teams (LeagueId 15)
(N'Sevilla', N'Seville', 1890, N'Ramón Sánchez Pizjuán', 15, GETDATE(), GETDATE()),
(N'Liverpool', N'Liverpool', 1892, N'Anfield', 15, GETDATE(), GETDATE()),
(N'Roma', N'Rome', 1927, N'Stadio Olimpico', 15, GETDATE(), GETDATE()),
(N'Ajax', N'Amsterdam', 1900, N'Johan Cruyff Arena', 15, GETDATE(), GETDATE());

-- Optional: Display the inserted data with League names
SELECT 
    t.[Name],
    t.[City],
    t.[FoundedYear],
    t.[Stadium],
    t.[LeagueId],
    l.[Name] as LeagueName,
    l.[Country],
    t.[CreatedAt],
    t.[UpdatedAt]
FROM [dbo].[Teams] t
INNER JOIN [dbo].[Leagues] l ON t.LeagueId = l.Id
ORDER BY l.[Name], t.[Name];
GO