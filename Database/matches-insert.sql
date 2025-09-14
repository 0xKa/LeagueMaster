-- Insert sample data into Matches table
INSERT INTO [dbo].[Matches]
           ([MatchDate]
           ,[Location]
           ,[Stadium]
           ,[HomeTeamScore]
           ,[AwayTeamScore]
           ,[HomeTeamId]
           ,[AwayTeamId]
           ,[CreatedAt]
           ,[UpdatedAt])
VALUES
-- Premier League Matches 2023/2024
('2024-03-03 16:30:00', N'Manchester', N'Etihad Stadium', 3, 1, 2, 3, GETDATE(), GETDATE()), -- Man City vs Man Utd
('2024-03-02 15:00:00', N'London', N'Emirates Stadium', 2, 1, 1, 6, GETDATE(), GETDATE()), -- Arsenal vs Tottenham
('2024-03-02 12:30:00', N'Liverpool', N'Anfield', 4, 0, 4, 5, GETDATE(), GETDATE()), -- Liverpool vs Chelsea
('2024-02-24 17:30:00', N'London', N'Stamford Bridge', 2, 2, 5, 2, GETDATE(), GETDATE()), -- Chelsea vs Man City
('2024-02-17 15:00:00', N'Manchester', N'Old Trafford', 1, 2, 3, 1, GETDATE(), GETDATE()), -- Man Utd vs Arsenal

-- La Liga Matches 2023/2024
('2024-03-03 21:00:00', N'Madrid', N'Santiago Bernabéu', 2, 2, 8, 9, GETDATE(), GETDATE()), -- Real Madrid vs Atlético
('2024-03-02 18:30:00', N'Barcelona', N'Spotify Camp Nou', 1, 0, 7, 10, GETDATE(), GETDATE()), -- Barcelona vs Sevilla
('2024-02-25 16:15:00', N'Madrid', N'Cívitas Metropolitano', 3, 1, 9, 11, GETDATE(), GETDATE()), -- Atlético vs Valencia
('2024-02-18 21:00:00', N'Seville', N'Ramón Sánchez Pizjuán', 0, 3, 10, 8, GETDATE(), GETDATE()), -- Sevilla vs Real Madrid
('2024-02-11 18:30:00', N'Valencia', N'Mestalla', 1, 1, 11, 7, GETDATE(), GETDATE()), -- Valencia vs Barcelona

-- Serie A Matches 2023/2024
('2024-03-03 20:45:00', N'Milan', N'San Siro', 1, 0, 14, 13, GETDATE(), GETDATE()), -- AC Milan vs Inter
('2024-03-02 18:00:00', N'Turin', N'Allianz Stadium', 2, 2, 15, 17, GETDATE(), GETDATE()), -- Juventus vs Roma
('2024-02-25 20:45:00', N'Naples', N'Diego Maradona Stadium', 3, 1, 16, 14, GETDATE(), GETDATE()), -- Napoli vs AC Milan
('2024-02-18 15:00:00', N'Rome', N'Stadio Olimpico', 2, 0, 17, 16, GETDATE(), GETDATE()), -- Roma vs Napoli
('2024-02-11 18:00:00', N'Milan', N'San Siro', 0, 1, 13, 15, GETDATE(), GETDATE()), -- Inter vs Juventus

-- Ligue 1 Matches 2023/2024
('2024-03-03 20:45:00', N'Paris', N'Parc des Princes', 4, 2, 26, 27, GETDATE(), GETDATE()), -- PSG vs Marseille
('2024-03-02 17:00:00', N'Marseille', N'Orange Vélodrome', 3, 0, 27, 28, GETDATE(), GETDATE()), -- Marseille vs Lyon
('2024-02-25 21:00:00', N'Lyon', N'Groupama Stadium', 1, 1, 28, 29, GETDATE(), GETDATE()), -- Lyon vs Monaco
('2024-02-18 17:00:00', N'Monaco', N'Stade Louis II', 2, 2, 29, 30, GETDATE(), GETDATE()), -- Monaco vs Lille
('2024-02-11 16:00:00', N'Lille', N'Stade Pierre-Mauroy', 0, 3, 30, 26, GETDATE(), GETDATE()), -- Lille vs PSG

-- Champions League Matches 2023/2024
('2024-03-12 21:00:00', N'Manchester', N'Etihad Stadium', 2, 1, 2, 8, GETDATE(), GETDATE()), -- Man City vs Real Madrid
('2024-03-13 21:00:00', N'Paris', N'Parc des Princes', 3, 2, 26, 7, GETDATE(), GETDATE()), -- PSG vs Barcelona
('2024-03-05 21:00:00', N'Munich', N'Allianz Arena', 1, 1, 56, 13, GETDATE(), GETDATE()), -- Bayern vs Inter
('2024-03-06 21:00:00', N'Madrid', N'Santiago Bernabéu', 2, 0, 8, 2, GETDATE(), GETDATE()), -- Real Madrid vs Man City
('2024-02-20 21:00:00', N'Milan', N'San Siro', 0, 2, 13, 56, GETDATE(), GETDATE()), -- Inter vs Bayern

