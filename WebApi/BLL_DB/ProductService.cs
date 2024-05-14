using BLL_DB.DTOModels;
using BLL_DB.ServiceInterfaces;
using System.Data;
using Microsoft.Data.SqlClient;
public class ProductService : IProductService
{
    string connectionStrin = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lab5_6;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    public void ActivateProduct(int productId)
    {
        executeSql(String.Format("exec dbo.ActivateProduct {0}", productId));
    }

    public void AddProduct(ProductRequestDTO productDTO)
    {
        
            executeSql(String.Format("exec dbo.AddProduct {0}, {1}, {2}", productDTO.Name, productDTO.Price, productDTO.GroupId));
        
    }

    public void DeactivateProduct(int productId)
    {
        
         executeSql(String.Format("exec dbo.DeactivateProduct {0}", productId));
    }

    public void DeleteProduct(int productId)
    {
        
            executeSql(String.Format("delete from dbo.Products where Id = {0}", productId));
       
    }

    public IEnumerable<ProductResponseDTO> GetProducts(string sortBy, string filterByName, string filterByGroupName, int? filterByGroupId, bool includeInactive)
    {
        var products = new List<ProductResponseDTO>();

        using (SqlConnection connection = new SqlConnection(connectionStrin))
        {
            using (SqlCommand command = new SqlCommand("dbo.GetProducts", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@SortBy", sortBy ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@FilterByName", filterByName ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@FilterByGroupName", filterByGroupName ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@FilterByGroupId", filterByGroupId ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@IncludeInactive", includeInactive));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new ProductResponseDTO
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Price = Convert.ToDouble(reader["Price"]),
                            GroupName = reader["GroupName"].ToString()
                        };
                        products.Add(product);
                    }
                }
            }
        }

        return products;
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



  