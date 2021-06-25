using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Esercitazione.Model;

namespace Week6.Esercitazione.Context
{
    public class InsuranceContext : DbContext
    {
        //dbset, costruttore no arg, chiamata metodo onmodelcreating, connectionstring

        public InsuranceContext() : base()
        {

        }

        //connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; 
                                    Initial Catalog = Insurance; Server = .\SQLEXPRESS");
        }
        //DBSET
        public DbSet<Client> Clients { get; set; }

        public DbSet<Policy> Policies { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<Policy>(new PolicyConfiguration());

        }


    }
}
