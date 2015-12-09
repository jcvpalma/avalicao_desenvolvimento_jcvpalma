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
    public class ProdutoDAO : IDisposable
    {

        IRepositorieBase<Produto> _produtoRepositorie;

        public ProdutoDAO(IRepositorieBase<Produto> _produto)
        {
            _produtoRepositorie = _produto;
        }

        public bool existsProduto(string produto)
        {
            bool retorno = false;

            if (_produtoRepositorie.getAllBy(x => x.DescricaoProduto == produto).Count() > 0)
            {
                retorno = true;
            }
            return retorno;
        }


        public bool Salvar(Produto _produto)
        {
            bool retorno = false;
            if (_produto != null && _produto.IdProduto != null)
            {
                Produto newest = new Produto();

                newest = _produto;

                if (_produtoRepositorie.save(newest) > 0)
                {
                    retorno = true;
                }

            }
            else
            {
                if (_produtoRepositorie.update(_produto) > 0)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public Produto getProduto(String _produto)
        {
            return _produtoRepositorie.getOne(x => x.DescricaoProduto.Contains(_produto));
        }

        public void Dispose()
        {
            _produtoRepositorie.Dispose();
        }
    }
}