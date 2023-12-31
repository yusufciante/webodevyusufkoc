using hastanerandevu.Models;
using hastanerandevu.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace hastanerandevu.Controllers
{
    public class RandevuController : Controller
    {
        private readonly IRandevuRepository _randevuRepository;
        private readonly IDoktorRepository _doktorRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;
        public RandevuController(IRandevuRepository randevuRepository, IDoktorRepository doktorRepository,IWebHostEnvironment webHostEnvironment )
        {
            _randevuRepository = randevuRepository;
            _doktorRepository = doktorRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
           // List<Doktor> objDoktorList = _doktorRepository.GetAll().ToList();
            List<Randevu> objRandevuList = _randevuRepository.GetAll(includeProps:"Dokor").ToList();
            return View(objRandevuList);
        }

        public IActionResult EkleGuncelle(int? id)
        {
                IEnumerable<SelectListItem> DoktorList = _doktorRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.DoktorAdi,
                    Value = k.Id.ToString()
                });
                
            ViewBag.DoktorList= DoktorList;
            
            if(id==null||id==0)
            { return View(); }
            else
            {
                Randevu randevuVt = _randevuRepository.Get(u => u.Id == id);
                if (randevuVt == null) { return NotFound(); }
                return View(randevuVt);
            }
        }
        [HttpPost]

        public IActionResult EkleGuncelle(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                
                if (randevu.Id == 0)
                {
                    _randevuRepository.Ekle(randevu);
                    TempData["basarili"] = "Başarıyla yeni randevu oluşturuldu";
                }
                else
                {
                    _randevuRepository.Guncelle(randevu);
                    TempData["basarili"] = "Başarıyla randevu güncellendi";
                }

               
                _randevuRepository.Kaydet();
                return RedirectToAction("Index", "Randevu");
            }
            return View();
    
        }
        
        

        public IActionResult Guncelle(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _randevuRepository.Guncelle(randevu);
                _randevuRepository.Kaydet();
                TempData["basarili"] = "Başarıyla Doktor güncellendi";
                return RedirectToAction("Index", "Randevu");
            }
            return View();
        }
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Randevu? randevuVt = _randevuRepository.Get(u=>u.Id==id);
            if (randevuVt == null) { return NotFound(); }
            return View(randevuVt);
        }
    
    [HttpPost,ActionName("Sil")]

    public IActionResult SilPOST(int? id)
    {
            Randevu? randevu = _randevuRepository.Get(u=>u.Id == id);
            if(randevu==null) 
            { 
                return NotFound();
            }
            _randevuRepository.Sil(doktor);
            _randevuRepository.Kaydet();
            TempData["basarili"] = "Başarıyla Doktor silindi gj mf";
            return RedirectToAction("Index", "Randevu"); 
        }
    }
}