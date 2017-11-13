using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleCloudPrint.Lib;
using GoogleCloudPrint.Web.Models;

namespace GoogleCloudPrint.Web.Controllers
{
    public class AcceptPendingInvitesController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["TDMessage"] != null)
            {
                ViewBag.PageResp = TempData["TDMessage"];
                TempData.Remove("TDMessage");
            }

            return View();
        }

        [HttpPost]
        public ActionResult IndexPost(string printerId = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(printerId))
                {
                    CloudHelper.AcceptAnyPendingInvites(printerId);
                    TempData.Add("TDMessage", new PageResponse { cMessage = "Printer added successfully!", isSuccess = true });
                }
                else
                {
                    TempData.Add("TDMessage", new PageResponse { cMessage = "Please enter PrinterId", isSuccess = false });
                }
            }
            catch (Exception ex)
            {
                TempData.Add("TDMessage", new PageResponse { cMessage = ex.Message, isSuccess = false });
            }

            return RedirectToAction("Index");
        }

    }
}