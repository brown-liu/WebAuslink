using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebAuslink.Data;
using WebAuslink.Models;

namespace WebAuslink.Controllers
{
    public class AdminController : Controller
    {

        public readonly IWebHostEnvironment _webEnv;
        public readonly WebAuslinkContext _context;

        public AdminController(IWebHostEnvironment webEnv,WebAuslinkContext context)
        {
            this._webEnv = webEnv;
            this._context = context;
        }

        public IActionResult Issues()
        {
            return View();
        }
        public IActionResult UpLoadPdf()
        {
            ViewBag.IsSuccess = "NeitherTrueOrFalse";
            return View();
        }

     public void  SavePDFInfoToDb(string title,string classification,string path)
        {
          
            FileLoader pdf = new FileLoader() { Title=title,Classification=classification,pdfUrl=path};

            _context.FileLoader.Add(pdf);

           _context.SaveChanges();
            
        
        }



        [HttpPost]
        public async Task<IActionResult> UpLoadPdf(ObjectPDF objPdf)
        {
            if (ModelState.IsValid && objPdf.pdf != null)
            {
                string root = _webEnv.WebRootPath;
                if (objPdf.Classification == "auslink")
                {
                    string folder = "pdf/auslink_sop/";
                    folder +=  Guid.NewGuid().ToString() + objPdf.pdf.FileName;
                    string serverFolderAddress =  Path.Combine(root, folder);
                    FileStream file = new FileStream(serverFolderAddress, FileMode.Create);
                   await objPdf.pdf.CopyToAsync(file);
                    ViewBag.IsSuccess = "true";
                    
                    SavePDFInfoToDb(objPdf.Title,objPdf.Classification,folder);
                    file.Dispose();
                    return View();
                }
                if (objPdf.Classification == "client")
                {
                    string folder = "pdf/client_sop/";
                    folder += Guid.NewGuid().ToString() + objPdf.pdf.FileName;
                    string serverFolderAddress = Path.Combine(root, folder);
                    FileStream file = new FileStream(serverFolderAddress, FileMode.Create);
                    await objPdf.pdf.CopyToAsync(file);
                    ViewBag.IsSuccess = "true";

                    SavePDFInfoToDb(objPdf.Title, objPdf.Classification, folder);
                    file.Dispose();
                    return View();
                }
                else
                {
                    ViewBag.IsSuccess = "false";
                    return View();
                }

            }

            return View();
        }

    }
}
