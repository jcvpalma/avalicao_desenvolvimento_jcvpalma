using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AvaliacaoDesenv.Model;
using AD_BussinessEF;
using AD_ContractRepos.DataRepo;

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

                var oFornecedor = new FornecedorDAO(new FornecedorRepositories());
                var _fornecedorObject = new Fornecedor();

                using (System.IO.StreamReader read = new System.IO.StreamReader(oFile.InputStream))
                {
                    while ((line = read.ReadLine()) != null)
                    {
                        sValores += line.Replace("\t","|");

                        string[] vetor = line.Split('\t');

                        _fornecedorObject.NomeFornecedor = vetor[5];

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