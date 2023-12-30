using hastanerandevu.Models;
using hastanerandevu.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace hastanerandevu.Controllers
{
    public class DoktorBransController : Controller
    {

        private readonly UygulamaDbContext _uygulamaDbContext;

        public DoktorBransController(UygulamaDbContext context)
        {
            _uygulamaDbContext = context;
        }
        public IActionResult Index()
        {
            List<DoktorBrans> objDoktorBransList = _uygulamaDbContext.DoktorBranslari.ToList();
             return View(objDoktorBransList);
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Ekle(DoktorBrans doktorBrans)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.DoktorBranslari.Add(doktorBrans);
                _uygulamaDbContext.SaveChanges();
                return RedirectToAction("Index", "DoktorBrans");
            }
            return View();
    
        }
        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0) {
                return NotFound();
            }
            DoktorBrans doktorBransVt = _uygulamaDbContext.DoktorBranslari.Find(id);
            if(doktorBransVt == null) { return NotFound(); }
            return View(doktorBransVt);
        }
        
        [HttpPost]

        public IActionResult Guncelle(DoktorBrans doktorBrans)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.DoktorBranslari.Update(doktorBrans);
                _uygulamaDbContext.SaveChanges();
                return RedirectToAction("Index", "DoktorBrans");
            }
            return View();
        }

    }

}
