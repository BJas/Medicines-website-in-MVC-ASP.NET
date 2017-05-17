using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using emde.kz.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace emde.kz.DAL
{
    public class MedicinesContext : DbContext
    {

        public MedicinesContext()
            : base("MedicinesContext")
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
