using Catalog.API.Models;
using Microservice.Shared.Dtos;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Response<List<Product>>> GetAllProducts();
        Task<Response<Product>> GetProductById(string id);
        Task<Response<List<Product>>> GetProductByName(string name);
        Task<Response<List<Product>>> GetProductByCategory(string categoryName);

        Task<Response<NoContent>> CreateProduct(Product product);
        Task<Response<NoContent>> DeleteProduct(string id);
        Task<Response<NoContent>> UpdateProduct(Product product);
    }
}
