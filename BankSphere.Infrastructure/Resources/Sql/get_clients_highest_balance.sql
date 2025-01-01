SELECT TOP(10)
P.[type] AS AccountType,
P.balance AS Balance,
C.[name] AS [Name],
C.identification AS IdentificationNumber
FROM [Product] P
INNER JOIN Client C 
ON P.client_id = C.client_id
ORDER BY P.balance desc