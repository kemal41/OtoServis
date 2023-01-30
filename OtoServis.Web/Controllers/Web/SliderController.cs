using OtoServis.BL;
using OtoServis.BL.Abstract;
using OtoServis.Entities.Web;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Web
{
    public class SliderController : Controller
    {
        private readonly IRepository<Slider> rpSlider = new Repository<Slider>();
        public ActionResult Index()
        {
            var slider = rpSlider.List().OrderByDescending(c => c.SliderId);
            return View(slider);
        }
        public ActionResult SliderKaydet(Slider slider, HttpPostedFileBase resim)
        {
            try
            {
                if (resim != null)
                {
                    string uzantı = Path.GetExtension(resim.FileName);
                    string dosyaAdi = Path.GetFileNameWithoutExtension(resim.FileName) + "_" + Guid.NewGuid();
                    string tamAd = dosyaAdi + uzantı;
                    string yol = Server.MapPath("/img/Slider/") + tamAd;
                    resim.SaveAs(yol);
                    string kaydedilecekYol = "/img/Slider/" + tamAd;
                    slider.Resim = kaydedilecekYol;

                    rpSlider.Insert(slider);
                    TempData["Ok"] = "Kayıt Başarılı";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["No"] = "Hata Olustu" + ex.ToString();
                return RedirectToAction("Index");
            }



        }
        [HttpPost]
        public ActionResult SliderSil(int id)
        {
            try
            {
                var slider = rpSlider.GetById(id);
                string resimYolu = Request.MapPath(slider.Resim);
                rpSlider.Delete(slider);
                if (System.IO.File.Exists(resimYolu))
                {
                    System.IO.File.Delete(resimYolu);
                }
                TempData["Ok"] = "Silme Tamamlandı";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["No"] = "Hata";
                return RedirectToAction("Index");
            }

        }
    }
}