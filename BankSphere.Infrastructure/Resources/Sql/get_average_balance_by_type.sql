SELECT 
    [type] AS AccountType,
    AVG(balance) AS AverageBalance
FROM 
    [Product]
WHERE 
    active = @Active
GROUP BY 
    [type];