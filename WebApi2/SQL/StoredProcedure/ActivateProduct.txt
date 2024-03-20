CREATE PROCEDURE ActivateProduct
    @ProductId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
    SET IsActive = 1
    WHERE Id = @ProductId;

END