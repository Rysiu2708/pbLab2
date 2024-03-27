using BLL_DB.ServiceInterfaces;

public class BasketService : IBasketService
{
    public void AddProductToBasket(int productId, int userId)
    {
        throw new NotImplementedException();
    }

    public void ChangeBasketPositionQuantity(int basketPositionId, int newQuantity)
    {
        throw new NotImplementedException();
    }

    public void RemoveProductFromBasket(int basketPositionId)
    {
        throw new NotImplementedException();
    }
}