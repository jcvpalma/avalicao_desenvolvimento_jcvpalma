using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AvaliacaoDesenv.Model;
using AD_BussinessEF;
using AD_ContractRepos.DataRepo;

namespace TestUnitAvalDesenv
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Comprador comprador = new Comprador();

                comprador.NomeComprador = "Comprador teste";
                
                var oComprador = new CompradorDAO(new CompradorRepositories());
                var existComprador = oComprador.existsComprador(comprador.NomeComprador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
