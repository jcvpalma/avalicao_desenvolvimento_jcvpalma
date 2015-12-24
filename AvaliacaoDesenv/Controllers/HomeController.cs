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
                            try
                            {
                                #region -- Variaveis vindas do arquivo
                                comprador = vetor[0];//Comprador
                                descricao = vetor[1];//Descricao
                                precoUnitario = decimal.Parse(vetor[2]);//Preco
                                quantidade = int.Parse(vetor[3]);//Quantidade
                                endereco = vetor[4];//Endereco
                                fornecedor = vetor[5];//Fornecedor
                                #endregion

                                #region -- | Laco de negocios

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
                                var __fornecedor = oFornecedor.getFornecedor(fornecedor);


                                //3. Insiro o produto
                                var oProduto = new ProdutoDAO(new ProdutoRepositories());
                                var existProduto = oProduto.existsProduto(descricao);

                                if (existProduto == false)
                                {
                                    Produto novoProduto = new Produto();
                                    novoProduto.DescricaoProduto = descricao;
                                    novoProduto.ValorUnitario = precoUnitario;
                                    novoProduto.FornecedorIdFornecedor = __fornecedor.IdFornecedor;

                                    if (!oProduto.Salvar(novoProduto))
                                    {
                                        throw new Exception("Nao foi possivel salvar o produto!");
                                    }
                                }
                                var __produto = oProduto.getProduto(descricao);

                                var oPedido = new ComprasDAO(new ComprasRepositories());
                                Compra pedido = new Compra();

                                pedido.Comprador = __comprador;
                                pedido.DtCompra = DateTime.Now;

                                var existPedidoAberto = oPedido.existsPedidoAberto(__fornecedor.IdFornecedor, __comprador.IdComprador, __produto.IdProduto);

                                if (!oPedido.Salvar(pedido))
                                {
                                    throw new Exception("Nao foi possivel salvar o Pedido!");
                                }
                                var __pedido = oPedido.getPedido(__fornecedor.IdFornecedor, __comprador.IdComprador, __produto.IdProduto);


                                //4. Alimento o Pedido e o Detalhe do Pedido
                                DetalheCompra detPedido = new DetalheCompra();

                                detPedido.ProdutoIdProduto = __produto.IdProduto;
                                detPedido.Produto = __produto;
                                detPedido.QtdeProdutoCompra = quantidade;
                                detPedido.ComprasIdCompra = __pedido.IdCompra;
                                detPedido.Compra = __pedido;

                                var oDetCompras = new DetalheComprasDAO(new DetalheComprasRepositories());
                                if (!oDetCompras.Salvar(detPedido))
                                {
                                    throw new Exception("Nao foi possivel salvar o Pedido!");
                                }
                                

                                #endregion
                            }
                            catch (Exception ex)
                            {
                                sValores = ex.Message.ToString();
                            }
                        
                        }//Fim !columns

                    }//Fim while
                }//Fim using

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