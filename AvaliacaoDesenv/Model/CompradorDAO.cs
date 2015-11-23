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
    public class CompradorDAO : IDisposable
    {
        IRepositorieBase<Comprador> _compradorRepository;

        public CompradorDAO(IRepositorieBase<Comprador> _comprador)
        {
            _compradorRepository = _comprador;
        }

        public bool existsComprador(string comprador)
        {
            bool retorno = false;

            if (_compradorRepository.getAllBy(x => x.NomeComprador == comprador).Count() > 0)
            {
                retorno = true;
            }
            return retorno;
        }


        public bool Salvar(Comprador _comprador)
        {
            bool retorno = false;
            if (_comprador != null)
            {
                Comprador newest = new Comprador();

                newest = _comprador;

                if (_compradorRepository.save(newest) > 0)
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
            _compradorRepository.Dispose();
        }
    }

}