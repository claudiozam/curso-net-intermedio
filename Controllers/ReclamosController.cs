using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSistemaReclamosV2.Models.Db;
using WebApplicationSistemaReclamosV2.Models.ViewModels;

namespace WebApplicationSistemaReclamosV2.Controllers
{
    public class ReclamosController : Controller
    {
        // GET: ReclamosController1cs
        public ActionResult Index()
        {
            ReclamosDb db = new ReclamosDb();
            List<ReclamoViewModel> listReclamos = db.BuscarTodoLosReclamos();
            return View(listReclamos);
        }

        // GET: ReclamosController1cs/Details/5
        public ActionResult Details(int id)
        {
            ReclamosDb db = new ReclamosDb();
            ReclamoViewModel reclamoViewModel = db.BuscarReclamoPorId(id);
            return View(reclamoViewModel);
        }

        // GET: ReclamosController1cs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReclamosController1cs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReclamoViewModel reclamoViewModel)
        {
            if(ModelState.IsValid)
            {
                ReclamosDb db = new ReclamosDb();
                db.AltaDeReclamo(
                    reclamoViewModel.Titulo,
                    reclamoViewModel.Descripcion,
                    "nuevo",
                    DateTime.Now
                );

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: ReclamosController1cs/Edit/5
        public ActionResult Edit(int id)
        {
            ReclamosDb db = new ReclamosDb();
            ReclamoViewModel reclamoViewModel = db.BuscarReclamoPorId(id);

            return View(reclamoViewModel);
        }

        // POST: ReclamosController1cs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReclamoViewModel reclamoViewModel)
        {
            if(ModelState.IsValid)
            {
                ReclamosDb db = new ReclamosDb();
                db.ActualizarReclamo(id,
                    reclamoViewModel.Titulo,
                    reclamoViewModel.Descripcion,
                    "nuevo",
                    DateTime.Now
                );
                return RedirectToAction(nameof(Index));
            }
            return View(reclamoViewModel);
        }

        // GET: ReclamosController1cs/Delete/5
        public ActionResult Delete(int id)
        {
            ReclamosDb db = new ReclamosDb();
            db.BorrarReclamo(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Ejemplo()
        {
            return View();
        }
    }
}
