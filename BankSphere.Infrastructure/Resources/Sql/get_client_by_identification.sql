SELECT 
    c.client_id as Id,
    c.identification as IdentificationNumber, 
    c.[name] AS [Name],
    p.number AS Phone,
    c.person_type as PersonType,
    bc.delegate_name AS DelegateName,
    bc.delegate_identification AS DelegateIdentificationNumber,
    bc.delegate_phone AS DelegatePhone
FROM 
    Client c
INNER JOIN	
    Phone p ON c.client_id = p.client_id
LEFT JOIN 
    Business_Client bc ON c.client_id = bc.client_id
WHERE 
    c.identification = @IdentificationNumber;