using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BachHoaVeSau.Controllers
{
    public class ProductController : Controller
    {
        CuaHangBachHoaEntities db = new CuaHangBachHoaEntities();
        
        public ActionResult SanPhamTheoLoai( int? loai, int? page)
        {
            
            if (loai != null)
            {
                ViewBag.loai = loai;
                int pageNumber = page ?? 1;
                int pageSize = 12;
                var productList = db.SANPHAMs.Where(x => x.MALSP == loai).OrderBy(x => x.MASP).ToPagedList(pageNumber, pageSize);
                return View(productList);
            }
            else
            {
                int pageNumber = page ?? 1;
                int pageSize = 12;
                var productList = db.SANPHAMs.OrderBy(x => x.MASP).ToPagedList(pageNumber, pageSize);
                return View(productList);
            }

        }
        

    }
}