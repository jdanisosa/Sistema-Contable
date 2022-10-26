using Microsoft.AspNetCore.Mvc;
using Sistema_Contable.DB;
using Sistema_Contable.Models;

namespace Sistema_Contable.Controllers
{
    public class NomenclaturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        int? id_grupo_aux = 0;

        public NomenclaturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GrupoContable()
        {
            IEnumerable<Grupo_Contable> ListaGrupos = _context.Grupo_Contables;
            return View(ListaGrupos);
        }

        [HttpGet]
        public IActionResult CreateGrupo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGrupo(Grupo_Contable grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Grupo_Contables.Add(grupo);
                _context.SaveChanges();
                return RedirectToAction("GrupoContable");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditarGrupo(int? Id_Grupo_Contable)
        {
            var grupo = _context.Grupo_Contables.Find(Id_Grupo_Contable);

            if (Id_Grupo_Contable.HasValue == false)
            {
                TempData["ErrorTitle"] = "Error!";
                TempData["ErrorDescription"] = "No se encontro la división";
                TempData["ErrorCode"] = "404";
                return RedirectToAction("ErrorPage", "Home");
            }
            else
            {
                return View(grupo);
            }
        }

        [HttpPost]
        public IActionResult EditarGrupo(Grupo_Contable grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(grupo);
                _context.SaveChanges();
                return RedirectToAction("GrupoContable");

            }
            return View();
        }

        [HttpGet]
        public IActionResult EliminarGrupo(int? Id_Grupo_Contable)
        {
            var grupo = _context.Grupo_Contables.Find(Id_Grupo_Contable);

            if (Id_Grupo_Contable.HasValue == false)
            {
                TempData["ErrorTitle"] = "Error!";
                TempData["ErrorDescription"] = "No se encontro la división";
                TempData["ErrorCode"] = "404";
                return RedirectToAction("ErrorPage", "Home");
            }

            var subgrupos = from cg in _context.Clasificacion_Grupos where cg.Id_Grupo_Contable == Id_Grupo_Contable select cg;

            if (subgrupos.Count() > 0)
            {
                TempData["ErrorTitle"] = "Error!";
                TempData["ErrorDescription"] = "No se puede eliminar la división porque hay subdivisiones asociadas a ella.";
                TempData["ErrorCode"] = 403;
                return RedirectToAction("ErrorPage", "Home");
            }
            else
            {
                return View(grupo);
            }
        }

        [HttpPost]
        public IActionResult EliminarGrupo(Grupo_Contable grupo)
        {
            try
            {
                _context.Grupo_Contables.Remove(grupo);
                _context.SaveChanges();
                return RedirectToAction("GrupoContable");
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public IActionResult SubGrupoContable(int? Id_Grupo_Contable)
        {
            var subgrupos = from cg in _context.Clasificacion_Grupos where cg.Id_Grupo_Contable == Id_Grupo_Contable select cg;
            id_grupo_aux = Id_Grupo_Contable;

            return View(subgrupos);
        }

        [HttpGet]
        public IActionResult CreateSubGrupo()
        {
            return View();
        }
    }
}
