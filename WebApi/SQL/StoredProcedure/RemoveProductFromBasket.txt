CREATE PROCEDURE RemoveProductFromBasket
    @BasketPositionId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM BasketPositions
    WHERE ID = @BasketPositionId;

END