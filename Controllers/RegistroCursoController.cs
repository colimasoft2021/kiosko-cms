using Kiosko.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosko.Controllers
{
    public class RegistroCursoController : Controller
    {
        private readonly RegistroCursoContext _Reg;

        public RegistroCursoController(RegistroCursoContext registro)
        {
            _Reg = registro;
        }
        // GET: RegistroCursoController1
        public ActionResult Index()
        {
            return View("RegistroCurso");
        }

        // GET: RegistroCursoController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistroCursoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroCursoController1/Create
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

        // GET: RegistroCursoController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistroCursoController1/Edit/5
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

        // GET: RegistroCursoController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistroCursoController1/Delete/5
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
