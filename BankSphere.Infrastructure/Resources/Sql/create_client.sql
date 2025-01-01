DECLARE @ClientId INT;

INSERT INTO Client 
([identification], [name], [person_type]) 
VALUES 
(
@IdentificationNumber,
@Name,
@PersonType);

SET @ClientId = SCOPE_IDENTITY();

INSERT INTO Phone 
([client_id],
[number],
[country_code])
VALUES 
(@ClientId,
@Phone,
@CountryCode);

SELECT @ClientId AS ClientId;				