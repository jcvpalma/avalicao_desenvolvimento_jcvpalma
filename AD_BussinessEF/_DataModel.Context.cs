﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataModelContainer : DbContext
    {
        public DataModelContainer()
            : base("name=DataModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comprador> Comprador { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<DetalheCompra> DetalheCompras { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
    }
}
