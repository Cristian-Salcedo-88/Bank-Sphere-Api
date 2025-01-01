UPDATE [Product]
SET
balance = @Balance,
active = @Active
WHERE 
product_id = @ProducId;