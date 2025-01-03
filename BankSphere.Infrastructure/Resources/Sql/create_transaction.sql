INSERT INTO [Transaction]
(product_id,
[type],
amount)
VALUES 
(@ProductId,
@TransactionType,
@Amount);

-- Obtener el ID de la transacción recién creada
SELECT SCOPE_IDENTITY() AS TransactionId;