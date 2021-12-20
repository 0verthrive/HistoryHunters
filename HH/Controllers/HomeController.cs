using HH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HH.Controllers
{
    public class HomeController : Controller
    { 
        private readonly DestinoContext _Context;
        public HomeController(DestinoContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult Contato()
        {
            return View();
        }
        public IActionResult Destino()
        {
            var destino = _Context.Destino.ToList();
            return View(destino);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Destino destino)
        {
            _Context.Add(destino);
            _Context.SaveChanges();

            return RedirectToAction("Destino");
        }

        public IActionResult Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var destino = _Context.Destino.SingleOrDefault(a => a.ID == id);

            if(destino == null)
            {
                return NotFound();
            }
            return View(destino);
        }
        [HttpPost]
        public IActionResult Edit(int id, Destino destino)
        {
            if (id != destino.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _Context.Update(destino);
                _Context.SaveChanges();

                return RedirectToAction("Destino");
            }
            return View(destino);
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var destino = _Context.Destino.SingleOrDefault(a => a.ID == id);

            if (destino == null)
            {
                return NotFound();
            }
            return View(destino);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Delet(int id)
        {
            var destino = _Context.Destino.SingleOrDefault(a => a.ID == id);
            if(destino == null)
            {
                return NotFound();
            }
            _Context.Destino.Remove(destino);
            _Context.SaveChanges();
            return RedirectToAction("Destino");
        }
        public IActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var destino = _Context.Destino.SingleOrDefault(a => a.ID == id);
            if (destino == null)
            {
                return NotFound();
            }
            return View(destino);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
