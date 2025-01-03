SELECT
product_id AS ProductId,
client_id AS ClientId,
[type] AS AccountType,
balance AS Balance,
opening_date AS OpeningDate,
active AS Active
FROM [Product] 
WHERE 
client_id = @ClientId and [type] = @AccountType and active = @Active