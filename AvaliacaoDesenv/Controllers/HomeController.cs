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

                using (System.IO.StreamReader read = new System.IO.StreamReader(oFile.InputStream))
                {

                    #region --|COMPRADOR|--
                    string comprador = String.Empty;
                    string descricao = String.Empty;
                    decimal precoUnitario = 0;
                    int quantidade = 0;
                    string endereco = String.Empty;
                    string fornecedor = String.Empty;
                    #endregion

                    while ((line = read.ReadLine()) != null)
                    {
                        sValores += line.Replace("\t","|");

                        string[] vetor = line.Split('\t');

                        if (!vetor[0].StartsWith("Comprador"))
                        {
                            #region -- Variaveis vindas do arquivo
                            comprador = vetor[0];//Comprador
                            descricao = vetor[1];//Descricao
                            precoUnitario = decimal.Parse(vetor[2]);//Preco
                            quantidade = int.Parse(vetor[3]);//Quantidade
                            endereco = vetor[4];//Endereco
                            fornecedor = vetor[5];//Fornecedor

                            //Abro o pedido de Compra
                            Compra pedido = new Compra();
                            DetalheCompra detPedido = new DetalheCompra();

                            //1. Insiro o Comprador Caso nao Exista
                            var oComprador = new CompradorDAO(new CompradorRepositories());
                            var existComprador = oComprador.existsComprador(comprador);

                            if (existComprador == false)
                            {
                                Comprador novoComprador = new Comprador();
                                novoComprador.NomeComprador = comprador;
                                if (!oComprador.Salvar(novoComprador))
                                {
                                    throw new Exception("Nao foi possivel salvar o comprador!");
                                }
                            }
                            var __comprador = oComprador.getComprador(comprador);

                            //2. Insiro o Fornecedor
                            var oFornecedor = new FornecedorDAO(new FornecedorRepositories());
                            var existFornecedor = oFornecedor.existsFornecedor(fornecedor);

                            if (existFornecedor == false) 
                            {
                                Fornecedor novoFornecedor = new Fornecedor();
                                novoFornecedor.NomeFornecedor = fornecedor;
                                if (!oFornecedor.Salvar(novoFornecedor))
                                {
                                    throw new Exception("Nao foi possivel salvar o produto!");
                                }
                            }
                            var __fornecedor = oFornecedor.getFornecedor(descricao);


                            //3. Insiro o produto
                            var oProduto = new ProdutoDAO(new ProdutoRepositories());
                            var existProduto = oProduto.existsProduto(descricao);

                            if (existProduto == false)
                            {
                                Produto novoProduto = new Produto();
                                novoProduto.DescricaoProduto = descricao;
                                novoProduto.ValorUnitario = precoUnitario;
                                novoProduto.Fornecedor = __fornecedor;

                                if (!oProduto.Salvar(novoProduto))
                                {
                                    throw new Exception("Nao foi possivel salvar o produto!");
                                }
                            }
                            var __produto = oProduto.getProduto(descricao);

                            //4. Alimento o Pedido e o Detalhe do Pedido

                            detPedido.Produtoes.Add(__produto);
                            detPedido.QtdeProdutoCompra = quantidade;

                            pedido.Comprador = __comprador;
                            pedido.DetalheCompras.Add(detPedido);
                            pedido.DtCompra = new DateTime();

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