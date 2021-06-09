using Microsoft.EntityFrameworkCore;
using System;
using TrackerDB.Models;

namespace TrackerDB
{
    public class ContextDB: DbContext
    {
        public DbSet<ContractPIR> ContractPIRs { get; set; }
        public DbSet<ContractSMR> ContractSMRs { get; set; }
        public DbSet<Powerline> Powerlines { get; set; }
        public DbSet<InternalNote> InternalNotes { get; set; }
        public DbSet<TypeOfContract> TypeOfContracts { get; set; }

        public ContextDB(DbContextOptions options):base (options)
        {
            Database.EnsureCreated();                      // если базы нет, то она создастся

        } 
    }
}
