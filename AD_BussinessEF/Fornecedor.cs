//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AD_BussinessEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            this.Produto = new HashSet<Produto>();
        }
    
        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
    
        public virtual ICollection<Produto> Produto { get; set; }
    }
}