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
    public class FornecedorDAO : IDisposable
    {

        IRepositorieBase<Fornecedor> _fornecedorRepository;

        public FornecedorDAO(IRepositorieBase<Fornecedor> _fornecedor)
        {
            _fornecedorRepository = _fornecedor;            
        }

        public bool SalvarFornecedor(Fornecedor _fornecedor)
        {
            bool retorno = false;
            if (_fornecedor != null)
            {
                Fornecedor newest = new Fornecedor();

                newest = _fornecedor;

                if (_fornecedorRepository.save(newest) > 0)
                {
                    retorno = true;
                }

            }
            else
            {

            }
            return retorno;
        }


        public void Dispose()
        {
            _fornecedorRepository.Dispose();
        }
    }
}