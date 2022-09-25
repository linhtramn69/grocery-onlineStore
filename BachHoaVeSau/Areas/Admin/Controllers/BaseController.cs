using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BachHoaVeSau.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected void SetAlert(string mess, string type)
        {
            TempData["AlertMess"] = mess;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}