using IvanRetoCurso.Database;
using IvanRetoCurso.Models;
using IvanRetoCurso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IvanRetoCurso.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new EmpleadoViewModel();
            model.datos = EmpleadoService.getAll();
            return View(model);
        }

        public ActionResult Agregar()
        {
            var model = new PosicionesViewModel();
            model.datos = EmpleadoService.getAllP();

            // Transformar a un SelectListItem como los necesita el DropDownList
            List<SelectListItem> items = model.datos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Name.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;

            return View();
        }

        [HttpPost]
        public ActionResult Guardar(EmpleadoViewModel model)
        {
            var DateAndTime = DateTime.Now; //Obtiene la fecha actual

            var empleado = new EmployeesIvan()
            {
                CreationDate = DateAndTime,
                Name = model.Name,
                LastName = model.LastName,
                Birhtday = model.Birthday,
                RCF = model.RFC,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PositionId = model.PositionId,
                IsDeleted = false
            };
            
            EmpleadoService.Agregar(empleado);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            //Crear el metodo para buscar los datos del empleado (service)
            var model = EmpleadoService.Buscar(id);
            var DateAndTime = DateTime.Now; //Obtiene la fecha actual
            //Crear el view model con los datos del empleado
            var empleado = new EmpleadoViewModel()
            {
                Id = model.Id,
                CreationDate = DateAndTime,
                Name = model.Name,
                LastName = model.LastName,
                Birthday = (DateTime)model.CreationDate,
                RFC = model.RCF,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PositionId = model.PositionId,
                IsDeleted = model.IsDeleted
            };

            var positions = new PosicionesViewModel();
            positions.datos = EmpleadoService.getAllP();

            // Transformar a un SelectListItem como los necesita el DropDownList
            List<SelectListItem> items = positions.datos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Name.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;

            //Crear la vista con el formulario para poder modificar
            //return Content(id.ToString());
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Actualizar(EmpleadoViewModel model)
        {
            var DateAndTime = DateTime.Now; //Obtiene la fecha actual
            //Crear el objeto de empleado
            var empleado = new EmployeesIvan()
            {
                Id = model.Id,
                CreationDate = DateAndTime,
                Name = model.Name,
                LastName = model.LastName,
                Birhtday = model.Birthday,
                RCF = model.RFC,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PositionId = model.PositionId,
                IsDeleted = model.IsDeleted
            };

            //Crear el metodo para actualizar en la base de datos
            //Invocar el metodo 
            EmpleadoService.Actualizar(empleado);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            var DateAndTime = DateTime.Now; //Obtiene la fecha actual
            //Crear el metodo para buscar los datos del empleado (service)
            var model = EmpleadoService.Buscar(id);
            //Crear el view model con los datos del empleado
            var empleado = new EmpleadoViewModel()
            {
                Id = model.Id,
                CreationDate = DateAndTime,
                Name = model.Name,
                LastName = model.LastName,
                Birthday = model.Birhtday,
                RFC = model.RCF,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PositionId = model.PositionId,
                IsDeleted = model.IsDeleted
            };

            //Crear la vista con el formulario para poder modificar
            //return Content(id.ToString());
            return View(empleado);
        }

        [HttpPost]
        public ActionResult DarDeBaja(EmpleadoViewModel model)
        {
            if (model.IsDeleted)
                model.IsDeleted = false;
            else
                model.IsDeleted = true;
            var DateAndTime = DateTime.Now; //Obtiene la fecha actual
            //Crear el objeto de empleado
            var empleado = new EmployeesIvan()
            {
                Id = model.Id,
                CreationDate = DateAndTime,
                Name = model.Name,
                LastName = model.LastName,
                Birhtday = model.Birthday,
                RCF = model.RFC,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PositionId = model.PositionId,
                IsDeleted = model.IsDeleted
            };

            //Crear el metodo para actualizar en la base de datos
            //Invocar el metodo 
            EmpleadoService.Actualizar(empleado);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}