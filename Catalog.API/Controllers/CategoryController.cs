using Catalog.API.Models;
using Catalog.API.Repositories.Interfaces;
using Microservice.Shared.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryRepository.GetAll();
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var response = await _categoryRepository.Create(category);
            return CreateActionResultInstance(response);
        }

    }
}
