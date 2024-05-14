CREATE PROCEDURE GenerateOrderFromBasket
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;


    DECLARE @NewOrderId INT;
    INSERT INTO Orders (UserID, Date, IsPayed)
    VALUES (@UserId, GETDATE(), 0); 

    SET @NewOrderId = SCOPE_IDENTITY(); 


    INSERT INTO OrderPositions(OrderID, Amount,Price, ProductID)
    SELECT @NewOrderId, Amount, (select price from Products where id = ProductID), ProductID
    FROM BasketPositions
    WHERE UserID = @UserId;

    DELETE FROM BasketPositions
    WHERE UserID = @UserId;

    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('Failed to generate order from basket.', 16, 1);
        RETURN;
    END

END