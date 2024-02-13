CREATE DATABASE OneToOneDB
GO
USE OneToOneDB
GO

CREATE TABLE Countries(
CountryId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(30) NOT NULL
)

GO
INSERT INTO Countries([Name])
VALUES('Norway'),('Canada'),('Bahamas')

GO

CREATE TABLE Capitals(
CapitalId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(30) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(CountryId),
UNIQUE(CountryId)
)
GO

INSERT INTO Capitals([Name],[CountryId])
VALUES('Oslo',1),('Ottawa',2),('Nassau',3)