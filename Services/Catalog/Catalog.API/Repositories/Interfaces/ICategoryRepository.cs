using Catalog.API.Models;
using Microservice.Shared.Dtos;

namespace Catalog.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Response<NoContent>> Create(Category category);
        Task<Response<List<Category>>> GetAll();
        Task<Response<Category>> GetById(string id);
    }
}
