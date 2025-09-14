-- Insert sample data into Players table with proper Unicode support
INSERT INTO [dbo].[Players]
           ([FirstName]
           ,[LastName]
           ,[DateOfBirth]
           ,[Nationality]
           ,[Position]
           ,[ShirtNumber]
           ,[TeamId]
           ,[CreatedAt]
           ,[UpdatedAt])
VALUES
-- Manchester City Players (TeamId from previous insert)
(N'Erling', N'Haaland', '2000-07-21', N'Norway', 4, 9, 2, GETDATE(), GETDATE()),
(N'Kevin', N'De Bruyne', '1991-06-28', N'Belgium', 3, 17, 2, GETDATE(), GETDATE()),
(N'Phil', N'Foden', '2000-05-28', N'England', 3, 47, 2, GETDATE(), GETDATE()),
(N'Rúben', N'Dias', '1997-05-14', N'Portugal', 2, 3, 2, GETDATE(), GETDATE()),
(N'Ederson', N'Moraes', '1993-08-17', N'Brazil', 1, 31, 2, GETDATE(), GETDATE()),

-- Arsenal Players
(N'Bukayo', N'Saka', '2001-09-05', N'England', 4, 7, 1, GETDATE(), GETDATE()),
(N'Martin', N'Ødegaard', '1998-12-17', N'Norway', 3, 8, 1, GETDATE(), GETDATE()),
(N'Gabriel', N'Jesus', '1997-04-03', N'Brazil', 4, 9, 1, GETDATE(), GETDATE()),
(N'William', N'Saliba', '2001-03-24', N'France', 2, 2, 1, GETDATE(), GETDATE()),
(N'Aaron', N'Ramsdale', '1998-05-14', N'England', 1, 1, 1, GETDATE(), GETDATE()),

-- Real Madrid Players
(N'Jude', N'Bellingham', '2003-06-29', N'England', 3, 5, 8, GETDATE(), GETDATE()),
(N'Vinícius', N'Júnior', '2000-07-12', N'Brazil', 4, 7, 8, GETDATE(), GETDATE()),
(N'Thibaut', N'Courtois', '1992-05-11', N'Belgium', 1, 1, 8, GETDATE(), GETDATE()),
(N'Toni', N'Kroos', '1990-01-04', N'Germany', 3, 8, 8, GETDATE(), GETDATE()),
(N'Luka', N'Modrić', '1985-09-09', N'Croatia', 3, 10, 8, GETDATE(), GETDATE()),

-- FC Barcelona Players
(N'Robert', N'Lewandowski', '1988-08-21', N'Poland', 4, 9, 7, GETDATE(), GETDATE()),
(N'Pedri', N'González', '2002-11-25', N'Spain', 3, 8, 7, GETDATE(), GETDATE()),
(N'Gavi', N'', '2004-08-05', N'Spain', 3, 6, 7, GETDATE(), GETDATE()),
(N'Marc-André', N'ter Stegen', '1992-04-30', N'Germany', 1, 1, 7, GETDATE(), GETDATE()),
(N'Ronald', N'Araújo', '1999-03-07', N'Uruguay', 2, 4, 7, GETDATE(), GETDATE()),

-- Paris Saint-Germain Players
(N'Kylian', N'Mbappé', '1998-12-20', N'France', 4, 7, 26, GETDATE(), GETDATE()),
(N'Neymar', N'Jr', '1992-02-05', N'Brazil', 4, 10, 26, GETDATE(), GETDATE()),
(N'Lionel', N'Messi', '1987-06-24', N'Argentina', 4, 30, 26, GETDATE(), GETDATE()),
(N'Marquinhos', N'', '1994-05-14', N'Brazil', 2, 5, 26, GETDATE(), GETDATE()),
(N'Gianluigi', N'Donnarumma', '1999-02-25', N'Italy', 1, 99, 26, GETDATE(), GETDATE()),

