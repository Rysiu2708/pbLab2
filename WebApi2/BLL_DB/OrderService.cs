using BLL_DB.DTOModels;
using BLL_DB.ServiceInterfaces;

public class OrderService : IOrderService
{
    public void GenerateOrderFromBasket(int userId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<OrderPositionResponseDTO> GetOrderPositions(int orderId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<OrderResponseDTO> GetOrders(string sortBy, int? orderIdFilter, bool? paidStatusFilter)
    {
        throw new NotImplementedException();
    }

    public void PayOrder(int orderId, decimal amountPaid)
    {
        throw new NotImplementedException();
    }
}