CREATE PROCEDURE DeactivateProduct
    @ProductId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM OrderPositions od
        INNER JOIN Orders o ON od.OrderId = o.Id
        WHERE od.ProductId = @ProductId AND o.IsPayed = 0
    )
    BEGIN
        RAISERROR('Product is associated with unpaid orders and cannot be deactivated.', 16, 1);
        RETURN;
    END

    UPDATE Products
    SET IsActive = 0
    WHERE Id = @ProductId;
END