﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MGDB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MGDBModelContainer : DbContext
    {
        public MGDBModelContainer()
            : base("name=MGDBModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Research> ResearchSet { get; set; }
        public virtual DbSet<Engineer> EngineerSet { get; set; }
        public virtual DbSet<Customer> CustomerSet { get; set; }
        public virtual DbSet<SamplePrepRecord> SamplePrepRecordSet { get; set; }
        public virtual DbSet<SampleMakingRecord> SampleMakingRecordSet { get; set; }
        public virtual DbSet<MVZ> MVZSet { get; set; }
        public virtual DbSet<ChemistryRecord> ChemistryRecordSet { get; set; }
        public virtual DbSet<TypeOfResearch> TypeOfResearchSet { get; set; }
        public virtual DbSet<ResearchData> ResearchDataSet { get; set; }
    }
}
