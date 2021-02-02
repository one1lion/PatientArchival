using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientArchive.Services
{
    public class PdfService : Controller
    {
        public byte[] DownloadPDF(string filePath)
        {
            string filename = "Test.pdf";
            string filepath = filePath;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeTypes.GetMimeType(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };

            return filedata;
            //return File(filedata, contentType);
        }
    }
}
