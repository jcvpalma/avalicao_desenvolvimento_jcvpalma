using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AD_BussinessEF;
using AD_ContractRepos;
using AD_ContractRepos.DataRepo;
using AD_Repositories;


namespace AvaliacaoDesenv.Model
{
    public class ComprasDAO : IDisposable
    {

        IRepositorieBase<Compra> _comprasRepositorie;

        public ComprasDAO(IRepositorieBase<Compra> _compras)
        {
            this._comprasRepositorie = _compras;
        }
        public bool existsPedidoAberto(int idFornecedor, int idComprador, int idProduto)
        {
            bool retorno = false;

            if (_comprasRepositorie.getAllBy(x => ( x.Comprador.IdComprador == idComprador && x.DetalheCompras.FirstOrDefault().ProdutoIdProduto == idProduto && x.DetalheCompras.FirstOrDefault().Produto.FornecedorIdFornecedor == idFornecedor )).Count() > 0)
            {
                retorno = true;
            }
            return retorno;
        }

        public bool Salvar(Compra _compra)
        {
            bool retorno = false;
            if (_compra != null && _compra.IdCompra != null)
            {
                Compra newest = new Compra();

                newest = _compra;

                if (_comprasRepositorie.save(newest) > 0)
                {
                    retorno = true;
                }

            }
            else
            {
                if (_comprasRepositorie.update(_compra) > 0)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public Compra getPedido(int idFornecedor, int idComprador, int idProduto)
        {
            return _comprasRepositorie.getOne(x => (x.Comprador.IdComprador == idComprador && x.DetalheCompras.FirstOrDefault().ProdutoIdProduto == idProduto && x.DetalheCompras.FirstOrDefault().Produto.FornecedorIdFornecedor == idFornecedor));
        }
        public void Dispose()
        {
            _comprasRepositorie.Dispose();
        }
    }
}