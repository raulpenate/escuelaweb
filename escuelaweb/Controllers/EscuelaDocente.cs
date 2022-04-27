using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace escuelaweb.Controllers
{
    public class EscuelaDocente : Controller
    {
        // GET: EscuelaDocente
        public ActionResult Index()
        {
            return View();
        }

        // GET: EscuelaDocente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EscuelaDocente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EscuelaDocente/Create
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

        // GET: EscuelaDocente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EscuelaDocente/Edit/5
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

        // GET: EscuelaDocente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EscuelaDocente/Delete/5
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
