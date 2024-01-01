using hospital.Models;
using hospital.Utility;
using hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;

namespace hospital.Controllers
{
   
    public class RandevuController : Controller
    {
        private readonly IRandevuRepository _randevuRepository;
        private readonly IDoktorRepository _doktorRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;
        public RandevuController(IRandevuRepository randevuRepository, IDoktorRepository doktorRepository, IWebHostEnvironment webHostEnvironment)
        {
            _randevuRepository = randevuRepository;
            _doktorRepository = doktorRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            // List<Doktor> objDoktorList = _doktorRepository.GetAll().ToList();
            List<Randevu> objRandevuList = _randevuRepository.GetAll(includeProps: "Doktor").ToList();
            return View(objRandevuList);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> DoktorList = _doktorRepository.GetAll()
            .Select(k => new SelectListItem
            {
                Text = k.DoktorAdi,
                Value = k.Id.ToString()
            });

            ViewBag.DoktorList = DoktorList;

            if (id == null || id == 0)
            { return View(); }
            else
            {
                Randevu? randevuVt = _randevuRepository.Get(u => u.Id == id);
                if (randevuVt == null) { return NotFound(); }
                return View(randevuVt);
            }
        }

        [Authorize(Roles = UserRoles.Role_Admin)]
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


        [Authorize(Roles = UserRoles.Role_Admin)]
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
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Sil(int? id)
        {
            IEnumerable<SelectListItem> DoktorList = _doktorRepository.GetAll()
            .Select(k => new SelectListItem
            {
                Text = k.DoktorAdi,
                Value = k.Id.ToString()
            });
            ViewBag.DoktorList = DoktorList;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Randevu? randevuVt = _randevuRepository.Get(u => u.Id == id);
            if (randevuVt == null)
            {
                return NotFound();
            }
            return View(randevuVt);
        }

        [HttpPost, ActionName("Sil")]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult SilPOST(int? id)
        {
            Randevu? randevu = _randevuRepository.Get(u => u.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }
            _randevuRepository.Sil(randevu);
            _randevuRepository.Kaydet();
            TempData["basarili"] = "Başarıyla Doktor silindi gj mf";
            return RedirectToAction("Index", "Randevu");
        }
        [Authorize(Roles = UserRoles.Role_Hasta)]
        public IActionResult RandevuAl(int? id)
        {

            IEnumerable<SelectListItem> DoktorList = _doktorRepository.GetAll().
                Select(
                k => new SelectListItem
                {
                    Text = k.DoktorAdi,
                    Value = k.Id.ToString(),
                }
               );

            ViewBag.DoktorList = DoktorList;


            // if (id == null || id == 0)//ekle
            //{

            return View();

            // }

        }


        [Authorize(Roles = UserRoles.Role_Hasta)]
        [HttpPost]//bunu yazmazsan yukarıda aynı isimle action olduğu için "catch" çalışır, sayfayı göremezsin.
        public IActionResult RandevuAl(Randevu randevu)
        {

            if (ModelState.IsValid)
            {

                randevu.Id = 0;


                _randevuRepository.Ekle(randevu);
                TempData["basarili"] = "Başarıyla Doktor silindi gj mf";



                _randevuRepository.Kaydet();//bunu yapmazsan db'ye bilgiler eklenmez.



                return RedirectToAction("Index", "Doktor");
            }
            else
            {
                return View();
            }


        }
    }
}
