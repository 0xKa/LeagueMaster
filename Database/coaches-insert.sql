-- Insert sample data into Coaches table with proper Unicode support
INSERT INTO [dbo].[Coaches]
           ([FirstName]
           ,[LastName]
           ,[Nationality]
           ,[DateOfBirth]
           ,[ExperienceYears]
           ,[TeamId]
           ,[CreatedAt]
           ,[UpdatedAt])
VALUES
-- Premier League Coaches
(N'Pep', N'Guardiola', N'Spain', '1971-01-18', 18, 2, GETDATE(), GETDATE()), -- Manchester City
(N'Mikel', N'Arteta', N'Spain', '1982-03-26', 5, 1, GETDATE(), GETDATE()), -- Arsenal
(N'Erik', N'ten Hag', N'Netherlands', '1970-02-02', 15, 3, GETDATE(), GETDATE()), -- Manchester United
(N'Jürgen', N'Klopp', N'Germany', '1967-06-16', 22, 4, GETDATE(), GETDATE()), -- Liverpool
(N'Mauricio', N'Pochettino', N'Argentina', '1972-03-02', 14, 5, GETDATE(), GETDATE()), -- Chelsea
(N'Ange', N'Postecoglou', N'Australia', '1965-08-27', 28, 6, GETDATE(), GETDATE()), -- Tottenham

-- La Liga Coaches
(N'Carlo', N'Ancelotti', N'Italy', '1959-06-10', 30, 8, GETDATE(), GETDATE()), -- Real Madrid
(N'Xavi', N'Hernández', N'Spain', '1980-01-25', 3, 7, GETDATE(), GETDATE()), -- Barcelona
(N'Diego', N'Simeone', N'Argentina', '1970-04-28', 20, 9, GETDATE(), GETDATE()), -- Atlético Madrid
(N'Quique', N'Sánchez Flores', N'Spain', '1965-02-05', 18, 10, GETDATE(), GETDATE()), -- Sevilla
(N'Rubén', N'Baraja', N'Spain', '1975-07-11', 4, 11, GETDATE(), GETDATE()), -- Valencia

-- Serie A Coaches
(N'Simone', N'Inzaghi', N'Italy', '1976-04-05', 7, 13, GETDATE(), GETDATE()), -- Inter Milan
(N'Stefano', N'Pioli', N'Italy', '1965-10-20', 15, 14, GETDATE(), GETDATE()), -- AC Milan
(N'Massimiliano', N'Allegri', N'Italy', '1967-08-11', 19, 15, GETDATE(), GETDATE()), -- Juventus
(N'Francesco', N'Calzona', N'Italy', '1968-05-27', 8, 16, GETDATE(), GETDATE()), -- Napoli
(N'Daniele', N'De Rossi', N'Italy', '1983-07-24', 1, 17, GETDATE(), GETDATE()), -- Roma

-- Ligue 1 Coaches
(N'Luis', N'Enrique', N'Spain', '1970-05-08', 10, 26, GETDATE(), GETDATE()), -- PSG
(N'Jean-Louis', N'Gasset', N'France', '1953-12-09', 30, 27, GETDATE(), GETDATE()), -- Marseille
(N'Pierre', N'Sage', N'France', '1984-02-07', 2, 28, GETDATE(), GETDATE()), -- Lyon
(N'Adi', N'Hütter', N'Austria', '1970-02-11', 12, 29, GETDATE(), GETDATE()), -- Monaco
(N'Paulo', N'Fonseca', N'Portugal', '1973-03-05', 14, 30, GETDATE(), GETDATE()), -- Lille

-- Eredivisie Coaches
(N'John', N'van t Schip', N'Netherlands', '1963-12-29', 20, 31, GETDATE(), GETDATE()), -- Ajax
(N'Peter', N'Bosz', N'Netherlands', '1963-11-21', 15, 32, GETDATE(), GETDATE()), -- PSV
(N'Arne', N'Slot', N'Netherlands', '1978-09-17', 6, 33, GETDATE(), GETDATE()), -- Feyenoord
(N'Pascal', N'Jansen', N'Netherlands', '1973-01-04', 8, 34, GETDATE(), GETDATE()), -- AZ Alkmaar

