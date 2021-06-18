using System.Threading.Tasks;
using AspTodo.Core.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AspTodo.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class TodosController : Controller
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoService.GetAllAsync();

            return Ok(todos);
        }
    }
}