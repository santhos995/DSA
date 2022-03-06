--https://www.educative.io/courses/introductory-guide-to-sql/q2xxJrxq8BG

-- The lesson queries are reproduced below for convenient copy/paste into the terminal. 

-- Query 1
SELECT FirstName
FROM Actors
INNER JOIN DigitalAssets
ON Id=ActorId 
AND MONTH(DoB) = MONTH(LastUpdatedOn) 
AND DAY(DoB) = DAY(LastUpdatedOn);

-- Query 2
SELECT FirstName
FROM Actors 
WHERE (Id, MONTH(DoB), DAY(DoB))
IN ( SELECT ActorId, MONTH(LastUpdatedOn), DAY(LastUpdatedOn)
     FROM DigitalAssets);

--Query 3
SELECT ActorId, AssetType, LastUpdatedOn FROM DigitalAssets;

-- Query 4
SELECT FirstName, AssetType, LastUpdatedOn 
FROM Actors  
INNER JOIN (SELECT ActorId, AssetType, LastUpdatedOn 
            FROM DigitalAssets) AS tbl 
ON ActorId = Id;

-- Query 5
SELECT FirstName, AssetType, LastUpdatedOn 
FROM Actors 
INNER JOIN (SELECT ActorId, AssetType, LastUpdatedOn 
            FROM DigitalAssets) AS tbl 
ON ActorId = Id
WHERE FirstName = "Kim";

-- Query 6
SELECT FirstName, AssetType, LastUpdatedOn 
FROM Actors 
INNER JOIN (SELECT ActorId, AssetType, LastUpdatedOn 
            FROM DigitalAssets) AS tbl 
ON ActorId = Id
WHERE FirstName = "Kim"
ORDER BY LastUpdatedOn DESC LIMIT 1;


--https://www.educative.io/courses/introductory-guide-to-sql/N0VOQv31pG2
-- The lesson queries are reproduced below for convenient copy/paste into the terminal. 

-- Query 1
SELECT URL AS "Brad's Insta Page" 
FROM Actors 
INNER JOIN DigitalAssets 
WHERE AssetType = "Instagram" AND FirstName  ="Brad";

-- Query 2
SELECT URL 
FROM DigitalAssets 
WHERE AssetType = "Instagram" AND 
ActorId = (SELECT Id 
           FROM Actors 
           WHERE FirstName = "Brad");

-- Query 3
SELECT FirstName 
FROM Actors 
INNER JOIN DigitalAssets 
ON ActorId = Id 
WHERE LastUpdatedOn = (SELECT MAX(LastUpdatedOn) 
                       FROM DigitalAssets);

--https://www.educative.io/courses/introductory-guide-to-sql/xo6PpLM022r
-- The lesson queries are reproduced below for convenient copy/paste into the terminal. 

-- Query 1
SELECT * FROM Actors 
INNER JOIN DigitalAssets ON ActorId=Id 
WHERE AssetType = ANY (SELECT DISTINCT AssetType 
                       FROM DigitalAssets
                       WHERE AssetType != 'Website');

-- Query 2
SELECT * FROM Actors 
INNER JOIN DigitalAssets ON ActorId=Id 
WHERE AssetType != 'Website';

-- Query 3
SELECT FirstName, SecondName
FROM Actors
WHERE Id = ANY (SELECT ActorId
                FROM DigitalAssets
                WHERE AssetType = 'Facebook');

-- Query 4
SELECT FirstName, SecondName
FROM Actors
WHERE Id IN (SELECT ActorId
             FROM DigitalAssets
             WHERE AssetType = 'Facebook');

-- Query 5
SELECT FirstName, SecondName 
FROM Actors 
WHERE NetworthInMillions > ALL (SELECT NetworthInMillions 
                                FROM Actors
                                WHERE FirstName LIKE "j%");
                                