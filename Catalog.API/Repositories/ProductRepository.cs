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
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }
        public async Task<Response<NoContent>> CreateProduct(Product product)
        {
            await _productCollection.InsertOneAsync(product);
            return Response<NoContent>.Success((int)HttpStatusCode.Created);
        }

        public async Task<Response<NoContent>> DeleteProduct(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.Id == id);

            if(result.DeletedCount > 0)
            {
                return Response<NoContent>.Success((int)HttpStatusCode.NoContent);
            }
            else
            {
                return Response<NoContent>.Fail("Ürün bulunamadı",(int)HttpStatusCode.NotFound);
            }
        }

        public async Task<Response<List<Product>>> GetAllProducts()
        {
            var result = await _productCollection.Find(product => true).ToListAsync();

            if(result.Any())
            {
                foreach(var item in result)
                {
                    item.Category = await _categoryCollection.Find<Category>(x => x.Id == item.CategoryId).FirstAsync();
                }
            }
            else
            {
                result = new List<Product>();
            }

            return Response<List<Product>>.Success(result, (int)HttpStatusCode.OK);
        }

        public Task<Response<List<Product>>> GetProductByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Product>> GetProductById(string id)
        {
            var result = await _productCollection.Find(product => product.Id == id).FirstOrDefaultAsync();
            result.Category = await _categoryCollection.Find(x => x.Id == result.CategoryId).FirstAsync();
            return Response<Product>.Success(result, (int)HttpStatusCode.OK);
        }

        public Task<Response<List<Product>>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<NoContent>> UpdateProduct(Product product)
        {
            var result = await _productCollection.FindOneAndReplaceAsync(p => p.Id == product.Id, product);
            if(result == null) return Response<NoContent>.Fail("Ürün bulunamadı", (int)HttpStatusCode.NoContent);

            return Response<NoContent>.Success((int)HttpStatusCode.NoContent);
        }
    }
}
