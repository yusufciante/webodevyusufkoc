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

        private readonly IDoktorBransRepository _doktorBransRepository;

        public DoktorBransController(IDoktorBransRepository context)
        {
            _doktorBransRepository = context;
        }
        public IActionResult Index()
        {
            List<DoktorBrans> objDoktorBransList = _doktorBransRepository.GetAll().ToList();
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
                _doktorBransRepository.Ekle(doktorBrans);
                _doktorBransRepository.Kaydet();
                TempData["basarili"] = "Başarıyla yeni branş oluşturuldu";
                return RedirectToAction("Index", "DoktorBrans");
            }
            return View();
    
        }
        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0) {
                return NotFound();
            }
            DoktorBrans doktorBransVt = _doktorBransRepository.Get(u=>u.Id==id);
            if(doktorBransVt == null) { return NotFound(); }
            return View(doktorBransVt);
        }
        
        [HttpPost]

        public IActionResult Guncelle(DoktorBrans doktorBrans)
        {
            if (ModelState.IsValid)
            {
                _doktorBransRepository.Guncelle(doktorBrans);
                _doktorBransRepository.Kaydet();
                TempData["basarili"] = "Başarıyla branş güncellendi";
                return RedirectToAction("Index", "DoktorBrans");
            }
            return View();
        }
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DoktorBrans? doktorBransVt = _doktorBransRepository.Get(u=>u.Id==id);
            if (doktorBransVt == null) { return NotFound(); }
            return View(doktorBransVt);
        }
    
    [HttpPost,ActionName("Sil")]

    public IActionResult SilPOST(int? id)
    {
            DoktorBrans? doktorBrans = _doktorBransRepository.Get(u=>u.Id == id);
            if(doktorBrans==null) 
            { 
                return NotFound();
            }
            _doktorBransRepository.Sil(doktorBrans);
            _doktorBransRepository.Kaydet();
            TempData["basarili"] = "Başarıyla branş silindi gj mf";
            return RedirectToAction("Index", "DoktorBrans"); 
        }
    }
}