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

        IRepositorieBase<DetalheCompras> _detalheComprasRepositorie;

        public DetalheComprasDAO(IRepositorieBase<DetalheCompras> _detalheCompras)
        {
            _detalheComprasRepositorie = _detalheCompras;
        }

        public void Dispose()
        {
            _detalheComprasRepositorie.Dispose();
        }
    }
}