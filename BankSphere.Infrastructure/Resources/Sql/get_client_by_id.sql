SELECT 
    c.client_id as Id,
    c.identification as IdentificationNumber, 
    c.[name] AS [Name],
    c.person_type as PersonType
FROM [Client] c
WHERE c.client_id = @ClientId