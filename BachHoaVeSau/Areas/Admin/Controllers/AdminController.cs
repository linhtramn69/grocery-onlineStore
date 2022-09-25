using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;

namespace BachHoaVeSau.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        CuaHangBachHoaEntities db = new CuaHangBachHoaEntities();
        // GET: Admin/Admin
        // Index
        public ActionResult listSp(int? page)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            else
            {
                int pageNumber = page ?? 1;
                int pageSize = 10;
                var sp = db.SANPHAMs.OrderBy(x => x.MASP).ToPagedList(pageNumber, pageSize);
                return View(sp);
            }
        }


        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string username, string password)
        {
            if(username=="admin" && password == "123")
            {
                Session["user"] = "admin";
                return RedirectToAction("listSp");
            }
            else
            {
                TempData["error"] = "Tài khoản hoặc mật khẩu không đúng!";
                return View();
            }   
        }

        public ActionResult DangXuat()
        {
            // xoa Session
            Session.Remove("user");
            // xoa session form authent
            FormsAuthentication.SignOut();

            return RedirectToAction("DangNhap");
        }

        public ActionResult listUser()
        {
            var user = from s in db.KHACHHANGs select s;
            return View(user);
        }
        public ActionResult listLoaiSp()
        {
            var loai = from s in db.LOAISANPHAMs select s;
            return View(loai);
        }
        public PartialViewResult LoaiPartial()
        {
            var dsLoai = db.LOAISANPHAMs.OrderBy(x => x.TENLSP).ToList();
            return PartialView(dsLoai);
        }
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost, ActionName("CreateProduct")]
        [ValidateInput(false)]
        public ActionResult CreateProduct(SANPHAM sp, HttpPostedFileBase fileUpload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Upload file
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Lưu đường dẫn file ảnh 
                    var path = Path.Combine(Server.MapPath("~/Content"), fileName);
                    //Kiểm tra file đã tồn tại
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                   
                    sp.HINHANH = fileUpload.FileName;
                    db.SANPHAMs.Add(sp);
                    db.SaveChanges();
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Thêm sản phẩm không thành công");
            }
            //Cập nhật lại danh sách hiển thị
            var listSp = from s in db.SANPHAMs select s;
            SetAlert("Thêm sản phẩm thành công", "success");
            return View("listSp", listSp);
        }

        //Hiển thị thông tin một sách cần xoá
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(s => s.MASP == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        //Xác nhận xoá
        [HttpPost, ActionName("DeleteProduct")]
        public ActionResult DeleteConfirm(int id)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(s => s.MASP == id);
            var path = Path.Combine(Server.MapPath("~/Content"), sp.HINHANH);

            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Xoá ảnh trong thư mục ~/Content/Image
            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            db.SANPHAMs.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("listSp");
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(s => s.MASP == id);
            return View(sp);
        }

        [HttpPost, ActionName("EditProduct")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id)
        {
            var spUpdate = db.SANPHAMs.Find(id);
            if (TryUpdateModel(spUpdate, "", new string[] { "TENSP", "DONGIA", "DONVITINH", "SLTONKHO", "HINHANH" }))
            {
                try
                {
                    db.Entry(spUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Error Save Data");
                }
            }

            return RedirectToAction("listSp");
        }



    }
}