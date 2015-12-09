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

        public bool existsFornecedor(string fornecedor)
        {
            bool retorno = false;

            if (_fornecedorRepository.getAllBy(x => x.NomeFornecedor == fornecedor).Count() > 0)
            {
                retorno = true;
            }
            return retorno;
        }


        public bool Salvar(Fornecedor _fornecedor)
        {
            bool retorno = false;
            if (_fornecedor != null && _fornecedor.IdFornecedor != null)
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
                if (_fornecedorRepository.update(_fornecedor) > 0)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public Fornecedor getFornecedor(String _fornecedor)
        {
            return _fornecedorRepository.getOne(x => x.NomeFornecedor.Contains(_fornecedor));
        }


        public void Dispose()
        {
            _fornecedorRepository.Dispose();
        }
    }
}