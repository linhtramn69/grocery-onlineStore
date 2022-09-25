using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BachHoaVeSau;
namespace BachHoaVeSau.Controllers
{
    public class HomeController : Controller
    {
        CuaHangBachHoaEntities db = new CuaHangBachHoaEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 9;
            var sp = db.SANPHAMs.Where(x => x.DEAL ==true).OrderBy(x => x.TENSP).ToPagedList(pageNumber, pageSize);
            return View(sp);
        }
        public ActionResult ChiTietSP(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var chitiet = db.SANPHAMs.SingleOrDefault(s => s.MASP == id);
            return chitiet == null ? HttpNotFound() : (ActionResult)View("ChiTietSP", chitiet);
        }
        public PartialViewResult LoaiPartial()
        {
            var dsLoai = db.LOAISANPHAMs.OrderBy(x => x.TENLSP).ToList();
            return PartialView(dsLoai);
        }
        public ActionResult TinTuc()
        {
            return View();
        }
        public ActionResult KhuyenMai()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost, ActionName("DangKy")]
        [ValidateInput(false)]
        public ActionResult DangKy(KHACHHANG kh)
        {
            Console.WriteLine(kh);
            if(ModelState.IsValid)
            {
                var check = db.KHACHHANGs.FirstOrDefault(s => s.USERNAME == kh.USERNAME);
                    if (check == null)
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.KHACHHANGs.Add(kh);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "sai";
                        return View();
                    }

            }return View();
            
        }

    }
}