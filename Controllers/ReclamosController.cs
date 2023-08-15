using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSistemaReclamosV2.Models.ViewModels;

namespace WebApplicationSistemaReclamosV2.Controllers
{
    public class ReclamosController : Controller
    {
        // GET: ReclamosController1cs
        public ActionResult Index()
        {
            List<ReclamoViewModel> listReclamos = new List<ReclamoViewModel>();
            listReclamos.Add(new ReclamoViewModel(1, "Ejemplo1", "Desc1", DateTime.Now, "nuevo"));
            listReclamos.Add(new ReclamoViewModel(2, "Ejemplo2", "Desc2", DateTime.Now, "nuevo"));
            listReclamos.Add(new ReclamoViewModel(3, "Ejemplo3", "Desc3", DateTime.Now, "nuevo"));

            return View(listReclamos);
        }

        // GET: ReclamosController1cs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReclamosController1cs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReclamosController1cs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReclamosController1cs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReclamosController1cs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReclamosController1cs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}
