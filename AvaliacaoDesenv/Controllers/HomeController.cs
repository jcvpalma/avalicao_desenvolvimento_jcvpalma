using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaliacaoDesenv.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Salvar(HttpPostedFileBase file)
        {

            if (Request.IsAjaxRequest())
            {
                var sValores = String.Empty;
                var oFile = Request.Files["oFile"];
                string line;


                using (System.IO.StreamReader read = new System.IO.StreamReader(oFile.InputStream))
                {
                    while ((line = read.ReadLine()) != null)
                    {
                        sValores += line.Replace("\t","|");
                    }
                }

                ViewData["valores"] = sValores;

                return Json(ViewData);
            }
            else
            {
                return View();
            }
            
            
        }

    }
}