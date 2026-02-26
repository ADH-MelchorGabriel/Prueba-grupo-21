using Microsoft.AspNetCore.Mvc;
using Prueba21.WEB.Data;
using Prueba21.WEB.Models;

namespace Prueba21.WEB.Controllers
{
    public class TareasController : Controller
    {

        private readonly DataContext _dataContext;


        public TareasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IActionResult Index()
        {
            var Tareas = _dataContext.Tareas.ToList();
            return View(Tareas);
        }

        
        public IActionResult Nuevo()
        {
            var tarea = new TareaEntity();

            return View(tarea);
        }

        [HttpPost]
        public IActionResult Nuevo(TareaEntity newObj)
        {
            _dataContext.Tareas.Add(newObj);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