-- Primeira Liga Coaches
(N'Roger', N'Schmidt', N'Germany', '1967-03-13', 16, 35, GETDATE(), GETDATE()), -- Benfica
(N'Sérgio', N'Conceição', N'Portugal', '1974-11-15', 9, 36, GETDATE(), GETDATE()), -- Porto
(N'Rúben', N'Amorim', N'Portugal', '1985-01-27', 5, 37, GETDATE(), GETDATE()), -- Sporting CP
(N'Artur', N'Jorge', N'Portugal', '1972-02-13', 12, 38, GETDATE(), GETDATE()), -- Braga

-- Scottish Premiership Coaches
(N'Brendan', N'Rodgers', N'Ireland', '1973-01-26', 16, 39, GETDATE(), GETDATE()), -- Celtic
(N'Philippe', N'Clement', N'Belgium', '1974-03-22', 8, 40, GETDATE(), GETDATE()), -- Rangers
(N'Neil', N'Warnock', N'England', '1948-12-01', 42, 41, GETDATE(), GETDATE()), -- Aberdeen

-- MLS Coaches
(N'Greg', N'Vanney', N'USA', '1974-06-11', 10, 42, GETDATE(), GETDATE()), -- LA Galaxy
(N'Nick', N'Cushing', N'England', '1985-04-09', 6, 43, GETDATE(), GETDATE()), -- NYCFC
(N'Gerardo', N'Martino', N'Argentina', '1962-11-20', 25, 44, GETDATE(), GETDATE()), -- Inter Miami
(N'Brian', N'Schmetzer', N'USA', '1962-03-18', 20, 45, GETDATE(), GETDATE()), -- Seattle Sounders

-- Brazilian Coaches
(N'Tite', N'', N'Brazil', '1961-05-25', 25, 46, GETDATE(), GETDATE()), -- Flamengo
(N'Abel', N'Ferreira', N'Portugal', '1978-12-22', 7, 47, GETDATE(), GETDATE()), -- Palmeiras
(N'Fábio', N'Carille', N'Brazil', '1973-12-26', 12, 48, GETDATE(), GETDATE()), -- Santos
(N'Thiago', N'Carpini', N'Brazil', '1984-03-05', 4, 49, GETDATE(), GETDATE()), -- São Paulo
(N'António', N'Oliveira', N'Portugal', '1972-06-10', 15, 50, GETDATE(), GETDATE()), -- Corinthians
(N'Renato', N'Gaúcho', N'Brazil', '1962-09-09', 22, 51, GETDATE(), GETDATE()), -- Grêmio
(N'Eduardo', N'Coudet', N'Argentina', '1974-09-12', 9, 52, GETDATE(), GETDATE()), -- Internacional
(N'Gabriel', N'Milito', N'Argentina', '1980-09-07', 5, 53, GETDATE(), GETDATE()), -- Atlético Mineiro
(N'Fernando', N'Diniz', N'Brazil', '1974-03-27', 10, 54, GETDATE(), GETDATE()), -- Fluminense
(N'Tiago', N'Nunes', N'Brazil', '1980-03-05', 8, 55, GETDATE(), GETDATE()), -- Botafogo
(N'Ramon', N'Menezes', N'Brazil', '1972-06-30', 6, 56, GETDATE(), GETDATE()), -- Vasco da Gama

-- UEFA Competitions Coaches
(N'Pep', N'Guardiola', N'Spain', '1971-01-18', 18, 57, GETDATE(), GETDATE()), -- Man City (UCL)
(N'Carlo', N'Ancelotti', N'Italy', '1959-06-10', 30, 58, GETDATE(), GETDATE()), -- Real Madrid (UCL)
(N'Luis', N'Enrique', N'Spain', '1970-05-08', 10, 59, GETDATE(), GETDATE()), -- PSG (UCL)
(N'Simone', N'Inzaghi', N'Italy', '1976-04-05', 7, 60, GETDATE(), GETDATE()) -- Inter (UCL)

-- Optional: Display the inserted data with Team names
SELECT 
    c.[FirstName],
    c.[LastName],
    c.[Nationality],
    c.[DateOfBirth],
    c.[ExperienceYears],
    c.[TeamId],
    t.[Name] as TeamName,
    c.[CreatedAt],
    c.[UpdatedAt]
FROM [dbo].[Coaches] c
INNER JOIN [dbo].[Teams] t ON c.TeamId = t.Id
ORDER BY t.[Name];
GO