-- Bayern Munich Players (assuming they're in Champions League team)
(N'Harry', N'Kane', '1993-07-28', N'England', 4, 9, 56, GETDATE(), GETDATE()),
(N'Joshua', N'Kimmich', '1995-02-08', N'Germany', 3, 6, 56, GETDATE(), GETDATE()),
(N'Thomas', N'Müller', '1989-09-13', N'Germany', 4, 25, 56, GETDATE(), GETDATE()),
(N'Manuel', N'Neuer', '1986-03-27', N'Germany', 1, 1, 56, GETDATE(), GETDATE()),
(N'Leroy', N'Sané', '1996-01-11', N'Germany', 4, 10, 56, GETDATE(), GETDATE()),

-- Brazilian Teams Players (Flamengo)
(N'Gabriel', N'Barbosa', '1996-08-30', N'Brazil', 4, 9, 37, GETDATE(), GETDATE()),
(N'Éverton', N'Ribeiro', '1989-04-10', N'Brazil', 3, 7, 37, GETDATE(), GETDATE()),
(N'Filipe', N'Luís', '1985-08-09', N'Brazil', 2, 16, 37, GETDATE(), GETDATE()),
(N'David', N'Luiz', '1987-04-22', N'Brazil', 2, 23, 37, GETDATE(), GETDATE()),
(N'Santos', N'', '1990-03-17', N'Brazil', 1, 1, 37, GETDATE(), GETDATE()),

-- São Paulo Players
(N'Luciano', N'da Rocha', '1993-05-18', N'Brazil', 4, 10, 40, GETDATE(), GETDATE()),
(N'James', N'Rodríguez', '1991-07-12', N'Colombia', 3, 19, 40, GETDATE(), GETDATE()),
(N'Rafinha', N'', '1985-09-07', N'Brazil', 2, 13, 40, GETDATE(), GETDATE()),
(N'Wellington', N'Rato', '1991-07-07', N'Brazil', 3, 27, 40, GETDATE(), GETDATE()),
(N'Jandrei', N'', '1993-03-01', N'Brazil', 1, 93, 40, GETDATE(), GETDATE()),

-- Young Prospects
(N'Jude', N'Bellingham', '2003-06-29', N'England', 3, 5, 8, GETDATE(), GETDATE()),
(N'Gavi', N'', '2004-08-05', N'Spain', 3, 6, 7, GETDATE(), GETDATE()),
(N'Jamal', N'Musiala', '2003-02-26', N'Germany', 3, 42, 56, GETDATE(), GETDATE()),
(N'Eduardo', N'Camavinga', '2002-11-10', N'France', 3, 12, 8, GETDATE(), GETDATE()),
(N'Ansu', N'Fati', '2002-10-31', N'Spain', 4, 10, 7, GETDATE(), GETDATE()),

-- Veteran Players
(N'Cristiano', N'Ronaldo', '1985-02-05', N'Portugal', 4, 7, 8, GETDATE(), GETDATE()),
(N'Luka', N'Modrić', '1985-09-09', N'Croatia', 3, 10, 8, GETDATE(), GETDATE()),
(N'Thiago', N'Silva', '1984-09-22', N'Brazil', 2, 6, 5, GETDATE(), GETDATE()),
(N'Manuel', N'Neuer', '1986-03-27', N'Germany', 1, 1, 56, GETDATE(), GETDATE()),
(N'Robert', N'Lewandowski', '1988-08-21', N'Poland', 4, 9, 7, GETDATE(), GETDATE());

-- Optional: Display the inserted data with Team names
SELECT 
    p.[FirstName],
    p.[LastName],
    p.[DateOfBirth],
    p.[Nationality],
    CASE p.[Position]
        WHEN 1 THEN 'Goalkeeper'
        WHEN 2 THEN 'Defender'
        WHEN 3 THEN 'Midfielder'
        WHEN 4 THEN 'Forward'
        ELSE 'Unknown'
    END as Position,
    p.[ShirtNumber],
    p.[TeamId],
    t.[Name] as TeamName,
    p.[CreatedAt],
    p.[UpdatedAt]
FROM [dbo].[Players] p
INNER JOIN [dbo].[Teams] t ON p.TeamId = t.Id
ORDER BY t.[Name], p.[ShirtNumber];
GO