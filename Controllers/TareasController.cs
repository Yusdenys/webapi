using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        protected ITareaServices tareaServices;

        public TareasController(ITareaServices tareaServices)
        {
            this.tareaServices = tareaServices;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareaServices.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            tareaServices.Save(tarea);
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarea tareas)
        {
            tareaServices.Update(id, tareas);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            tareaServices?.Delete(id);
            return Ok();
        }
    }
}
