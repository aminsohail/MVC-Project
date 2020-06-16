using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagement.DAL
{
    public class PatientDAL: DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-H6C5O2EO;Initial Catalog=HospitalManagement;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientModel>()
                .ToTable("tb1Patient");

            modelBuilder.Entity<PatientModel>()
                .HasKey(p => p.id);
         // modelBuilder.Entity<PatientModel>()
           //     .Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
        }

        public DbSet<PatientModel> PatientModels { get; set; }


    }
}
