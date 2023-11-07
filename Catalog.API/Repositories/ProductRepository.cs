using Catalog.API.Models;
using Catalog.API.Repositories.Interfaces;
using Microservice.Shared.Dtos;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Response<NoContent>> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<Product>>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<Product>>> GetProductByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Product>> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<Product>>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
