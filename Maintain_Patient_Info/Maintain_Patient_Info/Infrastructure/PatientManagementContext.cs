using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.HospitalServices;


namespace Maintain_Patient_Info.Infrastructure
{
    public class PatientManagementContext : DbContext

    {
        public PatientManagementContext(DbContextOptions<PatientManagementContext> options) : base(options)
        {

        }
<<<<<<< HEAD
        public virtual DbSet<PatientsRegistory> PatientsRegistory { get; set; }
        public virtual DbSet<LabTests> LabTests { get; set; } 
       
        public virtual DbSet<Consultation> Consultation { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
=======
        public virtual DbSet<PatientsRegistory> Patient_Infos { get; set; }
        public virtual DbSet<LabTests> LabTests { get; set; } 
        public virtual DbSet<Consultation> Consultation { get; set; }
        public virtual DbSet<Room> RoomDetails { get; set; }
>>>>>>> 340ce19387372fc6c78a23e62af23ea45c6588f7
        protected override void OnModelCreating(ModelBuilder modelsBuilder)
        {
            modelsBuilder.Entity<Room>().HasData(

               new Room
               {

                   Id=1,
                   RoomType = "Single",
                   charge = 4000


               },
              new Room
              {
                  Id = 2,
                  RoomType = "Single",
                  charge = 4000
              },

              new Room
              {
                  Id=3,
                  RoomType = "Double",
                  charge = 4000
              },
              new Room
              {
                  Id=4,
                  RoomType = "ICU",
                  charge = 6000
              },
              new Room
              {
                  Id=5,
                  RoomType = "Special Rooms",
                  charge = 6500
              }
              );

            modelsBuilder.Entity<LabTests>().HasData(

           new LabTests
           {
               Id = 1,
               LabTestName = "Blood Test",
               LabTestResult = "Completed",
               Charge = 150
           },
           new LabTests
           {
               Id=2,

               LabTestName = "Creatine Test",
               LabTestResult = "Pending",
               Charge = 200
           },
             new LabTests
             {
                 Id=3,

                 LabTestName = "Prick Test",
                 LabTestResult = "Completed",
                 Charge = 100
             },

             new LabTests
             {
                 Id=4,

                 LabTestName = "Diabetes Test",
                 LabTestResult = "Pending",
                 Charge = 150
             }
             ) ;

            modelsBuilder.Entity<Consultation>().HasData(
                new Consultation
                {
                    DocId = 1,

                    DoctorName = "Hari",
                    Purpose = "skin Problem",
                    Charge = 4005


                },
            new Consultation
            {
                DocId=2,
                
                DoctorName = "Rahul",
                Purpose = "Cardiac CheckUp",

                Charge = 500
            },
            new Consultation
            {
                DocId=3,
             
                DoctorName = "Kiran",
                Purpose = "Kidney CheckUp",

                Charge = 450
            },
            new Consultation
            {
                DocId=4,
               
                DoctorName = "Srikanth",
                Purpose = "Sugar CheckUp",

                Charge = 500
            }
            );
        }



    }

    

}
