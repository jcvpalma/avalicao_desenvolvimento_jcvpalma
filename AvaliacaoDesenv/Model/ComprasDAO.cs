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

        IRepositorieBase<Compras> _comprasRepositorie;

        public ComprasDAO(IRepositorieBase<Compras> _compras)
        {
            this._comprasRepositorie = _compras;
        }

        public void Dispose()
        {
            _comprasRepositorie.Dispose();
        }
    }
}