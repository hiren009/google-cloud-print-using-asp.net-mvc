using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoogleCloudPrint.Web.Models
{
    public class PrinterModel
    {
        [Required(ErrorMessage = "* Required")]
        public string PrinterId { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string title { get; set; }

        public bool isPrintFromUrl { get; set; }

        //Print from url
        public string url { get; set; }

        //Print by uploading file
        public string strFileName { get; set; }
        public byte[] document { get; set; }
        public string mimeType { get; set; }
    }
}