DECLARE @ProductId INT;

INSERT INTO [Product]
(client_id,
[type],
balance
) 
VALUES 
(@ClientId,
@AccountType,
@Balance);

SET @ProductId = SCOPE_IDENTITY();

SELECT @ProductId