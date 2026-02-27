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

        [HttpGet]
        public IActionResult Modificar(int id)
        {
            var tarea = _dataContext.Tareas.Where(x => x.Id == id).FirstOrDefault();
   
            
            return View(tarea);
        }

        [HttpPost]
        public IActionResult Modificar(TareaEntity newObj)
        {
            var tarea = _dataContext.Tareas.Where(x => x.Id == newObj.Id).FirstOrDefault();
            tarea.Tarea = newObj.Tarea;
            tarea.Descripcion = newObj.Descripcion;
            _dataContext.Tareas.Update(tarea);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Borrar(int id)
        {
            var tarea = _dataContext.Tareas.Where(x => x.Id == id).FirstOrDefault();
            // Select * from Tarea where id=1

            _dataContext.Tareas.Remove(tarea);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
