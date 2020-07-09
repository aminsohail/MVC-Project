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

        string conStr = "";

        public PatientDAL(string ConStr)
        {
            this.conStr = ConStr;
        }

        public PatientDAL(DbContextOptions<PatientDAL> options): base(options)
        {

         }

        public PatientDAL()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
        //   optionsBuilder.UseSqlServer(connectionString: conStr);
           optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-H6C5O2EO;Initial Catalog=HospitalManagement;Integrated Security=True");
         }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientModel>()
                .ToTable("tb1Patient");

            modelBuilder.Entity<Problem>()
                .ToTable("tb1Problem");

            modelBuilder.Entity<PatientModel>()
                .HasKey(p => p.id);
            //     .Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed) 


            modelBuilder.Entity<Problem>()
               .HasKey(p => p.id);

            // 1 to many
            modelBuilder.Entity<PatientModel>()
                .HasMany(c => c.problems)
                .WithOne(e => e.patient);
            modelBuilder.Entity<PatientModel>();
           
        }

        public DbSet<PatientModel> PatientModels { get; set; }
        public DbSet<Problem> Problems { get; set; }


    }
}