-- Brazilian League Matches 2023
('2023-11-05 16:00:00', N'Rio de Janeiro', N'Maracanã', 3, 1, 46, 49, GETDATE(), GETDATE()), -- Flamengo vs São Paulo
('2023-11-04 19:30:00', N'São Paulo', N'Allianz Parque', 2, 0, 47, 50, GETDATE(), GETDATE()), -- Palmeiras vs Corinthians
('2023-10-28 16:00:00', N'Porto Alegre', N'Arena do Grêmio', 1, 1, 51, 52, GETDATE(), GETDATE()), -- Grêmio vs Internacional
('2023-10-21 19:00:00', N'Belo Horizonte', N'Arena MRV', 2, 1, 53, 54, GETDATE(), GETDATE()), -- Atlético Mineiro vs Fluminense
('2023-10-14 16:30:00', N'Rio de Janeiro', N'Nilton Santos', 0, 0, 55, 56, GETDATE(), GETDATE()), -- Botafogo vs Vasco

-- MLS Matches 2023
('2023-10-07 19:30:00', N'Los Angeles', N'Dignity Health Sports Park', 2, 2, 42, 43, GETDATE(), GETDATE()), -- LA Galaxy vs NYCFC
('2023-10-01 17:00:00', N'New York', N'Yankee Stadium', 1, 3, 43, 44, GETDATE(), GETDATE()), -- NYCFC vs Inter Miami
('2023-09-23 16:00:00', N'Miami', N'DRV PNK Stadium', 4, 1, 44, 45, GETDATE(), GETDATE()), -- Inter Miami vs Seattle
('2023-09-16 19:30:00', N'Seattle', N'Lumen Field', 2, 0, 45, 42, GETDATE(), GETDATE()), -- Seattle vs LA Galaxy

-- Derby Matches (Classicos)
('2024-02-10 17:30:00', N'Madrid', N'Santiago Bernabéu', 4, 0, 8, 7, GETDATE(), GETDATE()), -- Real Madrid vs Barcelona (El Clásico)
('2024-01-28 20:45:00', N'Milan', N'San Siro', 0, 1, 13, 14, GETDATE(), GETDATE()), -- Inter vs AC Milan (Derby della Madonnina)
('2024-01-14 16:30:00', N'Manchester', N'Old Trafford', 2, 3, 3, 2, GETDATE(), GETDATE()), -- Man Utd vs Man City (Manchester Derby)
('2023-12-03 15:00:00', N'London', N'Tottenham Hotspur Stadium', 2, 2, 6, 1, GETDATE(), GETDATE()), -- Tottenham vs Arsenal (North London Derby)
('2023-11-12 16:00:00', N'Rio de Janeiro', N'Maracanã', 1, 0, 46, 54, GETDATE(), GETDATE()), -- Flamengo vs Fluminense (Fla-Flu)

-- Recent High-Scoring Matches
('2024-02-03 15:00:00', N'Liverpool', N'Anfield', 5, 1, 4, 6, GETDATE(), GETDATE()), -- Liverpool vs Tottenham
('2024-01-20 18:30:00', N'Barcelona', N'Spotify Camp Nou', 4, 2, 7, 11, GETDATE(), GETDATE()), -- Barcelona vs Valencia
('2024-01-06 17:00:00', N'Paris', N'Parc des Princes', 6, 2, 26, 30, GETDATE(), GETDATE()), -- PSG vs Lille
('2023-12-16 16:00:00', N'Munich', N'Allianz Arena', 3, 0, 56, 15, GETDATE(), GETDATE()), -- Bayern vs Juventus
('2023-12-09 19:30:00', N'São Paulo', N'Morumbi', 3, 3, 49, 47, GETDATE(), GETDATE()); -- São Paulo vs Palmeiras

-- Optional: Display the inserted data with Team names
SELECT 
    m.[MatchDate],
    m.[Location],
    m.[Stadium],
    m.[HomeTeamScore],
    m.[AwayTeamScore],
    m.[HomeTeamId],
    homeTeam.[Name] as HomeTeam,
    m.[AwayTeamId],
    awayTeam.[Name] as AwayTeam,
    m.[CreatedAt],
    m.[UpdatedAt]
FROM [dbo].[Matches] m
INNER JOIN [dbo].[Teams] homeTeam ON m.HomeTeamId = homeTeam.Id
INNER JOIN [dbo].[Teams] awayTeam ON m.AwayTeamId = awayTeam.Id
ORDER BY m.[MatchDate] DESC;
GO