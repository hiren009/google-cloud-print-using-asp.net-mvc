using GoogleCloudPrint.Lib;
using GoogleCloudPrint.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleCloudPrint.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var allPrinters = CloudHelper.GetPrinterList();
            ViewBag.allPrinters = allPrinters;

            return View();
        }

      
    }
}