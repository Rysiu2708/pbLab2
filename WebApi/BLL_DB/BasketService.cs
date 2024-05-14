using BLL_DB.ServiceInterfaces;
using Microsoft.Data.SqlClient;

public class BasketService : IBasketService
{
    public void AddProductToBasket(int productId, int userId)
    {
       
            executeSql(String.Format("exec dbo.AddProductToBasket {0}, {1}", productId, userId));
       
    }

    public void ChangeBasketPositionQuantity(int basketPositionId, int newQuantity)
    {
        executeSql(String.Format("exec dbo.ChangeBasketPositionQuantity {0}, {1}", basketPositionId, newQuantity));
    }

    public void RemoveProductFromBasket(int basketPositionId)
    {
        executeSql(String.Format("exec dbo.RemoveProductFromBasket {0}", basketPositionId));

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