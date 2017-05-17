using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace emde.kz.Models
{
    public class Medicine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string InternationalName { get; set; }
        public string Component { get; set; }
        public string PharmaAction { get; set; }
        public string Contrindiction { get; set; }
        public string Effect { get; set; }
        public string MethodsOfUse { get; set; }
        public string StorageCondition { get; set; }
        public string Image { get; set; }
        public string Dosage { get; set; }
        public bool Recipe { get; set; }
    }

    public class MedicineDbContext : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
    }
   
}