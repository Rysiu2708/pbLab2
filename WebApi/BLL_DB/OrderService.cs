using BLL_DB.DTOModels;
using BLL_DB.ServiceInterfaces;
using Microsoft.Data.SqlClient;

public class OrderService : IOrderService
{
    public void GenerateOrderFromBasket(int userId)
    {
        executeSql(String.Format("exec dbo.GenerateOrderFromBasket {0}", userId));
    }
    public
 IEnumerable<OrderPositionResponseDTO> GetOrderPositions(int orderId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<OrderResponseDTO> GetOrders(string sortBy, int? orderIdFilter, bool? paidStatusFilter)
    {
        throw new NotImplementedException();
    }

    public void PayOrder(int orderId, decimal amountPaid)
    {
        executeSql(String.Format("exec dbo.PayOrder {0}, {1}", orderId, amountPaid));
    }


    private string executeSql(string sql)
    {
        string output = "";
        using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Lab5_6;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
        {
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        output += reader[i] + ";";
                    }
                    output += '\n';
                }
            }
        }
        return output;
    }
}