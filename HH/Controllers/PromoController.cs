using HH.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HH.Controllers
{
    public class PromoController : Controller
    {
        private readonly PromoContext _Context;
        public PromoController(PromoContext context)
        {
            _Context = context;
        }

        public IActionResult Promo()
        {
            var promo = _Context.Promo.ToList();
            return View(promo);
        }
        public IActionResult CreatePromo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePromo(Promo promo)
        {
            _Context.Add(promo);
            _Context.SaveChanges();

            return RedirectToAction("Promo");
        }

        public IActionResult EditPromo(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var promo = _Context.Promo.SingleOrDefault(a => a.ID == id);

            if (promo == null)
            {
                return NotFound();
            }
            return View(promo);
        }
        [HttpPost]
        public IActionResult EditPromo(int id, Promo promo)
        {
            if (id != promo.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _Context.Update(promo);
                _Context.SaveChanges();

                return RedirectToAction("Promo");
            }
            return View(promo);
        }
        public IActionResult DeletePromo(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var promo = _Context.Promo.SingleOrDefault(a => a.ID == id);

            if (promo == null)
            {
                return NotFound();
            }
            return View(promo);
        }
        [HttpPost, ActionName("DeletePromo")]
        public IActionResult Delet(int id)
        {
            var promo = _Context.Promo.SingleOrDefault(a => a.ID == id);
            if (promo == null)
            {
                return NotFound();
            }
            _Context.Promo.Remove(promo);
            _Context.SaveChanges();
            return RedirectToAction("Promo");
        }
        public IActionResult DetailsPromo(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var promo = _Context.Promo.SingleOrDefault(a => a.ID == id);
            if (promo == null)
            {
                return NotFound();
            }
            return View(promo);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
