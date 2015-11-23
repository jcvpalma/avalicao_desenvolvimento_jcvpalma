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

                    string comprador = String.Empty;
                    string descricao = String.Empty;
                    double precoUnitario = 0.0;
                    int quantidade = 0;
                    string endereco = String.Empty;
                    string fornecedor = String.Empty;

                    while ((line = read.ReadLine()) != null)
                    {
                        sValores += line.Replace("\t","|");

                        string[] vetor = line.Split('\t');

                        if (!vetor[0].StartsWith("Comprador"))
                        {
                            #region -- Compilar processo de negocios aqui
                            comprador = vetor[0];//Comprador
                            descricao = vetor[1];//Descricao
                            precoUnitario = double.Parse(vetor[2]);//Preco
                            quantidade = int.Parse(vetor[3]);//Quantidade
                            endereco = vetor[4];//Endereco
                            fornecedor = vetor[5];//Fornecedor

                            //1. Insiro o Comprador Caso nao Exista
                            var oComprador = new CompradorDAO(new CompradorRepositories());
                            var existComprador = oComprador.existsComprador(comprador);



                            #endregion
                        }

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