using Catalog.API.Models;
using Catalog.API.Repositories.Interfaces;
using Catalog.API.Settings;
using Microservice.Shared.Dtos;
using MongoDB.Driver;
using System.Net;

namespace Catalog.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<Response<NoContent>> Create(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);
            return Response<NoContent>.Success((int)HttpStatusCode.OK);
        }

        public async Task<Response<List<Category>>> GetAll()
        {
            var result = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<Category>>.Success(result, (int)HttpStatusCode.OK);

        }

        public async Task<Response<Category>> GetById(string id)
        {
            var category = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return Response<Category>.Success(category, (int)HttpStatusCode.OK);
        }
    }
}
