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
        public ReclamoViewModel Get(int id)
        {
            ReclamosDb db = new ReclamosDb();
            return db.BuscarReclamoPorId(id);
        }

        // POST api/<ReclamosRestController>
        [HttpPost]
        public void Post([FromBody] ReclamoViewModel reclamoViewModel)
        {
            ReclamosDb db = new ReclamosDb();
            db.AltaDeReclamo(reclamoViewModel.Titulo, reclamoViewModel.Descripcion, "nuevo", DateTime.Now);
        }

        // PUT api/<ReclamosRestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ReclamoViewModel reclamoViewModel)
        {
            ReclamosDb db = new ReclamosDb();
            db.ActualizarReclamo(id, reclamoViewModel.Titulo, reclamoViewModel.Descripcion, "nuevo", DateTime.Now);

        }

        // DELETE api/<ReclamosRestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ReclamosDb db = new ReclamosDb();
            db.BorrarReclamo(id);
        }
    }
}
