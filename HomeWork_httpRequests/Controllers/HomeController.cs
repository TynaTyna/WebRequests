using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace HomeWork_httpRequests.Controllers
{
    public class HomeController : Controller
    {
         public ActionResult Index(int? value)
            {
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item0 = new SelectListItem() { Text = "Выберите тип запроса", Value = "0", Selected = true };
            SelectListItem item1 = new SelectListItem() { Text = "Get", Value = "1", Selected = false };
            SelectListItem item2 = new SelectListItem() { Text = "Post", Value = "2", Selected = false };
            SelectListItem item3 = new SelectListItem() { Text = "Options", Value = "3", Selected = false };
            SelectListItem item4 = new SelectListItem() { Text = "Link", Value = "4", Selected = false };
            SelectListItem item5 = new SelectListItem() { Text = "Put", Value = "5", Selected = false };
            SelectListItem item6 = new SelectListItem() { Text = "Delete", Value = "6", Selected = false };

            items.Add(item0);
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);
            items.Add(item6);

            if (value != null)
            {
                items.Where(i => i.Value == value.ToString()).First().Selected = true;

            }

            ViewBag.requestItems = items;
            return View();
        }
        
        public ActionResult RequestInfo()
        {
            StreamWriter w = new StreamWriter(HttpContext.Server.MapPath("~/Content/Response.txt"), true, Encoding.GetEncoding(1251));
            w.WriteLine("URL: " + Request.RawUrl);
            w.WriteLine("IP: " + Request.UserHostAddress);
            w.WriteLine("Request type: " + Request.RequestType);
            w.WriteLine();
            w.Close();
            return View();
        }


       
    }
}