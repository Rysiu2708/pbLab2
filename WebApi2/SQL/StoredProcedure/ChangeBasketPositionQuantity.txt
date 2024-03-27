CREATE PROCEDURE ChangeBasketPositionQuantity
    @BasketPositionId INT,
    @NewQuantity INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @NewQuantity <= 0
    BEGIN
        RAISERROR('Quantity must be greater than 0.', 16, 1);
        RETURN;
    END

    UPDATE BasketPositions
    SET Amount = @NewQuantity
    WHERE ID = @BasketPositionId;

END