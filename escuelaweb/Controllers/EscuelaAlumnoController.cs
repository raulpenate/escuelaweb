using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace escuelaweb.Controllers
{
    public class EscuelaAlumnoController : Controller
    {
        // GET: EscuelaAlumnoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EscuelaAlumnoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EscuelaAlumnoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EscuelaAlumnoController/Create
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

        // GET: EscuelaAlumnoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EscuelaAlumnoController/Edit/5
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

        // GET: EscuelaAlumnoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EscuelaAlumnoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
