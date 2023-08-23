using Microsoft.AspNetCore.Mvc;
using WebApplicationSistemaReclamosV2.Models.Db;
using WebApplicationSistemaReclamosV2.Models.ViewModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationSistemaReclamosV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamosRestController : ControllerBase
    {
        // GET: api/<ReclamosRestController>
        [HttpGet]
        public IEnumerable<ReclamoViewModel> Get()
        {
            ReclamosDb db = new ReclamosDb();
            return db.BuscarTodoLosReclamos();
        }

        // GET api/<ReclamosRestController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ReclamosDb db = new ReclamosDb();
            ReclamoViewModel reclamoViewModel = db.BuscarReclamoPorId(id);
            if(reclamoViewModel == null)
            {
                return NotFound();
            }
            
            return Ok(reclamoViewModel);
        }

        // POST api/<ReclamosRestController>
        [HttpPost]
        public IActionResult Post([FromBody] ReclamoViewModel reclamoViewModel)
        {
            ReclamosDb db = new ReclamosDb();
            db.AltaDeReclamo(reclamoViewModel.Titulo, reclamoViewModel.Descripcion, "nuevo", DateTime.Now);
            return Created("", reclamoViewModel);
        }

        // PUT api/<ReclamosRestController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReclamoViewModel reclamoViewModel)
        {
            ReclamosDb db = new ReclamosDb();
            db.ActualizarReclamo(id, reclamoViewModel.Titulo, reclamoViewModel.Descripcion, "nuevo", DateTime.Now);
            return NoContent();
        }

        // DELETE api/<ReclamosRestController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ReclamosDb db = new ReclamosDb();
            db.BorrarReclamo(id);
            return NoContent();
        }
    }
}
