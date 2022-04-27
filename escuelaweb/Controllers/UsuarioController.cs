using escuelaweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace escuelaweb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult Iniciar(Usuario item)
        {
            if (item == null)
            {
                //no llego la info del formulario
                return Content("No hay data del form");
            }
            escuelaContext db = new escuelaContext();
            var user = db.Alumnos.Where(x => x.Usuario.Equals(item.User) && x.Contrasena.Equals(item.Password)).ToList();
            if (user.Count == 0)
            {
                escuelaContext dbD = new escuelaContext();
                var userD = db.Docentes.Where(x => x.Usuario.Equals(item.User) && x.Contrasena.Equals(item.Password)).ToList();
                if (userD.Count == 0)
                {

                }

                //entonces aqui ya solo delimitas por permisos adone queres que vaya
                HttpContext.Session.SetString("username", userD.FirstOrDefault().Usuario);
                var usernameD = HttpContext.Session.GetString("username");
                return Redirect("/EscuelaDocente");
            }

            //entonces aqui ya solo delimitas por permisos adone queres que vaya
            HttpContext.Session.SetString("username", user.FirstOrDefault().Usuario);
            var username = HttpContext.Session.GetString("username");
            return Redirect("/EscuelaAlumno");
        }
    }
}
