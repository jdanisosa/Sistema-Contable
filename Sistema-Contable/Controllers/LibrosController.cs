using Microsoft.AspNetCore.Mvc;
using Sistema_Contable.DB;
using Sistema_Contable.Models;

namespace Sistema_Contable.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
