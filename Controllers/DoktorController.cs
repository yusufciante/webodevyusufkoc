using hastanerandevu.Models;
using hastanerandevu.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace hastanerandevu.Controllers
{
    public class DoktorController : Controller
    {
        private readonly IDoktorRepository _doktorRepository;
        private readonly IDoktorBransRepository _doktorBransRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;
        public DoktorController(IDoktorRepository doktorRepository, IDoktorBransRepository doktorBransRepository,IWebHostEnvironment webHostEnvironment )
        {
            _doktorRepository = doktorRepository;
            _doktorBransRepository = doktorBransRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
           // List<Doktor> objDoktorList = _doktorRepository.GetAll().ToList();
            List<Doktor> objDoktorList = _doktorRepository.GetAll(includeProps:"DoktorBrans").ToList();
            return View(objDoktorList);
        }

        public IActionResult EkleGuncelle(int? id)
        {
                IEnumerable<SelectListItem> DoktorBransiList = _doktorBransRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Ad,
                    Value = k.Id.ToString()
                });
                
            ViewBag.DoktorBransiList= DoktorBransiList;
            
            if(id==null||id==0)
            { return View(); }
            else
            {
                Doktor doktorVt = _doktorRepository.Get(u => u.Id == id);
                if (doktorVt == null) { return NotFound(); }
                return View(doktorVt);
            }
        }
        [HttpPost]

        public IActionResult EkleGuncelle(Doktor doktor, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string doktorPath= Path.Combine(wwwRootPath, @"img");
                if (file != null)
                {    
                using (var fileStream = new FileStream(Path.Combine(doktorPath,file.FileName),FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                doktor.ResimUrl = @"\img\" + file.FileName;
                }
                if (doktor.Id == 0)
                {
                    _doktorRepository.Ekle(doktor);
                    TempData["basarili"] = "Başarıyla yeni doktor oluşturuldu";
                }
                else
                {
                    _doktorRepository.Guncelle(doktor);
                    TempData["basarili"] = "Başarıyla doktor güncellendi";
                }

               
                _doktorRepository.Kaydet();
                return RedirectToAction("Index", "Doktor");
            }
            return View();
    
        }
        /*
        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0) {
                return NotFound();
            }
            Doktor doktorVt = _doktorRepository.Get(u=>u.Id==id);
            if(doktorVt == null) { return NotFound(); }
            return View(doktorVt);
        }
        */
        [HttpPost]

        public IActionResult Guncelle(Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _doktorRepository.Guncelle(doktor);
                _doktorRepository.Kaydet();
                TempData["basarili"] = "Başarıyla Doktor güncellendi";
                return RedirectToAction("Index", "Doktor");
            }
            return View();
        }
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Doktor? doktorVt = _doktorRepository.Get(u=>u.Id==id);
            if (doktorVt == null) { return NotFound(); }
            return View(doktorVt);
        }
    
    [HttpPost,ActionName("Sil")]

    public IActionResult SilPOST(int? id)
    {
            Doktor? doktor = _doktorRepository.Get(u=>u.Id == id);
            if(doktor==null) 
            { 
                return NotFound();
            }
            _doktorRepository.Sil(doktor);
            _doktorRepository.Kaydet();
            TempData["basarili"] = "Başarıyla Doktor silindi gj mf";
            return RedirectToAction("Index", "Doktor"); 
        }
    }
}