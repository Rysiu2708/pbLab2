using BLL_DB.DTOModels;
using BLL_DB.ServiceInterfaces;

public class ProductService : IProductService
{
    public void ActivateProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(ProductRequestDTO productDTO)
    {
        throw new NotImplementedException();
    }

    public void DeactivateProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductResponseDTO> GetProducts(string sortBy, string filterByName, string filterByGroupName, int? filterByGroupId, bool includeInactive)
    {
        throw new NotImplementedException();
    }
}