using Microsoft.AspNetCore.Mvc;
using ProjectManagementApp.Data.Services;

namespace ProjectManagementApp.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IService Service;

        public BaseController(IService service)
        {
            Service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Service.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Service.GetAllAsync();
            return Ok(result);
        }
    }
}
