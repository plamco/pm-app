using Microsoft.AspNetCore.Mvc;
using ProjectManagementApp.Data.Services;
using AppTask = ProjectManagementApp.Data.Models.Task;

namespace ProjectManagementApp.Controllers
{
    public class TasksController : BaseController
    {
        public TasksController(IService service) : base(service)
        {
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AppTask task)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(task);
            }
            else
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}
