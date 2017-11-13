using GoogleCloudPrint.Lib;
using GoogleCloudPrint.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleCloudPrint.Web.Controllers
{
    public class CloudPrintController : Controller
    {
        // GET: CloudPrint
        public ActionResult Index()
        {
            ViewBag.PrinterList = CloudHelper.GetPrinterList().Select(x => new SelectListItem { Text = x.Key, Value = x.Value }).ToList();

            if (TempData["TDMessage"] != null)
            {
                ViewBag.PageResp = TempData["TDMessage"];
                TempData.Remove("TDMessage");
            }

            var oRet = new PrinterModel();
            return View(oRet);
        }

        [HttpPost]
        public ActionResult IndexPost(PrinterModel oModel, HttpPostedFileBase fileUpload)
        {
            try
            {
                if (!oModel.isPrintFromUrl)
                {
                    if (fileUpload == null)
                    {
                        throw new Exception("Please upload file!");
                    }

                    oModel.strFileName = fileUpload.FileName;

                    using (var binaryReader = new BinaryReader(fileUpload.InputStream))
                    {
                        oModel.document = binaryReader.ReadBytes(fileUpload.ContentLength);
                    }

                    CloudHelper.PrintUploadedFile(oModel.PrinterId, oModel.title, oModel.strFileName, oModel.document);

                }
                else
                {
                    if (string.IsNullOrEmpty(oModel.url))
                    {
                        throw new Exception("Please enter url to print!");
                    }

                    CloudHelper.PrintOnlineUrl(oModel.PrinterId, oModel.title, oModel.url);
                }

                TempData.Add("TDMessage", new PageResponse { cMessage = "Printer request sent successfully!", isSuccess = true });

            }
            catch (Exception ex)
            {
                TempData.Add("TDMessage", new PageResponse { cMessage = ex.Message, isSuccess = false });
            }

            return RedirectToAction("Index");
        }


    }
}