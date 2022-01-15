using Kiosko.Data;
using Kiosko.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosko.Controllers
{
    public class ModelosController : Controller
    {

        private readonly ModelosContexto _context; 


        public ModelosController(ModelosContexto contexto)
        {
            _context = contexto;
        }



        // GET: ModelosController
        public IActionResult Index()
        {
            var modulos = _context.Modulos.FromSqlRaw<Modulos>("SELECT * FROM Modulos").ToList();
            return View(modulos);
        }

        // GET: ModelosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModelosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelosController/Create
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

        // GET: ModelosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModelosController/Edit/5
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

        // GET: ModelosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModelosController/Delete/5
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
