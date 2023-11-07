using Catalog.API.Models;
using Catalog.API.Repositories.Interfaces;
using Catalog.API.Settings;
using Microservice.Shared.Dtos;
using MongoDB.Driver;
using System.Net;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;
        public ProductRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }
        public async Task<Response<NoContent>> CreateProduct(Product product)
        {
            await _productCollection.InsertOneAsync(product);
            return Response<NoContent>.Success((int)HttpStatusCode.Created);
        }

        public Task<Response<bool>> DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<Product>>> GetAllProducts()
        {
            var result = await _productCollection.Find(product => true).ToListAsync();
            return Response<List<Product>>.Success(result, (int)HttpStatusCode.OK);
        }

        public Task<Response<List<Product>>> GetProductByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Product>> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Product>>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
