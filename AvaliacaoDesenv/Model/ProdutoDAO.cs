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

        public void Dispose()
        {
            _produtoRepositorie.Dispose();
        }
    }
}