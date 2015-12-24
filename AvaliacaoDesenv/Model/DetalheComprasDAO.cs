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
    public class DetalheComprasDAO : IDisposable
    {

        IRepositorieBase<DetalheCompra> _detalheComprasRepositorie;

        public DetalheComprasDAO(IRepositorieBase<DetalheCompra> _detalheCompras)
        {
            _detalheComprasRepositorie = _detalheCompras;
        }

        public bool existsDetalhePedido(int idCompra, int idProduto)
        {
            bool retorno = false;

            if (_detalheComprasRepositorie.getAllBy(x => x.ComprasIdCompra == idCompra && x.ProdutoIdProduto == idProduto).Count() > 0)
            {
                retorno = true;
            }
            return retorno;
        }

        public bool Salvar(DetalheCompra _detalhe)
        {
            bool retorno = false;
            if (_detalhe != null && _detalhe.IdDetalheCompra != null)
            {
                DetalheCompra newest = new DetalheCompra();

                newest = _detalhe;

                if (_detalheComprasRepositorie.save(newest) > 0)
                {
                    retorno = true;
                }

            }
            else
            {
                if (_detalheComprasRepositorie.update(_detalhe) > 0)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public DetalheCompra getDetalhePedido(int idCompra, int idProduto)
        {
            return _detalheComprasRepositorie.getOne(x => x.ComprasIdCompra == idCompra && x.ProdutoIdProduto == idProduto);
        }

        public void Dispose()
        {
            _detalheComprasRepositorie.Dispose();
        }
    }
}